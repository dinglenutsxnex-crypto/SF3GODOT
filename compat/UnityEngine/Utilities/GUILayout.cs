using System;

namespace UnityEngine
{
	public static class GUILayout
	{
		public static void BeginHorizontal(params GUILayoutOption[] options) { }
		public static void BeginHorizontal(GUIStyle style, params GUILayoutOption[] options) { }
		public static void BeginHorizontal(string text, GUIStyle style, params GUILayoutOption[] options) { }
		public static void BeginHorizontal(Texture image, GUIStyle style, params GUILayoutOption[] options) { }
		public static void EndHorizontal() { }

		public static void BeginVertical(params GUILayoutOption[] options) { }
		public static void BeginVertical(GUIStyle style, params GUILayoutOption[] options) { }
		public static void BeginVertical(string text, GUIStyle style, params GUILayoutOption[] options) { }
		public static void BeginVertical(Texture image, GUIStyle style, params GUILayoutOption[] options) { }
		public static void EndVertical() { }

		public static void BeginArea(Rect screenRect) { }
		public static void BeginArea(Rect screenRect, string text) { }
		public static void BeginArea(Rect screenRect, GUIStyle style) { }
		public static void BeginArea(Rect screenRect, string text, GUIStyle style) { }
		public static void BeginArea(Rect screenRect, Texture image) { }
		public static void BeginArea(Rect screenRect, Texture image, GUIStyle style) { }
		public static void EndArea() { }

		public static void BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options) { }
		public static void BeginScrollView(Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options) { }
		public static void BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options) { }
		public static Vector2 EndScrollView() => default;
		public static Vector2 EndScrollView(bool handleScrollWheel) => default;

		public static bool Button(string text, params GUILayoutOption[] options) => false;
		public static bool Button(string text, GUIStyle style, params GUILayoutOption[] options) => false;
		public static bool Button(Texture image, params GUILayoutOption[] options) => false;
		public static bool Button(Texture image, GUIStyle style, params GUILayoutOption[] options) => false;

		public static bool RepeatButton(string text, params GUILayoutOption[] options) => false;
		public static bool RepeatButton(string text, GUIStyle style, params GUILayoutOption[] options) => false;

		public static string TextField(string text, params GUILayoutOption[] options) => text;
		public static string TextField(string text, int maxLength, params GUILayoutOption[] options) => text;
		public static string TextField(string text, GUIStyle style, params GUILayoutOption[] options) => text;
		public static string TextField(string text, int maxLength, GUIStyle style, params GUILayoutOption[] options) => text;

		public static string TextArea(string text, params GUILayoutOption[] options) => text;
		public static string TextArea(string text, int maxLength, params GUILayoutOption[] options) => text;
		public static string TextArea(string text, GUIStyle style, params GUILayoutOption[] options) => text;

		public static bool Toggle(bool value, string text, params GUILayoutOption[] options) => value;
		public static bool Toggle(bool value, string text, GUIStyle style, params GUILayoutOption[] options) => value;

		public static float HorizontalSlider(float value, float leftValue, float rightValue, params GUILayoutOption[] options) => value;
		public static float HorizontalSlider(float value, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, params GUILayoutOption[] options) => value;

		public static float VerticalSlider(float value, float topValue, float bottomValue, params GUILayoutOption[] options) => value;
		public static float VerticalSlider(float value, float topValue, float bottomValue, GUIStyle slider, GUIStyle thumb, params GUILayoutOption[] options) => value;

		public static float HorizontalScrollbar(float value, float size, float leftValue, float rightValue, params GUILayoutOption[] options) => value;
		public static float HorizontalScrollbar(float value, float size, float leftValue, float rightValue, GUIStyle style, params GUILayoutOption[] options) => value;

		public static float VerticalScrollbar(float value, float size, float topValue, float bottomValue, params GUILayoutOption[] options) => value;
		public static float VerticalScrollbar(float value, float size, float topValue, float bottomValue, GUIStyle style, params GUILayoutOption[] options) => value;

		public static void Space(float pixels) { }
		public static void FlexibleSpace() { }

		public static void Label(string text, params GUILayoutOption[] options) { }
		public static void Label(string text, GUIStyle style, params GUILayoutOption[] options) { }
		public static void Label(Texture image, params GUILayoutOption[] options) { }
		public static void Label(Texture image, GUIStyle style, params GUILayoutOption[] options) { }
		public static void Label(GUIContent content, params GUILayoutOption[] options) { }
		public static void Label(GUIContent content, GUIStyle style, params GUILayoutOption[] options) { }

		public static void Box(string text, params GUILayoutOption[] options) { }
		public static void Box(string text, GUIStyle style, params GUILayoutOption[] options) { }
		public static void Box(Texture image, params GUILayoutOption[] options) { }
		public static void Box(Texture image, GUIStyle style, params GUILayoutOption[] options) { }
		public static void Box(GUIContent content, params GUILayoutOption[] options) { }
		public static void Box(GUIContent content, GUIStyle style, params GUILayoutOption[] options) { }

		public static GUILayoutOption Width(float width) => null;
		public static GUILayoutOption Height(float height) => null;
		public static GUILayoutOption MinWidth(float minWidth) => null;
		public static GUILayoutOption MaxWidth(float maxWidth) => null;
		public static GUILayoutOption MinHeight(float minHeight) => null;
		public static GUILayoutOption MaxHeight(float maxHeight) => null;
		public static GUILayoutOption ExpandWidth(bool expand) => null;
		public static GUILayoutOption ExpandHeight(bool expand) => null;

		public static bool Window(int id, Rect screenRect, WindowFunction func, string text, params GUILayoutOption[] options) => false;
		public static bool Window(int id, Rect screenRect, WindowFunction func, Texture image, params GUILayoutOption[] options) => false;
		public static bool Window(int id, Rect screenRect, WindowFunction func, GUIContent content, params GUILayoutOption[] options) => false;

		public static Rect Window(int id, Rect screenRect, WindowFunction func, string text, GUIStyle style, params GUILayoutOption[] options) => default;

		public delegate void WindowFunction(int id);
	}

	public class GUILayoutOption
	{
	}

	public static class GUILayoutUtility
	{
		public static Rect GetLastRect() => default;
		public static Rect GetRect(float width, float height) => default;
		public static Rect GetRect(float minWidth, float maxWidth, float minHeight, float maxHeight) => default;
	}

	public static class GUIUtility
	{
		public static int hotControl { get; set; }
		public static int keyboardControl { get; set; }
		public static Vector2 screenToGUIPoint(Vector2 screenPoint) => default;
		public static Vector2 guiToScreenPoint(Vector2 guiPoint) => default;
		public static Rect screenToGUIRect(Rect screenRect) => default;
		public static void ExitGUI() { }
		public static int GetControlID(FocusType focus) => 0;
		public static int GetControlID(int hint, FocusType focusType) => 0;
		public static object GetStateObject(Type t, int controlID) => null;
		public static void SwitchOnEsc() { }
	}

	public enum FocusType
	{
		Native,
		Keyboard,
		ForceKeyboard,
	}
}
