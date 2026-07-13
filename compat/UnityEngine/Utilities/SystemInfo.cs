using System;
using Godot;

namespace UnityEngine
{
	public static class SystemInfo
	{
		public static int processorCount => System.Environment.ProcessorCount;
		public static int processorFrequency => 0;
		public static int systemMemorySize => 0;
		public static int graphicsMemorySize => 0;
		public static int graphicsDeviceID => 0;
		public static int graphicsDeviceVendorID => 0;
		public static string graphicsDeviceName => "";
		public static string graphicsDeviceVendor => "";
		public static string graphicsDeviceVersionString => "";
		public static string graphicsDeviceVersion => "";
		public static int graphicsShaderLevel => 0;
		public static bool graphicsMultiThreaded => false;
		public static int supportedRenderTargetCount => 0;
		public static bool supportsImageEffects => true;
		public static bool supports3DTextures => true;
		public static bool supports2DArrayTextures => true;
		public static bool supports3DRenderTextures => true;
		public static bool supportsCubemapArrayTextures => true;
		public static bool supportsComputeShaders => true;
		public static bool supportsInstancing => true;
		public static bool supportsRayTracing => false;
		public static bool supports2DTextures => true;
		public static bool supportsShadows => true;
		public static string deviceModel => "";
		public static string deviceName => "";
		public static DeviceType deviceType => DeviceType.Desktop;
		public static string deviceUniqueIdentifier => "";
		public static bool supportsVibration => false;
		public static bool supportsAudio => true;
		public static bool supportsGPS => false;
		public static bool supportsBluetooth => false;
		public static string operatingSystem => "";
		public static OperatingSystemFamily operatingSystemFamily => default;
		public static string processorType => "";
		public static int supportedTextureWrapModesCount => 0;
		public static bool SupportsRenderTextureFormat(RenderTextureFormat format) => true;
		public static bool SupportsTextureFormat(TextureFormat format) => true;
		public static bool SupportsVertexAttributeFormat(VertexAttributeFormat format, int dimension) => true;
		public static bool IsFormatSupported(GraphicsFormat format, FormatUsage usage) => true;
		public static bool SupportsRenderFormat(RenderTextureFormat format) => true;
		public static RenderingDeviceType graphicsDeviceType => default;
		public static bool graphicsJobModeSupported => false;
		public static bool graphicsJobTimingSupport => false;

		public static CopyTextureSupport copyTextureSupport => default;
		public static bool SupportsCopyTexture() => false;
		public static bool SupportsRandomWriteOnRenderTexture() => false;
		public static bool SupportsGPUFence() => false;
		public static bool SupportsAsyncCompute() => false;
		public static bool SupportsAsyncGPUReadback() => false;

		public static bool SupportsTextureWrapMode(TextureWrapMode mode) => true;
	}

	public enum OperatingSystemFamily
	{
		Other,
		MacOSX,
		Windows,
		Linux,
	}

	public enum DeviceType
	{
		Unknown = 0,
		Handheld = 1,
		Desktop = 2,
		Console = 3,
	}

	public enum RenderingDeviceType
	{
		OpenGLCore = 0,
		D3D11 = 2,
		Vulkan = 21,
		D3D12 = 18,
		Metal = 16,
	}

	public enum VertexAttributeFormat
	{
		Float32,
		Float16,
		UNorm8,
		SNorm8,
		UNorm16,
		SNorm16,
		UInt8,
		SInt8,
		UInt16,
		SInt16,
		UInt32,
		SInt32,
	}

	public enum GraphicsFormat
	{
		None = 0,
		R8_SRGB = 1,
		R8G8_SRGB = 2,
		R8G8B8_SRGB = 3,
		R8G8B8A8_SRGB = 4,
		R8_UNorm = 5,
		R8G8_UNorm = 6,
		R8G8B8_UNorm = 7,
		R8G8B8A8_UNorm = 8,
		R8_SNorm = 9,
		R8G8_SNorm = 10,
		R8G8B8_SNorm = 11,
		R8G8B8A8_SNorm = 12,
		R8_UInt = 13,
		R8G8_UInt = 14,
		R8G8B8_UInt = 15,
		R8G8B8A8_UInt = 16,
		R8_SInt = 17,
		R8G8_SInt = 18,
		R8G8B8_SInt = 19,
		R8G8B8A8_SInt = 20,
		R16_UNorm = 21,
		R16G16_UNorm = 22,
		R16G16B16_UNorm = 23,
		R16G16B16A16_UNorm = 24,
		R16_SNorm = 25,
		R16G16_SNorm = 26,
		R16G16B16_SNorm = 27,
		R16G16B16A16_SNorm = 28,
		R16_UInt = 29,
		R16G16_UInt = 30,
		R16G16B16_UInt = 31,
		R16G16B16A16_UInt = 32,
		R16_SInt = 33,
		R16G16_SInt = 34,
		R16G16B16_SInt = 35,
		R16G16B16A16_SInt = 36,
		R32_UInt = 37,
		R32G32_UInt = 38,
		R32G32B32_UInt = 39,
		R32G32B32A32_UInt = 40,
		R32_SInt = 41,
		R32G32_SInt = 42,
		R32G32B32_SInt = 43,
		R32G32B32A32_SInt = 44,
		R16_SFloat = 45,
		R16G16_SFloat = 46,
		R16G16B16_SFloat = 47,
		R16G16B16A16_SFloat = 48,
		R32_SFloat = 49,
		R32G32_SFloat = 50,
		R32G32B32_SFloat = 51,
		R32G32B32A32_SFloat = 52,
		B8G8R8A8_SRGB = 56,
		B8G8R8A8_UNorm = 57,
		D16_UNorm = 90,
		D24_UNorm_S8_UInt = 91,
		D32_SFloat = 92,
		D32_SFloat_S8_UInt = 93,
		S8_UInt = 94,
		RGBA_DXT1_SRGB = 95,
		RGBA_DXT3_SRGB = 96,
		RGBA_DXT5_SRGB = 97,
		RGBA_BC7_SRGB = 98,
		RGBA_DXT1_UNorm = 99,
		RGBA_DXT3_UNorm = 100,
		RGBA_DXT5_UNorm = 101,
		RGBA_BC7_UNorm = 102,
	}

	public enum FormatUsage
	{
		Linear = 1,
		SRGB = 2,
		RenderTarget = 4,
		Sample = 8,
		Blend = 16,
		GetPixels = 32,
		SetPixels = 64,
		SetPixels32 = 128,
		GetPixels32 = 256,
		ReadRenderTexture = 512,
		WriteRenderTexture = 1024,
		RenderTargetSample = 2048,
		DepthStencil = 4096,
		Mask = 8192,
	}

	public enum CopyTextureSupport
	{
		None = 0,
		Basic = 1,
		Tex3D = 2,
		DifferentTextureTypes = 4,
		TextureToRT = 8,
		RTToTexture = 16,
	}

	public enum GraphicsJobMode
	{
		Sync,
		Async,
	}
}
