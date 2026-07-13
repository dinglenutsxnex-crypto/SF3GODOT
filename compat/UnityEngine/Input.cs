using System;
using Godot;

namespace UnityEngine
{
	public static class Input
	{
		public static Vector3 mousePosition { get; set; }
		public static bool mousePresent => true;
		public static int touchCount => 0;
		public static bool anyKey { get; set; }
		public static bool anyKeyDown { get; set; }
		public static string inputString => "";
		public static string compositionString => "";
		public static Vector2 compositionCursorPos { get; set; }
		public static bool imeIsSelected => false;
		public static IMECompositionMode imeCompositionMode { get; set; }
		public static string[] joystickNames => new string[0];
		public static float mouseScrollDelta => 0f;
		public static Touch[] touches => new Touch[0];

		public static bool GetKey(KeyCode key) => false;
		public static bool GetKeyUp(KeyCode key) => false;
		public static bool GetKeyDown(KeyCode key) => false;
		public static bool GetKey(string name) => false;
		public static bool GetKeyUp(string name) => false;
		public static bool GetKeyDown(string name) => false;

		public static bool GetMouseButton(int button) => false;
		public static bool GetMouseButtonDown(int button) => false;
		public static bool GetMouseButtonUp(int button) => false;

		public static bool GetButton(string buttonName) => false;
		public static bool GetButtonDown(string buttonName) => false;
		public static bool GetButtonUp(string buttonName) => false;

		public static float GetAxis(string axisName) => 0f;
		public static float GetAxisRaw(string axisName) => 0f;

		public static Touch GetTouch(int index) => default;
		public static string[] GetJoystickNames() => new string[0];

		public static void ResetInputAxes() { }

		public static bool simulateMouseWithTouches { get; set; }
		public static bool multiTouchEnabled { get; set; }
		public static bool stylusTouchSupported => false;
		public static bool touchPressureSupported => false;
		public static bool compensateSensors { get; set; }
		public static float gravity => 0f;
		public static Vector3 acceleration => default;
		public static int accelerationEventCount => 0;
		public static bool backButtonLeavesApp { get; set; }

		public static Gyroscope gyro => null;
	}

	public class Gyroscope
	{
		public bool enabled { get; set; }
		public Vector3 rotationRate => default;
		public Vector3 rotationRateUnbiased => default;
		public Vector3 userAcceleration => default;
		public Quaternion attitude => default;
	}

	public struct Touch
	{
		public int fingerId;
		public Vector2 position;
		public Vector2 rawPosition;
		public Vector2 deltaPosition;
		public float deltaTime;
		public int tapCount;
		public TouchPhase phase;
		public float pressure;
		public float maximumPossiblePressure;
		public TouchType type;
		public float altitudeAngle;
		public float azimuthAngle;
		public float radius;
		public float radiusVariance;
	}

	public enum TouchPhase
	{
		Began = 0,
		Moved = 1,
		Stationary = 2,
		Ended = 3,
		Canceled = 4,
	}

	public enum TouchType
	{
		Direct,
		Indirect,
		Stylus,
	}

	public enum IMECompositionMode
	{
		Auto,
		On,
		Off,
	}
}
