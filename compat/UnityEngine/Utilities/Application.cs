using Godot;
using System;

namespace UnityEngine
{
	public static class Application
	{
		public static Action<string, string, LogType> logMessageReceived;
		public static Action<string, string, LogType, string> logMessageReceivedThreaded;

		public static int targetFrameRate { get; set; }
		public static string dataPath => "";
		public static string persistentDataPath => "";
		public static string streamingAssetsPath => "";
		public static string temporaryCachePath => "";
		public static string absoluteURL => "";
		public static string unityVersion => "2021.3.0";
		public static string version => "1.0.0";
		public static string installerName => "";
		public static int installerVersion => 0;
		public static string identifier => "";
		public static string buildGUID => "";

		public static RuntimePlatform platform { get; }
		public static bool isEditor { get; }
		public static bool isPlaying => true;
		public static bool isFocused => true;
		public static bool isBatchMode => false;
		public static bool isConsolePlatform => false;
		public static bool isMobilePlatform => false;

		public static void OpenURL(string url) { }
		public static void Quit() { }
		public static void Quit(int exitCode) { }
		public static bool CanStreamedLevelBeLoaded(string levelName) => false;
		public static bool CanStreamedLevelBeLoaded(int levelIndex) => false;
		public static bool RequestUserAuthorization(UserAuthorization mode) => false;
		public static bool HasUserAuthorization(UserAuthorization mode) => false;

		public static void ExternalCall(string functionName, params object[] args) { }
		public static void RegisterLogCallback(LogCallback handler) { }
		public static void RegisterLogCallbackThreaded(LogCallback handler) { }
		public static void UnregisterLogCallback(LogCallback handler) { }

		public static bool internetReachability => false;
		public static NetworkReachability userAppHasConsentedToNetworking => default;

		public static bool runInBackground { get; set; }
		public static bool isWebGLPlayer => false;
		public static bool isSwitchPlatform => false;
		public static SystemLanguage systemLanguage => SystemLanguage.English;
	}


	public enum RuntimePlatform
	{
		OSXEditor,
		OSXPlayer,
		WindowsPlayer,
		WindowsEditor = 7,
		IPhonePlayer,
		Android = 11,
		LinuxPlayer = 13,
		LinuxEditor = 16,
		WebGLPlayer,
		WSAPlayerX86 = 18,
		MetroPlayerX86 = 18,
		WSAPlayerX64 = 19,
		MetroPlayerX64 = 19,
		WSAPlayerARM = 20,
		MetroPlayerARM = 20,
		TizenPlayer,
		PSP2,
		PS4,
		PSM,
		XboxOne,
		SamsungTVPlayer,
		WiiU = 30,
		tvOS,
		Switch,
		WP8Player = -1,
		BlackBerryPlayer = -1,
	}

	public delegate void LogCallback(string condition, string stackTrace, LogType type);

	public enum UserAuthorization
	{
		WebCam = 1,
		Microphone = 2,
	}

	public enum NetworkReachability
	{
		NotReachable = 0,
		ReachableViaCarrierDataNetwork = 1,
		ReachableViaLocalAreaNetwork = 2,
	}
}