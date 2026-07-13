using System;
namespace UnityEngine
{
	public static class Screen
	{
		public static int width;
		public static int height;
		public static float dpi => 0f;
		public static bool fullScreen { get; set; }
		public static bool fullScreenMode { get; set; }
		public static Resolution currentResolution => default;
		public static Resolution[] resolutions => new Resolution[0];
		public static Resolution[] supportedResolutions => new Resolution[0];
		public static ScreenOrientation autorotateToLandscapeLeft { get; set; }
		public static ScreenOrientation autorotateToLandscapeRight { get; set; }
		public static ScreenOrientation autorotateToPortrait { get; set; }
		public static ScreenOrientation autorotateToPortraitUpsideDown { get; set; }
		public static ScreenOrientation orientation { get; set; }
		public static int sleepTimeout { get; set; }
		public static float brightness { get; set; }
		public static Rect safeArea => Rect.zero;
		public static int brightnessInt { get; set; }
		public static ScreenOrientation screenOrientation { get; set; }

		public static void SetResolution(int width, int height, bool fullScreen) { }
		public static void SetResolution(int width, int height, FullScreenMode fullscreenMode) { }
		public static void SetResolution(int width, int height, FullScreenMode fullscreenMode, RefreshRate preferredRefreshRate) { }
		public static bool IsResolutionSupported(int width, int height, bool fullscreen) => false;
	}

	public enum ScreenOrientation
	{
		Unknown = 0,
		Portrait = 1,
		PortraitUpsideDown = 2,
		LandscapeLeft = 3,
		LandscapeRight = 4,
		AutoRotation = 5,
	}

	public enum FullScreenMode
	{
		ExclusiveFullScreen = 0,
		FullScreenWindow = 1,
		MaximizedWindow = 2,
		Windowed = 3,
	}

	public struct RefreshRate
	{
		public uint numerator;
		public uint denominator;
	}
}
