using System;

namespace UnityEngine
{
	public static class GUI
	{
		public static GUISkin skin;
		public static int depth;
		public static Color color;
		public static Color backgroundColor { get; set; }
		public static Color contentColor { get; set; }
		public static bool enabled { get; set; } = true;
		public static Matrix4x4 matrix { get; set; } = Matrix4x4.identity;
		public static string tooltip { get; set; }
		public static int changed { get; set; }

		public static void Label(Rect position, string text) { }
		public static void Label(Rect position, string text, GUIStyle style) { }
		public static void Label(Rect position, GUIContent content) { }
		public static void Label(Rect position, GUIContent content, GUIStyle style) { }
		public static void Label(Rect position, Texture image) { }
		public static void Label(Rect position, Texture image, GUIStyle style) { }

		public static void Box(Rect position, string text) { }
		public static void Box(Rect position, string text, GUIStyle style) { }
		public static void Box(Rect position, GUIContent content) { }
		public static void Box(Rect position, GUIContent content, GUIStyle style) { }
		public static void Box(Rect position, Texture image) { }

		public static bool Button(Rect rect, string text) => false;
		public static bool Button(Rect rect, string text, GUIStyle style) => false;
		public static bool Button(Rect rect, GUIContent content, GUIStyle style) => false;
		public static bool Button(Rect rect, Texture image) => false;
		public static bool Button(Rect rect, Texture image, GUIStyle style) => false;

		public static bool Toggle(Rect rect, bool value, string content) => value;
		public static bool Toggle(Rect rect, bool value, string content, GUIStyle style) => value;
		public static bool Toggle(Rect rect, bool value, GUIContent content, GUIStyle style) => value;

		public static float HorizontalSlider(Rect rect, float value, float leftValue, float rightValue) => value;
		public static float HorizontalSlider(Rect rect, float value, float leftValue, float rightValue, GUIStyle style) => value;
		public static float VerticalSlider(Rect rect, float value, float topValue, float bottomValue) => value;
		public static float VerticalSlider(Rect rect, float value, float topValue, float bottomValue, GUIStyle style) => value;

		public static float HorizontalScrollbar(Rect rect, float value, float size, float topValue, float bottomValue) => value;
		public static float HorizontalScrollbar(Rect rect, float value, float size, float topValue, float bottomValue, GUIStyle style) => value;
		public static float VerticalScrollbar(Rect rect, float value, float size, float topValue, float bottomValue) => value;
		public static float VerticalScrollbar(Rect rect, float value, float size, float topValue, float bottomValue, GUIStyle style) => value;

		public static void BeginGroup(Rect rect) { }
		public static void BeginGroup(Rect rect, string text) { }
		public static void BeginGroup(Rect rect, GUIStyle style) { }
		public static void BeginGroup(Rect rect, Texture image) { }
		public static void BeginGroup(Rect rect, string text, GUIStyle style) { }
		public static void EndGroup() { }

		public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect) => scrollPosition;
		public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, GUIStyle style) => scrollPosition;
		public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical) => scrollPosition;
		public static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle style) => scrollPosition;
		public static void EndScrollView() { }
		public static void EndScrollView(bool handleScrollWheel) { }

		public static string TextField(Rect position, string text) => text;
		public static string TextField(Rect position, string text, GUIStyle style) => text;
		public static string TextField(Rect position, string text, int maxLength) => text;
		public static string TextArea(Rect position, string text) => text;
		public static string TextArea(Rect position, string text, GUIStyle style) => text;

		public static string PasswordField(Rect position, string password, char maskChar) => password;
		public static string PasswordField(Rect position, string password, char maskChar, int maxLength) => password;

		public static Rect Window(int id, Rect clientRect, WindowFunction func, string text) => clientRect;
		public static Rect Window(int id, Rect clientRect, WindowFunction func, string text, GUIStyle style) => clientRect;

		public static void DragWindow() { }
		public static void DragWindow(Rect position) { }

		public delegate void WindowFunction(int id);

		public static void DrawTexture(Rect position, Texture image) { }
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode) { }
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend) { }
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect) { }
		public static void DrawTextureWithTexCoords(Rect position, Texture image, Rect texCoords) { }
		public static void DrawTextureWithTexCoords(Rect position, Texture image, Rect texCoords, bool alphaBlend) { }
	}
}