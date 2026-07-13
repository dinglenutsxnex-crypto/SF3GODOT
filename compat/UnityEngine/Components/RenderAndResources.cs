using System;

namespace UnityEngine
{
    public class Shader : Object
    {
        public static Shader Find(string name) => null;
        public static int PropertyToID(string name) => 0;
        public int GetPropertyCount() => 0;
        public string GetPropertyName(int propertyIndex) => "";
        public ShaderPropertyType GetPropertyType(int propertyIndex) => default;
        public bool isSupported => false;
        public int renderQueue => 0;
        public static void SetGlobalFloat(string name, float value) { }
        public static void SetGlobalFloat(int nameID, float value) { }
        public static void SetGlobalVector(string name, Vector4 value) { }
        public static void SetGlobalVector(int nameID, Vector4 value) { }
        public static void SetGlobalColor(string name, Color value) { }
        public static void SetGlobalColor(int nameID, Color value) { }
        public static void SetGlobalMatrix(string name, Matrix4x4 value) { }
        public static void SetGlobalMatrix(int nameID, Matrix4x4 value) { }
        public static void SetGlobalTexture(string name, Texture value) { }
        public static void SetGlobalTexture(int nameID, Texture value) { }
        public static void SetGlobalInt(string name, int value) { }
        public static void SetGlobalInt(int nameID, int value) { }
        public static float GetGlobalFloat(string name) => 0f;
        public static float GetGlobalFloat(int nameID) => 0f;
        public static Vector4 GetGlobalVector(string name) => default;
        public static Vector4 GetGlobalVector(int nameID) => default;
        public static Color GetGlobalColor(string name) => default;
        public static Color GetGlobalColor(int nameID) => default;
        public static Matrix4x4 GetGlobalMatrix(string name) => default;
        public static Matrix4x4 GetGlobalMatrix(int nameID) => default;
        public static Texture GetGlobalTexture(string name) => null;
        public static Texture GetGlobalTexture(int nameID) => null;
        public static int GetGlobalInt(string name) => 0;
        public static int GetGlobalInt(int nameID) => 0;
        public static void EnableKeyword(string keyword) { }
        public static void DisableKeyword(string keyword) { }
        public static bool IsKeywordEnabled(string keyword) => false;
        public static void WarmupAllShaders() { }
        public static int TagToID(string name) => 0;
        public static string IDToTag(int id) => "";
    }

    public enum ShaderPropertyType
    {
        Color, Vector, Float, Range, Texture,
    }

