using Godot;

namespace UnityEngine
{
	public static class Debug
	{
		const string nullString = "Null";

		public static bool isDebugBuild => OS.IsDebugBuild();
		public static bool developerConsoleVisible { get; set; }

		public static void Log(object obj)
		{
			if (obj != null) GD.Print(obj.ToString());
			else GD.Print(nullString);
		}

		public static void Log(object obj, Object context)
		{
			Log(obj);
		}

		public static void LogWarning(object obj)
		{
			if (obj != null) GD.Print(obj.ToString());
			else GD.Print(nullString);
		}

		public static void LogWarning(object obj, Object context)
		{
			LogWarning(obj);
		}

		public static void LogError(object obj)
		{
			if (obj != null) GD.PrintErr(obj.ToString());
			else GD.Print(nullString);
		}

		public static void LogError(object obj, Object context)
		{
			LogError(obj);
		}

		public static void LogException(System.Exception exception)
		{
			GD.PrintErr(exception.ToString());
		}

		public static void LogException(System.Exception exception, Object context)
		{
			LogException(exception);
		}

		public static void LogFormat(string format, params object[] args)
		{
			GD.Print(string.Format(format, args));
		}

		public static void LogFormat(Object context, string format, params object[] args)
		{
			LogFormat(format, args);
		}

		public static void LogAssertion(object obj)
		{
			LogError(obj);
		}

		public static void LogAssertion(object obj, Object context)
		{
			LogError(obj);
		}

		public static void LogFatal(object obj)
		{
			LogError(obj);
		}

		public static void LogFatal(object obj, Object context)
		{
			LogError(obj);
		}

		public static void Log(string message, LogType type) { }
		public static void Log(string message, LogType type, Object context) { }

		public static void DrawLine(Vector3 start, Vector3 end) { }
		public static void DrawLine(Vector3 start, Vector3 end, Color color) { }
		public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration) { }
		public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration, bool depthTest) { }

		public static void DrawRay(Vector3 start, Vector3 dir) { }
		public static void DrawRay(Vector3 start, Vector3 dir, Color color) { }
		public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration) { }
		public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration, bool depthTest) { }

		public static void Break() { }
		public static void DebugBreak() { }
		public static void ClearDeveloperConsole() { }

		public static ILogger unityLogger => new UnityLogger();
	}

	public interface ILogger
	{
		bool logEnabled { get; set; }
		LogType filterLogType { get; set; }
		void Log(LogType logType, object message);
		void Log(object message);
		void LogWarning(object message);
		void LogError(object message);
	}

	internal class UnityLogger : ILogger
	{
		public bool logEnabled { get; set; } = true;
		public LogType filterLogType { get; set; } = LogType.Log;
		public void Log(LogType logType, object message) => GD.Print(message);
		public void Log(object message) => GD.Print(message);
		public void LogWarning(object message) => GD.Print(message);
		public void LogError(object message) => GD.PrintErr(message);
	}
}
