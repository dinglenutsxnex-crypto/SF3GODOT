using System;

namespace UnityEngine
{
    public static class RectTransformUtility
    {
        public static Vector2 WorldToScreenPoint(RectTransform rect, Vector3 worldPoint) => default;
        public static bool ScreenPointToLocalPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam, out Vector2 localPoint) { localPoint = default; return false; }
        public static Vector3 ScreenPointToWorldPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam) => default;
        public static void FlipLayoutOnAxis(RectTransform rect, int axis, bool keepPositioning, bool recursive) { }
        public static void FlipLayoutAxes(RectTransform rect, bool keepPositioning, bool recursive) { }
        public static Bounds CalculateRelativeRectTransformBounds(Transform root, Transform child) => default;
        public static Bounds CalculateRelativeRectTransformBounds(params Transform[] transforms) => default;
    }

    public static class LayoutUtility
    {
        public static float GetMinWidth(RectTransform rect) => 0f;
        public static float GetPreferredWidth(RectTransform rect) => 0f;
        public static float GetFlexibleWidth(RectTransform rect) => 0f;
        public static float GetMinHeight(RectTransform rect) => 0f;
        public static float GetPreferredHeight(RectTransform rect) => 0f;
        public static float GetFlexibleHeight(RectTransform rect) => 0f;
        public static float GetPreferredSize(RectTransform rect, int axis) => 0f;
    }

    public static class AndroidJNI
    {
        public static IntPtr NewString(string str) => IntPtr.Zero;
        public static string GetStringChars(IntPtr str) => "";
        public static void DeleteLocalRef(IntPtr localRef) { }
        public static IntPtr GetMethodID(IntPtr clazz, string name, string sig) => IntPtr.Zero;
        public static IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig) => IntPtr.Zero;
        public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, params jvalue[] args) => IntPtr.Zero;
        public static void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, params jvalue[] args) { }
        public static jvalue[] CreateArgArray(params object[] args) => null;
        public static bool ExceptionOccurred() => false;
        public static void ExceptionDescribe() { }
        public static void ExceptionClear() { }
    }

    public struct jvalue
    {
        public bool z;
        public byte b;
        public char c;
        public short s;
        public int i;
        public long j;
        public float f;
        public double d;
        public IntPtr l;
    }

    public enum ReflectionPermissionFlag
    {
        ReflectedObjects = 1,
        ReflectionProbe = 2,
    }

    public class ImageWrapper
    {
        public RectTransform rectTransform => null;
    }

    public class TextWrapper
    {
        public RectTransform rectTransform => null;
    }
}