    public class RenderTexture : Texture
    {
        public int width { get; set; }
        public int height { get; set; }
        public int depth { get; set; }
        public RenderTextureFormat format { get; set; }
        public bool useMipMap { get; set; }
        public bool autoGenerateMips { get; set; }
        public FilterMode filterMode { get; set; }
        public TextureWrapMode wrapMode { get; set; }
        public int antiAliasing { get; set; }
        public bool enableRandomWrite { get; set; }
        public RenderTexture() { }
        public RenderTexture(int width, int height, int depth) { }
        public RenderTexture(int width, int height, int depth, RenderTextureFormat format) { }
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer) => null;
        public static RenderTexture GetTemporary(int width, int height) => null;
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format) => null;
        public static RenderTexture GetTemporary(int width, int height, RenderTextureFormat format) => null;
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite) => null;
        public static RenderTexture GetTemporary(int width, int height, RenderTextureFormat format, RenderTextureReadWrite readWrite) => null;
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing) => null;
        public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, int mipCount) => null;
        public static void ReleaseTemporary(RenderTexture temp) { }
        public void Release() { }
        public bool Create() => false;
        public bool IsCreated() => false;
        public void DiscardContents() { }
        public static RenderTexture active { get; set; }
        public static void MarkRestoreExpected() { }
        public void GenerateMips() { }
    }

    public enum RenderTextureReadWrite
    {
        Default,
        Linear,
        sRGB,
    }

    public class Texture3D : Texture
    {
        public int width { get; set; }
        public int height { get; set; }
        public int depth { get; set; }
        public TextureFormat format { get; set; }
        public Texture3D(int width, int height, int depth, TextureFormat format, bool mipChain) { }
        public void SetPixels(Color[] colors) { }
        public Color[] GetPixels() => null;
        public void Apply() { }
    }

    public class Mesh : Object
    {
        public Vector3[] vertices { get; set; }
        public Vector3[] normals { get; set; }
        public Vector4[] tangents { get; set; }
        public Vector2[] uv { get; set; }
        public Vector2[] uv2 { get; set; }
        public Color[] colors { get; set; }
        public Color32[] colors32 { get; set; }
        public int[] triangles { get; set; }
        public int subMeshCount { get; set; }
        public Bounds bounds { get; set; }
        public int vertexCount => 0;
        public int blendShapeCount => 0;
        public Matrix4x4[] bindposes { get; set; }
        public BoneWeight[] boneWeights { get; set; }
        public void Clear() { }
        public void RecalculateNormals() { }
        public void RecalculateBounds() { }
        public void RecalculateTangents() { }
        public void MarkDynamic() { }
        public void UploadMeshData(bool markNoLongerReadable) { }
        public void Optimize() { }
        public int[] GetTriangles(int submesh) => null;
        public void SetTriangles(int[] triangles, int submesh) { }
        public void SetTriangles(int[] triangles, int submesh, bool calculateBounds) { }
        public void SetColors(Color[] inColors) { }
        public void SetColors(Color32[] inColors) { }
        public void SetUVs(int channel, System.Collections.Generic.List<Vector4> uvs) { }
        public void GetUVs(int channel, System.Collections.Generic.List<Vector4> uvs) { }
        public string GetBlendShapeName(int index) => "";
        public void AddBlendShapeFrame(string shapeName, float weight, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents) { }
    }

    public class ComputeBuffer : IDisposable
    {
        public int count { get; }
        public int stride { get; }
        public ComputeBuffer(int count, int stride) { }
        public ComputeBuffer(int count, int stride, ComputeBufferType type) { }
        public void SetData(Array data) { }
        public void GetData(Array data) { }
        public void Release() { }
        public void Dispose() { }
        public static void CopyCount(ComputeBuffer src, ComputeBuffer dst, int dstOffsetBytes) { }
    }

    public enum ComputeBufferType
    {
        Default = 0, Raw = 1, Append = 2, Counter = 4, Constant = 8,
        Structured = 16, IndirectArguments = 256,
    }

    public class CommandBuffer : IDisposable
    {
        public string name { get; set; }
        public CommandBuffer() { }
        public void Release() { }
        public void Dispose() { }
        public void Clear() { }
        public void ClearRenderTarget(bool depth, bool color, Color backgroundColor) { }
        public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material) { }
        public void DrawRenderer(Renderer renderer, Material material) { }
        public void DrawRenderer(Renderer renderer, Material material, int submeshIndex) { }
        public void DrawRenderer(Renderer renderer, Material material, int submeshIndex, int shaderPass) { }
        public void DrawProceduralIndirectNow(Matrix4x4 matrix, Material material, int shaderPass, MeshTopology topology, ComputeBuffer bufferWithArgs) { }
        public void DrawProceduralIndirectNow(Matrix4x4 matrix, Material material, MeshTopology topology, ComputeBuffer bufferWithArgs) { }
        public void Blit(Texture source, RenderTargetIdentifier dest) { }
        public void Blit(Texture source, RenderTargetIdentifier dest, Material mat) { }
    }

    public struct RenderTargetIdentifier
    {
        public static implicit operator RenderTargetIdentifier(RenderTexture rt) => default;
        public static implicit operator RenderTargetIdentifier(string name) => default;
    }

    public class ScriptableObject : Object
    {
        public static T CreateInstance<T>() where T : ScriptableObject => default;
        public static ScriptableObject CreateInstance(Type type) => null;
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
        protected virtual void OnDestroy() { }
    }

    public class TextAsset : Object
    {
        public string text => "";
        public byte[] bytes => null;
        public override string ToString() => text;
    }

    public class RectTransform : Transform
    {
        public Rect rect { get; set; }
        public Vector2 anchoredPosition { get; set; }
        public Vector2 anchorMin { get; set; }
        public Vector2 anchorMax { get; set; }
        public Vector2 pivot { get; set; }
        public Vector2 sizeDelta { get; set; }
        public Vector2 anchoredPosition3D { get; set; }
        public Vector2 offsetMin { get; set; }
        public Vector2 offsetMax { get; set; }
        public void SetSizeWithCurrentAnchors(Axis axis, float size) { }
        public void GetLocalCorners(Vector3[] fourCornersArray) { }
        public void GetWorldCorners(Vector3[] fourCornersArray) { }
        public void ForceUpdateRectTransforms() { }
        public enum Axis { Horizontal, Vertical }
    }
}
