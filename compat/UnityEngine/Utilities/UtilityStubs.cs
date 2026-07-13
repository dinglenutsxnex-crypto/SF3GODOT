using System;

namespace UnityEngine
{
    public class TouchScreenKeyboard
    {
        public string text { get; set; }
        public bool done => false;
        public bool wasCanceled => false;
        public static bool hideInput { get; set; }
        public bool active { get; set; }
        public TouchScreenKeyboardStatus status => default;
        public static TouchScreenKeyboard Open(string text) => null;
        public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType) => null;
    }

    public enum TouchScreenKeyboardType
    {
        Default, ASCIICapable, NumbersAndPunctuation, URL, NumberPad, PhonePad, NamePhonePad, EmailAddress, NicknameKeyboard, Search,
    }

    public enum TouchScreenKeyboardStatus
    {
        Visible, Done, Canceled, Unknown,
    }

    public struct Vector2Int
    {
        public int x;
        public int y;
        public Vector2Int(int x, int y) { this.x = x; this.y = y; }
        public static Vector2Int zero => new Vector2Int(0, 0);
        public static Vector2Int one => new Vector2Int(1, 1);
    }

    public struct Vector3Int
    {
        public int x;
        public int y;
        public int z;
        public Vector3Int(int x, int y, int z) { this.x = x; this.y = y; this.z = z; }
        public static Vector3Int zero => new Vector3Int(0, 0, 0);
        public static Vector3Int one => new Vector3Int(1, 1, 1);
    }
}
