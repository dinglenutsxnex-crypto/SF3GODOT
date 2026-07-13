using System;

namespace UnityEngine
{
    public struct Bounds
    {
        public Vector3 center { get; set; }
        public Vector3 size { get; set; }
        public Vector3 extents { get; set; }
        public Vector3 min { get; set; }
        public Vector3 max { get; set; }
        public Bounds(Vector3 center, Vector3 size) { this.center = center; this.size = size; extents = size * 0.5f; min = center - extents; max = center + extents; }
        public void Encapsulate(Vector3 point) { }
        public void Encapsulate(Bounds bounds) { }
        public void Expand(float amount) { }
        public void SetMinMax(Vector3 min, Vector3 max) { }
        public bool Contains(Vector3 point) => false;
        public bool Intersects(Bounds bounds) => false;
        public bool IntersectRay(Ray ray) => false;
        public bool IntersectRay(Ray ray, out float distance) { distance = 0; return false; }
        public Vector3 ClosestPoint(Vector3 point) => default;
        public override bool Equals(object other) => false;
        public override int GetHashCode() => 0;
        public override string ToString() => "";
    }

    public struct Matrix4x4
    {
        public float m00, m01, m02, m03;
        public float m10, m11, m12, m13;
        public float m20, m21, m22, m23;
        public float m30, m31, m32, m33;

        public static Matrix4x4 identity => default;
        public static Matrix4x4 zero => default;

        public float this[int row, int column]
        {
            get => 0;
            set { }
        }

