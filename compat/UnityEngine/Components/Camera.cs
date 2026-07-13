using System;
using UnityEngine.Rendering;

namespace UnityEngine
{
	public class Camera : Behaviour
	{
		public static Camera main => null;
		public static Camera current => null;
		public static Camera mainOrthographic => null;

		public float nearClipPlane { get; set; }
		public float farClipPlane { get; set; }
		public float fieldOfView { get; set; }
		public float orthographicSize { get; set; }
		public bool orthographic { get; set; }
		public float depth { get; set; }
		public float aspect { get; set; }
		public int cullingMask { get; set; }
		public Color backgroundColor { get; set; }
		public CameraClearFlags clearFlags { get; set; }
		public Rect rect { get; set; }
		public RenderTexture targetTexture { get; set; }
		public bool allowHDR { get; set; }
		public bool allowMSAA { get; set; }
		public int targetDisplay { get; set; }
		public int pixelWidth => 0;
		public int pixelHeight => 0;
		public DepthTextureMode depthTextureMode { get; set; }
		public float focalLength => 0f;
		public Vector3 velocity => default;
		public Matrix4x4 projectionMatrix { get; set; }
		public Matrix4x4 worldToCameraMatrix { get; set; }
		public Matrix4x4 cameraToWorldMatrix => default;
		public Rect pixelRect { get; set; }
		public RenderingPath renderingPath { get; set; }
		public bool useOcclusionCulling { get; set; }
		public bool allowDynamicResolution { get; set; }
		public float stereoConvergence => 0f;
		public float stereoSeparation => 0f;
		public bool stereoEnabled => false;
		public Eye stereoActiveEye => Eye.Left;

		public TransparencySortMode transparencySortMode { get; set; }
		public int eventMask { get; set; }
		public Camera() => throw new NotImplementedException();

		public Ray ScreenPointToRay(Vector3 pos) => default;
		public Vector3 ScreenToWorldPoint(Vector3 position) => default;
		public Vector3 WorldToScreenPoint(Vector3 position) => default;
		public Vector3 ViewportToWorldPoint(Vector3 position) => default;
		public Vector3 WorldToViewportPoint(Vector3 position) => default;
		public void Render() { }
		public void RenderWithShader(Shader shader, string replacementTag) { }
		public void ResetWorldToCameraMatrix() { }
		public void ResetProjectionMatrix() { }
		public void ResetAspect() { }
		public void ResetClearFlags() { }
		public void CopyFrom(Camera other) { }
		public bool RenderToCubemap(RenderTexture cubemap) => false;
		public bool RenderToCubemap(RenderTexture cubemap, int faceMask) => false;
		public void SetTargetBuffers(RenderBuffer colorBuffer, RenderBuffer depthBuffer) { }
		public void SetTargetBuffers(RenderBuffer[] colorBuffers, RenderBuffer depthBuffer) { }
		public Plane[] CalculateFrustumPlanes() => null;
		public void CalculateFrustumCorners(Rect viewport, float zNear, Eye eye, Vector3[] outCorners) { }
		public void SetReplacementShader(Shader shader, string replacementTag) { }
		public void ResetReplacementShader() { }
		public void AddCommandBuffer(CameraEvent evt, CommandBuffer commandBuffer) { }
		public void AddCommandBuffer(CameraEvent evt, CommandBuffer commandBuffer, int renderPass) { }
		public void RemoveCommandBuffer(CameraEvent evt, CommandBuffer commandBuffer) { }
		public void RemoveAllCommandBuffers() { }
		public Vector3 ScreenToViewportPoint(Vector3 position) => default;
		public static int allCamerasCount => 0;
		public static Camera[] allCameras => null;
		public static int GetAllCameras(Camera[] cameras) => 0;

		public Matrix4x4 GetStereoProjectionMatrix(StereoscopicEye eye) => default;
		public Matrix4x4 GetStereoViewMatrix(StereoscopicEye eye) => default;

		public float GetFocalLength() => 0f;
		public Vector3 GetStereoEyePosition(StereoscopicEye eye) => default;

		public enum StereoscopicEye
		{
			Left = 0,
			Right = 1,
		}
	}

	public enum CameraClearFlags
	{
		Skybox = 1,
		Color = 2,
		SolidColor = 2,
		Depth = 3,
		Nothing = 4,
	}

	public enum RenderingPath
	{
		UsePlayerSettings = -1,
		VertexLit = 0,
		Forward = 1,
		DeferredLighting = 2,
		DeferredShading = 3,
	}

	public enum DepthTextureMode
	{
		None = 0,
		Depth = 1,
		DepthNormals = 2,
		MotionVectors = 4,
	}

	public enum Eye
	{
		Left = 0,
		Right = 1,
	}

	public enum StereoTargetEyeMask
	{
		None = 0,
		Left = 1,
		Right = 2,
		Both = 3,
	}
}
