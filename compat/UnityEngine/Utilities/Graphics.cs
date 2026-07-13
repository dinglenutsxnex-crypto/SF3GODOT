using System;

namespace UnityEngine
{
	public static class Graphics
	{
		public static void Blit(Texture source, RenderTexture dest) { }
		public static void Blit(Texture source, RenderTexture dest, Material mat) { }
		public static void Blit(Texture source, RenderTexture dest, Material mat, int pass) { }
		public static void Blit(Texture source, Material mat) { }
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation) { }
		public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion rotation, Material material, int layer) { }
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material) { }
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer) { }
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera) { }
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex) { }
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties) { }
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows) { }
		public static void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int layer, Camera camera, int submeshIndex, MaterialPropertyBlock properties, bool castShadows, bool receiveShadows) { }
		public static void DrawMesh(Mesh mesh, Transform position) { }
		public static void DrawMesh(Mesh mesh, Transform position, Material material) { }
		public static void DrawMesh(Mesh mesh, Transform position, Material material, int layer) { }
		public static void DrawRenderer(Renderer renderer) { }
		public static void DrawRenderer(Renderer renderer, Material material) { }
		public static void DrawRenderer(Renderer renderer, Material material, int submeshIndex) { }
		public static void DrawRenderer(Renderer renderer, Material material, int submeshIndex, int layer) { }
		public static void DrawMeshNow(Mesh mesh, Vector3 position, Quaternion rotation) { }
		public static void DrawMeshNow(Mesh mesh, Matrix4x4 matrix) { }
		public static void DrawTexture(Rect screenRect, Texture texture) { }
		public static void DrawTexture(Rect screenRect, Texture texture, Material mat) { }
		public static void DrawTexture(Rect screenRect, string text) { }

		public static void SetRenderTarget(RenderTexture rt) { }
		public static void SetRenderTarget(RenderBuffer colorBuffer, RenderBuffer depthBuffer) { }
		public static RenderTexture active { get; set; }

		public static void ClearRandomWriteTargets() { }
		public static void SetRandomWriteTarget(int index, RenderTexture rt) { }
		public static void SetRandomWriteTarget(int index, ComputeBuffer buffer) { }

		public static void ExecuteCommandBuffer(CommandBuffer buffer) { }

		public static void DrawProcedural(Material material, Bounds bounds, MeshTopology topology, int vertexCount) { }
		public static void DrawProcedural(Material material, Bounds bounds, MeshTopology topology, int vertexCount, int instanceCount) { }

		public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices) { }
		public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count) { }
		public static void DrawMeshInstanced(Mesh mesh, int submeshIndex, Material material, Matrix4x4[] matrices, int count, MaterialPropertyBlock properties) { }

		public static void BlitMultiTap(Texture source, RenderTexture dest, Material mat, params Vector2[] offsets) { }
		public static void BlitMultiTap(Texture source, RenderTexture dest, Material mat) { }

		public static void DrawProceduralIndirectNow(Material material, Bounds bounds, MeshTopology topology, ComputeBuffer bufferWithArgs) { }
		public static void DrawProceduralIndirectNow(Material material, Bounds bounds, MeshTopology topology, ComputeBuffer bufferWithArgs, int argsOffset) { }

		public static void ConvertTexture(Texture texture, RenderTexture renderTexture) { }

		public static RenderTexture activeColorBuffer => null;
		public static RenderTexture activeDepthBuffer => null;
	}
}
