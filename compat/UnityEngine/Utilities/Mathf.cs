using System;

namespace UnityEngine
{
    public struct Mathf
    {
        public const float PI = 3.14159274f;
        public const float Infinity = float.PositiveInfinity;
        public const float NegativeInfinity = float.NegativeInfinity;
        public const float Deg2Rad = 0.0174532924f;
        public const float Rad2Deg = 57.29578f;
        public const float Epsilon = 1.401298E-45f;

        public static float Abs(float f) => Math.Abs(f);
        public static int Abs(int value) => Math.Abs(value);
        public static float Acos(float f) => (float)Math.Acos(f);
        public static bool Approximately(float a, float b) => Math.Abs(b - a) < Math.Max(1E-06f * Math.Max(Math.Abs(a), Math.Abs(b)), Epsilon * 8f);
        public static float Asin(float f) => (float)Math.Asin(f);
        public static float Atan(float f) => (float)Math.Atan(f);
        public static float Atan2(float y, float x) => (float)Math.Atan2(y, x);
        public static float Ceil(float f) => (float)Math.Ceiling(f);
        public static int CeilToInt(float f) => (int)Math.Ceiling(f);
        public static float Clamp(float value, float min, float max) => value < min ? min : value > max ? max : value;
        public static int Clamp(int value, int min, int max) => value < min ? min : value > max ? max : value;
        public static float Clamp01(float value) => value < 0f ? 0f : value > 1f ? 1f : value;
        public static float Cos(float f) => (float)Math.Cos(f);
        public static float DeltaAngle(float current, float target)
        {
            float num = MathHelper.Repeat(target - current, 360f);
            if (num > 180f) num -= 360f;
            return num;
        }
        public static float Exp(float power) => (float)Math.Exp(power);
        public static float Floor(float f) => (float)Math.Floor(f);
        public static int FloorToInt(float f) => (int)Math.Floor(f);
        public static float GammaToLinearSpace(float value)
        {
            if (value <= 0.04045f) return value / 12.92f;
            return (float)Math.Pow((value + 0.055f) / 1.055f, 2.4);
        }
        public static float Lerp(float a, float b, float t) => a + (b - a) * Clamp01(t);
        public static float LerpAngle(float a, float b, float t)
        {
            float num = Repeat(b - a, 360f);
            if (num > 180f) num -= 360f;
            return a + num * Clamp01(t);
        }
        public static float LerpUnclamped(float a, float b, float t) => a + (b - a) * t;
        public static float LinearToGammaSpace(float value)
        {
            if (value <= 0.0031308f) return value * 12.92f;
            return 1.055f * (float)Math.Pow(value, 1f / 2.4f) - 0.055f;
        }
        public static float Log(float f) => (float)Math.Log(f);
        public static float Log(float f, float p) => (float)Math.Log(f, p);
        public static float Max(float a, float b) => a > b ? a : b;
        public static float Max(params float[] values)
        {
            float num = float.NegativeInfinity;
            for (int i = 0; i < values.Length; i++) if (values[i] > num) num = values[i];
            return num;
        }
        public static int Max(int a, int b) => a > b ? a : b;
        public static int Max(params int[] values)
        {
            int num = int.MinValue;
            for (int i = 0; i < values.Length; i++) if (values[i] > num) num = values[i];
            return num;
        }
        public static float Min(float a, float b) => a < b ? a : b;
        public static float Min(params float[] values)
        {
            float num = float.PositiveInfinity;
            for (int i = 0; i < values.Length; i++) if (values[i] < num) num = values[i];
            return num;
        }
        public static int Min(int a, int b) => a < b ? a : b;
        public static int Min(params int[] values)
        {
            int num = int.MaxValue;
            for (int i = 0; i < values.Length; i++) if (values[i] < num) num = values[i];
            return num;
        }
        public static float MoveTowards(float current, float target, float maxDelta)
        {
            if (Math.Abs(target - current) <= maxDelta) return target;
            return current + Math.Sign(target - current) * maxDelta;
        }
        public static float MoveTowardsAngle(float current, float target, float maxDelta)
        {
            float num = DeltaAngle(current, target);
            if (-maxDelta < num && num < maxDelta) return target;
            return MoveTowards(current, current + num, maxDelta);
        }
        public static float Pow(float f, float p) => (float)Math.Pow(f, p);
        public static float Repeat(float t, float length) => t - (float)Math.Floor(t / length) * length;
        public static float Round(float f) => (float)Math.Round(f);
        public static int RoundToInt(float f) => (int)Math.Round(f);
        public static float Sign(float f) => f >= 0f ? 1f : -1f;
        public static float Sin(float f) => (float)Math.Sin(f);
        public static float SmoothStep(float from, float to, float t)
        {
            t = Clamp01(t);
            t = -2f * t * t * t + 3f * t * t;
            return to * t + from * (1f - t);
        }
        public static float Sqrt(float f) => (float)Math.Sqrt(f);
        public static float Tan(float f) => (float)Math.Tan(f);
        public static float InverseLerp(float a, float b, float value)
        {
            if (a == b) return 0f;
            return Clamp01((value - a) / (b - a));
        }
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
        {
            smoothTime = Math.Max(0.0001f, smoothTime);
            float num = 2f / smoothTime;
            float num2 = num * deltaTime;
            float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
            float num4 = current - target;
            float num5 = target;
            float max = maxSpeed * smoothTime;
            float num6 = Clamp(num4, -max, max);
            target = current - num6;
            float num7 = (currentVelocity + num * num4) * deltaTime;
            currentVelocity = (currentVelocity - num * num7) * num3;
            float num8 = target + (num6 + num7) * num3;
            if (num5 - current > 0f == num8 > num5) { num8 = num5; currentVelocity = (num8 - num5) / deltaTime; }
            return num8;
        }
        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
        {
            target = current + DeltaAngle(current, target);
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }
        public static bool IsPowerOfTwo(int value) => value != 0 && (value & (value - 1)) == 0;
        public static int ClosestPowerOfTwo(int value) { int v = value; v--; v |= v >> 1; v |= v >> 2; v |= v >> 4; v |= v >> 8; v |= v >> 16; v++; return v; }
        public static int NextPowerOfTwo(int value) { if (value <= 0) return 1; value--; value |= value >> 1; value |= value >> 2; value |= value >> 4; value |= value >> 8; value |= value >> 16; value++; return value; }
        public static float PingPong(float t, float length) => length - Math.Abs(t % (2f * length) - length);
        public static float PerlinNoise(float x, float y) => 0f;
        public static ushort FloatToHalf(float val) => 0;
        public static float HalfToFloat(ushort val) => 0f;
    }

    internal static class MathHelper
    {
        public static float Repeat(float t, float length) => t - (float)Math.Floor(t / length) * length;
    }
}
