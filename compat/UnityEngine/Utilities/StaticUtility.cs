using System;

namespace UnityEngine
{
    public static class PlayerPrefs
    {
        public static void SetInt(string key, int value) { }
        public static int GetInt(string key) => 0;
        public static int GetInt(string key, int defaultValue) => defaultValue;
        public static void SetFloat(string key, float value) { }
        public static float GetFloat(string key) => 0f;
        public static float GetFloat(string key, float defaultValue) => defaultValue;
        public static void SetString(string key, string value) { }
        public static string GetString(string key) => "";
        public static string GetString(string key, string defaultValue) => defaultValue;
        public static bool HasKey(string key) => false;
        public static void DeleteKey(string key) { }
        public static void DeleteAll() { }
        public static void Save() { }
    }

    public static class ColorUtility
    {
        public static bool TryParseHtmlString(string htmlString, out Color color) { color = default; return false; }
        public static string ToHtmlStringRGB(Color color) => "";
        public static string ToHtmlStringRGBA(Color color) => "";
    }

    public static class JsonUtility
    {
        public static string ToJson(object obj) => "";
        public static string ToJson(object obj, bool prettyPrint) => "";
        public static T FromJson<T>(string json) => default;
        public static void FromJsonOverwrite(string json, object objectToOverwrite) { }
    }
}
