using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SceneConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectRoot = args.Length > 0 ? args[0] : @"C:\Users\Admin\Downloads\SF3PROJECT\SF3GODOT";
            string scenesDir = Path.Combine(projectRoot, "assets", "scenes");
            string outputDir = Path.Combine(projectRoot, "scenes");

            Directory.CreateDirectory(outputDir);

            var jsonFiles = Directory.GetFiles(scenesDir, "*.scene.json");
            foreach (var jsonFile in jsonFiles)
            {
                Console.WriteLine($"Converting {Path.GetFileName(jsonFile)}...");
                ConvertScene(jsonFile, outputDir, projectRoot);
            }

            Console.WriteLine("Done!");
        }

        static void ConvertScene(string jsonFile, string outputDir, string projectRoot)
        {
            string json = File.ReadAllText(jsonFile);
            var sceneData = JsonNode.Parse(json);

            string sceneName = sceneData["sceneName"]?.GetValue<string>() ?? Path.GetFileNameWithoutExtension(jsonFile).Replace(".scene", "");
            var hierarchy = sceneData["hierarchy"]?.AsArray();

            if (hierarchy == null) return;

            var tscn = new List<string>();
            tscn.Add("[gd_scene format=3]");
            tscn.Add("");

            int nodeId = 0;
            var nodePaths = new Dictionary<string, string>();

            // External resources
            int extResourceId = 1;
            var extResources = new List<string>();

            // Create a single root node wrapping everything
            string sceneRootName = sceneName + "_Root";
            tscn.Add($"[node name=\"{sceneRootName}\" type=\"Node\"]");
            tscn.Add("");

            foreach (var rootNode in hierarchy)
            {
                ConvertNode(rootNode, tscn, ref nodeId, ref extResourceId, extResources, nodePaths, sceneRootName, sceneName, projectRoot);
            }

            // Write ext_resources after the gd_scene header
            for (int i = 0; i < extResources.Count; i++)
            {
                tscn.Insert(1 + i, extResources[i]);
            }

            string outputFile = Path.Combine(outputDir, sceneName + ".tscn");
            File.WriteAllLines(outputFile, tscn);
            Console.WriteLine($"  -> {outputFile} ({tscn.Count} lines)");
        }

        static void ConvertNode(JsonNode node, List<string> tscn, ref int nodeId, ref int extResourceId, 
            List<string> extResources, Dictionary<string, string> nodePaths, string parentPath, string sceneName, string projectRoot, string parentType = "Node")
        {
            string name = node["name"]?.GetValue<string>() ?? "Node";
            string type = DetermineNodeType(node);

            // Check parent-child type compatibility
            if (!IsCompatibleNodeType(type, parentType))
            {
                tscn.Add($"# Skipped node '{name}' (type {type}): incompatible under parent type {parentType}");
                return;
            }

            bool isRoot = string.IsNullOrEmpty(parentPath);
            string parentRef = isRoot ? null : parentPath;
            string myPath = isRoot ? name : parentRef + "/" + name;
            nodePaths[name] = myPath;

            int myId = nodeId++;
            string nodeHeader = isRoot 
                ? $"[node name=\"{name}\" type=\"{type}\"]"
                : $"[node name=\"{name}\" type=\"{type}\" parent=\"{parentRef}\"]";
            tscn.Add(nodeHeader);

            // Transform
            var transform = node["transform"];
            if (transform != null)
            {
                var pos = transform["position"];
                var rot = transform["rotation"];
                var scale = transform["scale"];

                float px = pos?["x"]?.GetValue<float>() ?? 0;
                float py = pos?["y"]?.GetValue<float>() ?? 0;
                float pz = pos?["z"]?.GetValue<float>() ?? 0;

                float rx = rot?["x"]?.GetValue<float>() ?? 0;
                float ry = rot?["y"]?.GetValue<float>() ?? 0;
                float rz = rot?["z"]?.GetValue<float>() ?? 0;
                float rw = rot?["w"]?.GetValue<float>() ?? 1;

                float sx = scale?["x"]?.GetValue<float>() ?? 1;
                float sy = scale?["y"]?.GetValue<float>() ?? 1;
                float sz = scale?["z"]?.GetValue<float>() ?? 1;

                bool isUI = type == "Control" || type == "CanvasLayer" || type == "Label" || type == "TextureRect" || type == "Panel" || type == "Sprite2D" || type == "Camera2D";
                bool is3D = type == "Node3D" || type == "Camera3D";

                if (isUI)
                {
                    py = -py; // Flip Y for UI
                    tscn.Add($"position = Vector2({px}, {py})");
                    float rotDeg = rz * 57.29578f;
                    tscn.Add($"rotation = {rotDeg}");
                    tscn.Add($"scale = Vector2({sx}, {sy})");
                }
                else // Node3D / Camera3D / default
                {
                    tscn.Add($"transform = Transform3D(1, 0, 0, 0, 1, 0, 0, 0, 1, {px}, {py}, {pz})");
                    tscn.Add($"rotation_degrees = Vector3({rx * 57.29578f}, {ry * 57.29578f}, {rz * 57.29578f})");
                    tscn.Add($"scale = Vector3({sx}, {sy}, {sz})");
                }
            }

            // Components
            var components = node["components"]?.AsArray();
            if (components != null)
            {
                foreach (var comp in components)
                {
                    string compType = comp["type"]?.GetValue<string>();
                    var compData = comp["data"];

                    switch (compType)
                    {
                        case "camera":
                            ApplyCameraProperties(compData, tscn, type);
                            break;
                        case "uiPanel":
                        case "uiWidget":
                        case "uiLabel":
                        case "uiSprite":
                            ApplyNGUIProperties(compType, compData, tscn, type, extResources, ref extResourceId, projectRoot);
                            break;
                        case "script":
                            ApplyScript(compData, tscn, myPath, extResources, ref extResourceId, projectRoot);
                            break;
                        case "boxCollider":
                            ApplyBoxCollider(compData, tscn);
                            break;
                    }
                }
            }

            tscn.Add("");

            // Children
            var children = node["children"]?.AsArray();
            if (children != null)
            {
                foreach (var child in children)
                {
                    ConvertNode(child, tscn, ref nodeId, ref extResourceId, extResources, nodePaths, myPath, sceneName, projectRoot, type);
                }
            }
        }

        static string DetermineNodeType(JsonNode node)
        {
            var components = node["components"]?.AsArray();
            if (components != null)
            {
                foreach (var comp in components)
                {
                    string compType = comp["type"]?.GetValue<string>();
                    if (compType == "camera")
                    {
                        var data = comp["data"];
                        string camType = data?["type"]?.GetValue<string>();
                        if (camType == "orthographic")
                            return "Camera2D";
                        else
                            return "Camera3D";
                    }
            if (compType == "uiLabel")
            {
                return "Label";
            }
            if (compType == "uiSprite")
            {
                return "TextureRect";
            }
            if (compType == "uiPanel" || compType == "uiWidget")
            {
                return "Control";
            }
                }
            }

            string name = node["name"]?.GetValue<string>() ?? "";
            if (name.Contains("Camera")) return "Camera3D";
            if (name.Contains("UI") || name.Contains("anchor") || name.Contains("Panel") || name.Contains("Label") || name.Contains("Sprite"))
                return "Control";

            return "Node3D";
        }

        static void ApplyCameraProperties(JsonNode data, List<string> tscn, string nodeType)
        {
            if (data == null) return;

            bool enabled = data["enabled"]?.GetValue<int>() == 1;
            var clearFlagsNode = data["clearFlags"];
            int clearFlags = 0;
            if (clearFlagsNode != null)
            {
                if (clearFlagsNode.GetValueKind() == JsonValueKind.Number)
                    clearFlags = clearFlagsNode.GetValue<int>();
                else if (clearFlagsNode.GetValueKind() == JsonValueKind.String)
                    int.TryParse(clearFlagsNode.GetValue<string>(), out clearFlags);
            }
            var bgColor = data["backgroundColor"];
            float near = data["nearClip"]?.GetValue<float>() ?? 0.1f;
            float far = data["farClip"]?.GetValue<float>() ?? 1000f;
            float fov = data["fieldOfView"]?.GetValue<float>() ?? 60f;
            float orthoSize = data["orthographicSize"]?.GetValue<float>() ?? 5f;

            if (nodeType == "Camera2D")
            {
                tscn.Add($"zoom = Vector2({orthoSize}, {orthoSize})");
            }
            else
            {
                tscn.Add($"fov = {fov}");
                tscn.Add($"near = {near}");
                tscn.Add($"far = {far}");
            }

            if (bgColor != null)
            {
                float r = bgColor["r"]?.GetValue<float>() ?? 0;
                float g = bgColor["g"]?.GetValue<float>() ?? 0;
                float b = bgColor["b"]?.GetValue<float>() ?? 0;
                float a = bgColor["a"]?.GetValue<float>() ?? 1;
                tscn.Add($"# Background color: {r}, {g}, {b}, {a}");
                // Background color is set via WorldEnvironment
            }
        }

        static void ApplyNGUIProperties(string compType, JsonNode data, List<string> tscn, string nodeType, 
            List<string> extResources, ref int extResourceId, string projectRoot)
        {
            if (data == null) return;

            switch (compType)
            {
                case "uiPanel":
                    // UIPanel -> CanvasLayer or Control
                    int depth = data["depth"]?.GetValue<int>() ?? 0;
                    tscn.Add($"# NGUI Panel depth: {depth}");
                    break;
                case "uiWidget":
                    // UIWidget -> Control with size/anchors
                    float w = data["width"]?.GetValue<float>() ?? 100;
                    float h = data["height"]?.GetValue<float>() ?? 100;
                    tscn.Add($"custom_minimum_size = Vector2({w}, {h})");
                    // Anchors
                    var anchors = data["anchors"];
                    if (anchors != null)
                    {
                        // NGUI anchors -> Godot anchors
                        ApplyAnchors(anchors, tscn);
                    }
                    break;
                case "uiLabel":
                    string text = data["text"]?.GetValue<string>() ?? "";
                    int fontSize = data["fontSize"]?.GetValue<int>() ?? 16;
                    var color = data["color"];
                    tscn.Add($"text = \"{EscapeString(text)}\"");
                    tscn.Add($"font_size = {fontSize}");
                    if (color != null)
                    {
                        float r = color["r"]?.GetValue<float>() ?? 1;
                        float g = color["g"]?.GetValue<float>() ?? 1;
                        float b = color["b"]?.GetValue<float>() ?? 1;
                        float a = color["a"]?.GetValue<float>() ?? 1;
                        tscn.Add($"modulate = Color({r}, {g}, {b}, {a})");
                    }
                    // Change node type to Label in header (we can't easily modify after adding)
                    break;
                case "uiSprite":
                    string spriteName = data["spriteName"]?.GetValue<string>() ?? "";
                    var atlasGuid = data["atlas"]?["guid"]?.GetValue<string>();
                    if (!string.IsNullOrEmpty(spriteName) && !string.IsNullOrEmpty(atlasGuid))
                    {
                        // Would need to load atlas and sprite
                        tscn.Add($"# Sprite: {spriteName} from atlas {atlasGuid}");
                    }
                    break;
            }
        }

        static void ApplyAnchors(JsonNode anchors, List<string> tscn)
        {
            // NGUI anchors: left, right, bottom, top each have target (widget), relative (0-1), absolute (pixels)
            // Godot anchors: anchor_left, anchor_right, anchor_top, anchor_bottom (0-1), offset_left, offset_right, offset_top, offset_bottom
            // This is complex - simplified version
            tscn.Add($"# Anchors: {anchors.ToJsonString()}");
        }

        static void ApplyScript(JsonNode compData, List<string> tscn, string nodePath, 
            List<string> extResources, ref int extResourceId, string projectRoot)
        {
            var scriptInfo = compData?["script"];
            if (scriptInfo == null) return;

            string guid = scriptInfo["guid"]?.GetValue<string>();
            if (string.IsNullOrEmpty(guid)) return;

            // Map Unity script GUID to Godot script path
            string scriptPath = MapGuidToScript(guid, projectRoot);
            if (!string.IsNullOrEmpty(scriptPath))
            {
                int curId = extResourceId++;
                extResources.Add($"[ext_resource type=\"Script\" path=\"{scriptPath}\" id=\"{curId}\"]");
                // Check if script already assigned to this node
                bool hasScript = tscn.Any(line => line.TrimStart().StartsWith("script = "));
                if (!hasScript)
                {
                    tscn.Add($"script = ExtResource(\"{curId}\")");
                }
                else
                {
                    tscn.Add($"# Additional script (ignored, Godot supports one per node): {scriptPath}");
                }
            }
            else
            {
                tscn.Add($"# Script GUID not mapped: {guid}");
            }
        }

        static string MapGuidToScript(string guid, string projectRoot)
        {
            // Search for .cs.meta file with matching GUID
            var metaFiles = Directory.GetFiles(projectRoot, "*.cs.meta", SearchOption.AllDirectories);
            foreach (var metaFile in metaFiles)
            {
                string metaContent = File.ReadAllText(metaFile);
                if (metaContent.Contains($"guid: {guid}"))
                {
                    string csFile = metaFile.Substring(0, metaFile.Length - 5); // Remove .meta
                    // Convert to Godot resource path
                    string relativePath = csFile.Substring(projectRoot.Length + 1).Replace("\\", "/");
                    return "res://" + relativePath;
                }
            }
            return null;
        }

        static void ApplyBoxCollider(JsonNode data, List<string> tscn)
        {
            var size = data["size"];
            var center = data["center"];
            bool isTrigger = data["isTrigger"]?.GetValue<int>() == 1;

            if (size != null)
            {
                float sx = size["x"]?.GetValue<float>() ?? 1;
                float sy = size["y"]?.GetValue<float>() ?? 1;
                float sz = size["z"]?.GetValue<float>() ?? 1;
                tscn.Add($"# BoxCollider size: {sx}, {sy}, {sz}");
            }
        }

        static bool IsCompatibleNodeType(string childType, string parentType)
        {
            if (string.IsNullOrEmpty(parentType) || parentType == "Node")
                return true;

            // 3D nodes can only have 3D children
            bool is3DParent = parentType == "Node3D" || parentType == "Camera3D";
            bool is3DChild = childType == "Node3D" || childType == "Camera3D";
            if (is3DParent && is3DChild) return true;
            if (is3DParent && !is3DChild) return false;

            // Control/UI nodes can only have UI children
            bool isControlParent = parentType == "Control" || parentType == "Label" || parentType == "TextureRect" || parentType == "Panel" || parentType == "CanvasLayer";
            bool isControlChild = childType == "Control" || childType == "Label" || childType == "TextureRect" || childType == "Panel" || childType == "CanvasLayer" || childType == "Camera2D" || childType == "Node2D" || childType == "Sprite2D";
            if (isControlParent && isControlChild) return true;
            if (isControlParent && !isControlChild) return false;

            return true;
        }

        static string SanitizePath(string path)
        {
            return path.Replace("/", "_").Replace(":", "_");
        }

        static string EscapeString(string s)
        {
            return s.Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r");
        }
    }

    static class JsonExtensions
    {
        public static string ToJsonString(this JsonNode node)
        {
            return JsonSerializer.Serialize(node);
        }
    }
}