        public Vector4 GetColumn(int index) => default;
        public Vector4 GetRow(int index) => default;
        public void SetColumn(int index, Vector4 column) { }
        public void SetRow(int index, Vector4 row) { }
        public void SetTRS(Vector3 pos, Quaternion q, Vector3 s) { }
        public Vector3 MultiplyPoint(Vector3 point) => default;
        public Vector3 MultiplyPoint3x4(Vector3 point) => default;
        public Vector3 MultiplyVector(Vector3 vector) => default;
        public Matrix4x4 inverse => default;
        public Matrix4x4 transpose => default;
        public static Matrix4x4 Scale(Vector3 vector) => default;
        public static Matrix4x4 Translate(Vector3 vector) => default;
        public static Matrix4x4 Rotate(Quaternion q) => default;
        public static Matrix4x4 TRS(Vector3 pos, Quaternion q, Vector3 s) => default;
        public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b) => default;
        public static Vector4 operator *(Matrix4x4 a, Vector4 b) => default;
        public static Matrix4x4 Inverse(Matrix4x4 m) => default;
        public static Matrix4x4 TRS2(Vector3 pos, Quaternion q, Vector3 s) => default;
    }

    public class RectOffset
    {
        public int left { get; set; }
        public int right { get; set; }
        public int top { get; set; }
        public int bottom { get; set; }
        public int horizontal => left + right;
        public int vertical => top + bottom;
        public RectOffset() { }
        public RectOffset(int left, int right, int top, int bottom) { this.left = left; this.right = right; this.top = top; this.bottom = bottom; }
    }

    public struct Plane
    {
        public Vector3 normal { get; set; }
        public float distance { get; set; }
        public Plane(Vector3 inNormal, Vector3 inPoint) { this.normal = inNormal; this.distance = -Vector3.Dot(inNormal, inPoint); }
        public Plane(Vector3 inNormal, float d) { this.normal = inNormal; this.distance = d; }
        public Plane(Vector3 a, Vector3 b, Vector3 c) { this.normal = Vector3.Cross(b - a, c - a).normalized; this.distance = -Vector3.Dot(normal, a); }
        public bool Raycast(Ray ray) => false;
        public bool Raycast(Ray ray, out float enter) { enter = 0; return false; }
    }

    public struct LayerMask
    {
        public int value { get; set; }
        public static implicit operator int(LayerMask mask) => mask.value;
        public static implicit operator LayerMask(int intVal) => new LayerMask { value = intVal };
        public static int NameToLayer(string layerName) => 0;
        public static string LayerToName(int layer) => "";
        public static int GetMask(params string[] layerNames) => 0;
    }

    public struct BoneWeight
    {
        public float weight0 { get; set; }
        public float weight1 { get; set; }
        public float weight2 { get; set; }
        public float weight3 { get; set; }
        public int boneIndex0 { get; set; }
        public int boneIndex1 { get; set; }
        public int boneIndex2 { get; set; }
        public int boneIndex3 { get; set; }
    }

    public class Gradient
    {
        public ColorKey[] colorKeys { get; set; }
        public AlphaKey[] alphaKeys { get; set; }
        public GradientMode mode { get; set; }
        public Gradient() { colorKeys = new ColorKey[0]; alphaKeys = new AlphaKey[0]; }
        public Color Evaluate(float time) => default;
    }

    public struct ColorKey
    {
        public Color color;
        public float time;
        public ColorKey(Color color, float time) { this.color = color; this.time = time; }
    }

    public struct AlphaKey
    {
        public float alpha;
        public float time;
        public AlphaKey(float alpha, float time) { this.alpha = alpha; this.time = time; }
    }

    public enum GradientMode
    {
        Blend,
        Fixed,
        PerceptualBlend,
    }

    public enum HideFlags
    {
        None = 0, HideInHierarchy = 1, HideInInspector = 2, DontSaveInEditor = 4,
        NotEditable = 8, DontSaveInBuild = 16, DontUnloadUnusedAsset = 32,
        DontSave = 52, HideAndDontSave = 61,
    }

    public enum Space
    {
        World = 0,
        Self = 1,
    }

    public enum RenderTextureFormat
    {
        ARGB32, Depth, ARGBHalf, Shadowmap, RGB565, ARGB4444, ARGB1555, Default,
        ARGB2101010, DefaultHDR, ARGBFloat, RGFloat, RGHalf, RFloat, RHalf, R8,
    }

    public enum SystemLanguage
    {
        Afrikaans, Arabic, Basque, Belarusian, Bulgarian, Catalan, Chinese,
        Czech, Danish, Dutch, English, Estonian, Faroese, Finnish, French,
        German, Greek, Hebrew, Hugarian, Icelandic, Indonesian, Italian,
        Japanese, Korean, Latvian, Lithuanian, Norwegian, Polish, Portuguese,
        Romanian, Russian, SerboCroatian, Slovak, Slovenian, Spanish, Swedish,
        Thai, Turkish, Ukrainian, Vietnamese, ChineseSimplified, ChineseTraditional,
        Unknown, Hindi,
    }

    public enum AudioRolloffMode
    {
        Logarithmic, Linear, Custom,
    }

    public enum SendMessageOptions
    {
        RequireReceiver = 0,
        DontRequireReceiver = 1,
    }

    public enum EventTriggerType
    {
        PointerEnter, PointerExit, PointerDown, PointerUp, PointerClick,
        Drag, Drop, Scroll, UpdateSelected, Select, Deselect, Move,
        InitializePotentialDrag, BeginDrag, EndDrag, Submit, Cancel,
    }

    public class CharacterInfo
    {
        public int index;
        public UVRect uv;
        public Vector2 uvTopLeft;
        public Vector2 uvBottomLeft;
        public Vector2 uvTopRight;
        public Vector2 uvBottomRight;
        public float x, y, width, height, advance;
        public int flipped;
        public int minY => 0;
        public int maxY => 0;
        public int minX => 0;
        public int maxX => 0;
    }

    public struct UVRect
    {
        public float x, y, width, height;
    }

    public struct GradientColorKey
    {
        public Color color;
        public float time;
        public GradientColorKey(Color color, float time) { this.color = color; this.time = time; }
    }

    public struct GradientAlphaKey
    {
        public float alpha;
        public float time;
        public GradientAlphaKey(float alpha, float time) { this.alpha = alpha; this.time = time; }
    }

    public class MaterialPropertyBlock
    {
        public MaterialPropertyBlock() { }
        public void SetFloat(string name, float value) { }
        public void SetFloat(int nameID, float value) { }
        public void SetVector(string name, Vector4 value) { }
        public void SetVector(int nameID, Vector4 value) { }
        public void SetColor(string name, Color value) { }
        public void SetColor(int nameID, Color value) { }
        public void SetTexture(string name, Texture value) { }
        public void SetTexture(int nameID, Texture value) { }
        public void SetMatrix(string name, Matrix4x4 value) { }
        public void SetMatrix(int nameID, Matrix4x4 value) { }
        public void SetInt(string name, int value) { }
        public void SetInt(int nameID, int value) { }
        public float GetFloat(string name) => 0f;
        public float GetFloat(int nameID) => 0f;
        public Vector4 GetVector(string name) => default;
        public Vector4 GetVector(int nameID) => default;
        public Color GetColor(string name) => default;
        public Color GetColor(int nameID) => default;
        public Texture GetTexture(string name) => null;
        public Texture GetTexture(int nameID) => null;
        public bool HasProperty(string name) => false;
        public bool HasProperty(int nameID) => false;
        public void Clear() { }
        public bool isEmpty => true;
    }

    public enum ShadowCastingMode
    {
        Off = 0,
        On = 1,
        TwoSided = 2,
        ShadowsOnly = 3,
    }

    public enum ScaleMode
    {
        StretchToFill = 0,
        ScaleAndCrop = 1,
        ScaleToFit = 2,
    }

    public struct ColorBlock
    {
        public Color normalColor { get; set; }
        public Color highlightedColor { get; set; }
        public Color pressedColor { get; set; }
        public Color disabledColor { get; set; }
        public float colorMultiplier { get; set; }
        public float fadeDuration { get; set; }
        public static ColorBlock defaultColorBlock => default;
    }

    public enum SkinWeights
    {
        OneBone = 1,
        TwoBones = 2,
        FourBones = 4,
        Automatic = 0,
    }

    public enum MeshTopology
    {
        Triangles = 0,
        Quads = 2,
        Lines = 3,
        LineStrip = 4,
        Points = 5,
    }

    public enum TransparencySortMode
    {
        Default = 0,
        Perspective = 1,
        Orthographic = 2,
        CustomAxis = 3,
    }

    public enum RigidbodyConstraints
    {
        None = 0,
        FreezePositionX = 2,
        FreezePositionY = 4,
        FreezePositionZ = 8,
        FreezeRotationX = 16,
        FreezeRotationY = 32,
        FreezeRotationZ = 64,
        FreezePosition = 14,
        FreezeRotation = 112,
        FreezeAll = 126,
    }

    public enum PrimitiveType
    {
        Sphere,
        Capsule,
        Cylinder,
        Cube,
        Plane,
        Quad,
    }

    public enum FogMode
    {
        Linear = 3,
        Exponential = 1,
        ExponentialSquared = 2,
    }

    public enum AmbientMode
    {
        Skybox = 0,
        Flat = 1,
        Trilight = 3,
        CustomColor = 4,
    }

    public enum DeviceType2
    {
        Unknown = 0,
        Handheld = 1,
        Console = 2,
        Desktop = 3,
    }

    public enum RenderMode
    {
        ScreenSpaceOverlay = 0,
        ScreenSpaceCamera = 1,
        WorldSpace = 2,
    }

    public enum AudioSourceCurveType
    {
        CustomCurve = 0,
        CustomRolloff = 0,
        ReverbZoneMix = 1,
        Spread = 2,
        SpatialBlend = 3,
    }

    public enum ColorSpace
    {
        Uninitialized = -1,
        Gamma = 0,
        Linear = 1,
    }
}
