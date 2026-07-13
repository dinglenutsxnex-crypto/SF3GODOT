using System;

namespace UnityEngine
{
	public static class GL
	{
		public static void PushMatrix() { }
		public static void PopMatrix() { }
		public static void LoadPixelMatrix() { }
		public static void LoadProjectionMatrix(Matrix4x4 mat) { }
		public static void LoadOrtho() { }
		public static void LoadIdentity() { }
		public static void MultMatrix(Matrix4x4 mat) { }

		public static void Begin(GLMode mode) { }
		public static void End() { }
		public static void Vertex3(float x, float y, float z) { }
		public static void Vertex(Vector3 v) { }
		public static void Color(Color c) { }
		public static void TexCoord2(float x, float y) { }
		public static void TexCoord3(float x, float y, float z) { }
		public static void MultiTexCoord(int unit, Vector3 v) { }
		public static void MultiTexCoord(int unit, float x, float y) { }
		public static void MultiTexCoord2(int unit, Vector3 v) { }
		public static void MultiTexCoord2(int unit, float x, float y) { }

		public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor) { }
		public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor, float depth) { }

		public static void Flush() { }
		public static void InvalidateState() { }

		public static bool wireframe { get; set; }
		public static bool sRGBWrite { get; set; }
		public static bool invertCulling { get; set; }

		public static void RenderTargetBarrier() { }

		public static Matrix4x4 GetGPUProjectionMatrix(Matrix4x4 proj, bool renderIntoTexture) => default;
		public static Matrix4x4 GetGPUProjectionMatrix(Matrix4x4 proj, int renderTargetIdentifier) => default;
		public static void Viewport(Rect pixelRect) { }
		public static void ClearWithSkybox(bool clearDepth, bool clearColor, Camera camera) { }
	}

	public enum GLMode
	{
		Lines = 1,
		Triangles = 4,
		Quads = 7,
	}
}
