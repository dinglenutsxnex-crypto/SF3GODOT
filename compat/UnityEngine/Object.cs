using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace UnityEngine
{
	// Renamed from Object to avoid CS0104 ambiguity with System.Object
	public class UnityEngineObject
	{
		public string name { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
		public HideFlags hideFlags { get; set; }

		public int GetInstanceID() => throw new NotImplementedException();

		public static void Destroy(object target)
		{
			if (target is Godot.Node node) node.QueueFree();
			else if (target is IDisposable disp) disp.Dispose();
		}

		public static void Destroy(object target, float t)
		{
			Destroy(target);
		}

		public static void DestroyImmediate(object target)
		{
			Destroy(target);
		}

		public static void DestroyImmediate(object target, bool allowDestroyingAssets)
		{
			Destroy(target);
		}

		public static void DestroyObject(object obj) { }

		public static void DontDestroyOnLoad(object target)
		{
			if (target is Godot.Node node)
			{
				var tree = Godot.Engine.GetMainLoop() as SceneTree;
				if (tree != null && node != tree.Root)
				{
					tree.Root.AddChild(node);
				}
			}
			else if (target is GameObject go && go._node != null)
			{
				var tree = Godot.Engine.GetMainLoop() as SceneTree;
				if (tree != null && go._node != tree.Root)
				{
					tree.Root.AddChild(go._node);
				}
			}
		}

		static SceneTree GetTree()
		{
			return Godot.Engine.GetMainLoop() as SceneTree;
		}

		static List<Godot.Node> GetAllNodes(Godot.Node root)
		{
			var result = new List<Godot.Node>();
			result.Add(root);
			foreach (var child in root.GetChildren())
			{
				result.AddRange(GetAllNodes(child));
			}
			return result;
		}

		static bool TypeMatches(Type type, object obj)
		{
			if (obj == null) return false;
			return type.IsInstanceOfType(obj);
		}

		public static T FindObjectOfType<T>() where T : class
		{
			return FindObjectOfType(typeof(T)) as T;
		}

		public static T FindObjectOfType<T>(bool includeInactive) where T : class
		{
			return FindObjectOfType(typeof(T)) as T;
		}

		public static object FindObjectOfType(Type type)
		{
			var tree = GetTree();
			if (tree == null) return null;
			var allNodes = GetAllNodes(tree.Root);
			foreach (var node in allNodes)
			{
				if (node is Component c)
				{
					if (type.IsAssignableFrom(c.GetType())) return c;
				}
				else if (type.IsAssignableFrom(node.GetType()))
				{
					return node;
				}
				// Also check GameObject wrappers
				if (type == typeof(GameObject) || type.IsSubclassOf(typeof(GameObject)))
				{
					// Try to see if there's a GameObject wrapping this node
				}
			}
			return null;
		}

		public static T[] FindObjectsOfType<T>() where T : class
		{
			return FindObjectsOfType(typeof(T)).Cast<T>().ToArray();
		}

		public static T[] FindObjectsOfType<T>(bool includeInactive) where T : class
		{
			return FindObjectsOfType(typeof(T)).Cast<T>().ToArray();
		}

		public static object[] FindObjectsOfType(Type type)
		{
			var tree = GetTree();
			if (tree == null) return new object[0];
			var allNodes = GetAllNodes(tree.Root);
			var matches = new List<object>();
			foreach (var node in allNodes)
			{
				if (node is Component c)
				{
					if (type.IsAssignableFrom(c.GetType())) matches.Add(c);
				}
				else if (type.IsAssignableFrom(node.GetType()))
				{
					matches.Add(node);
				}
			}
			return matches.ToArray();
		}

		public static object[] FindObjectsOfType(Type type, bool includeInactive)
		{
			return FindObjectsOfType(type);
		}

		public static object Instantiate(object original)
		{
			if (original is Godot.Node node)
			{
				var copy = node.Duplicate();
				var tree = GetTree();
				if (tree != null) tree.Root.AddChild(copy);
				return copy;
			}
			return null;
		}

		public static T Instantiate<T>(T original) where T : class
		{
			return Instantiate((object)original) as T;
		}

		public static object Instantiate(object original, Transform parent)
		{
			var copy = Instantiate(original) as Godot.Node;
			if (copy != null && parent != null)
			{
				var tree = GetTree();
				if (tree != null && parent.node != null)
				{
					parent.node.AddChild(copy);
				}
			}
			return copy;
		}

		public static T Instantiate<T>(T original, Transform parent) where T : class
		{
			return Instantiate((object)original, parent) as T;
		}

		public static object Instantiate(object original, Transform parent, bool instantiateInWorldSpace)
		{
			return Instantiate(original, parent);
		}

		public static T Instantiate<T>(T original, Transform parent, bool instantiateInWorldSpace) where T : class
		{
			return Instantiate(original, parent) as T;
		}

		public static object Instantiate(object original, Vector3 position, Quaternion rotation)
		{
			var copy = Instantiate(original) as Godot.Node;
			if (copy != null && copy is Node3D n3d)
			{
				n3d.Position = new Vector3(position.x, position.y, position.z);
				n3d.Quaternion = new Godot.Quaternion(rotation.x, rotation.y, rotation.z, rotation.w);
			}
			return copy;
		}

		public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : class
		{
			return Instantiate((object)original, position, rotation) as T;
		}

		public static object Instantiate(object original, Vector3 position, Quaternion rotation, Transform parent)
		{
			return Instantiate(original, position, rotation, parent);
		}

		public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation, Transform parent) where T : class
		{
			return Instantiate(original, position, rotation) as T;
		}

		public override string ToString() => name;

		public static implicit operator bool(UnityEngineObject exists) => exists != null;
	}
}
