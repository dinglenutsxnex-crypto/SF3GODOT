using Godot;

namespace UnityEngine
{
	public static class Time
	{
		public static float time { get; internal set; }
		public static float realtimeSinceStartup => (float)(System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000.0);
		public static float timeScale { get => Engine.GetTimeScale(); set => Engine.SetTimeScale(value); }
		public static int frameCount => Engine.GetFramesDrawn();
		public static float deltaTime = 0.0f;
		public static float fixedDeltaTime = 0.0f;
		public static float unscaledTime { get; set; }
		public static float unscaledDeltaTime { get; set; }
		public static float smoothDeltaTime { get; set; }
		public static float fixedUnscaledTime { get; set; }
		public static float fixedUnscaledDeltaTime { get; set; }
		public static float maximumDeltaTime { get; set; }
		public static float maximumParticleDeltaTime { get; set; }
		public static float timeSinceLevelLoad { get; set; }
		public static float realtimeSinceStartupAsDouble => realtimeSinceStartup;
		public static double timeAsDouble { get; set; }
		public static double unscaledTimeAsDouble { get; set; }
		public static double fixedUnscaledTimeAsDouble { get; set; }
		public static double timeSinceLevelLoadAsDouble { get; set; }
		public static float captureFramerate { get; set; }
		public static bool inFixedTimeStep => false;
	}
}
