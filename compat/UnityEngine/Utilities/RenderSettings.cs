using System;

namespace UnityEngine
{
	public static class RenderSettings
	{
		public static bool fog { get; set; }
		public static FogMode fogMode { get; set; }
		public static Color fogColor { get; set; }
		public static float fogDensity { get; set; }
		public static float fogStartDistance { get; set; }
		public static float fogEndDistance { get; set; }
		public static bool fogLinear { get; set; }
		public static Color ambientLight { get; set; }
		public static Color ambientSkyColor { get; set; }
		public static Color ambientEquatorColor { get; set; }
		public static Color ambientGroundColor { get; set; }
		public static float ambientIntensity { get; set; }
		public static Material skybox { get; set; }
		public static Light sun { get; set; }
		public static bool haloStrength { get; set; }
		public static bool flareStrength { get; set; }
		public static float flareFadeSpeed { get; set; }
		public static float bounceScale { get; set; }
		public static int reflectionIntensity { get; set; }
		public static int reflectionBounces { get; set; }
		public static float defaultReflectionIntensity { get; set; }
		public static int defaultReflectionResolution { get; set; }
		public static int reflectionCubemapCompression { get; set; }
		public static AmbientMode ambientMode { get; set; }
	}

	public static class QualitySettings
	{
		public static int pixelLightCount { get; set; }
		public static float shadowDistance { get; set; }
		public static int shadowCascades { get; set; }
		public static float shadowCascade2Split { get; set; }
		public static Vector3 shadowCascade4Split { get; set; }
		public static bool realtimeReflectionProbes { get; set; }
		public static float masterTextureLimit { get; set; }
		public static int antiAliasing { get; set; }
		public static float lodBias { get; set; }
		public static int maximumLODLevel { get; set; }
		public static float particleRaycastBudget { get; set; }
		public static bool softParticles { get; set; }
		public static bool softVegetation { get; set; }
		public static bool realtimeSoftShadows { get; set; }
		public static int vSyncCount { get; set; }
		public static int currentLevel { get; set; }
		public static string[] names => new string[0];
		public static ColorSpace activeColorSpace { get; set; }
		public static SkinWeights skinWeights { get; set; }
		public static void SetQualityLevel(int index) { }
		public static void SetQualityLevel(int index, bool applyExpensiveChanges) { }
		public static void IncreaseLevel() { }
		public static void IncreaseLevel(bool applyExpensiveChanges) { }
		public static void DecreaseLevel() { }
		public static void DecreaseLevel(bool applyExpensiveChanges) { }
		public static int GetQualityLevel() => 0;

		public static AnisotropicFiltering anisotropicFiltering { get; set; }
	}

	public static class Gizmos
	{
		public static Color color { get; set; }
		public static void DrawRay(Ray r) { }
		public static void DrawRay(Vector3 from, Vector3 direction) { }
		public static void DrawLine(Vector3 from, Vector3 to) { }
		public static void DrawWireSphere(Vector3 center, float radius) { }
		public static void DrawSphere(Vector3 center, float radius) { }
		public static void DrawWireCube(Vector3 center, Vector3 size) { }
		public static void DrawCube(Vector3 center, Vector3 size) { }
		public static void DrawMesh(Mesh mesh) { }
		public static void DrawMesh(Mesh mesh, Vector3 position) { }
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation) { }
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Vector3 scale) { }
		public static void DrawIcon(Vector3 center, string name) { }
		public static void DrawIcon(Vector3 center, string name, bool allowScaling) { }
		public static void DrawGUITexture(Rect screenRect, Texture texture) { }
		public static void DrawGUITexture(Rect screenRect, Texture texture, Material mat) { }
		public static bool visible { get; set; }
		public static Matrix4x4 matrix { get; set; }
	}
}
