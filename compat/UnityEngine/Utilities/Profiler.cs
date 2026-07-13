namespace UnityEngine.Profiling
{
	public static class Profiler
	{
		public static void BeginSample(string label) { }
		public static void BeginSample(string label, Object targetObject) { }
		public static void EndSample() { }

		public static long GetTotalAllocatedMemoryLong() => 0;
		public static long GetTotalReservedMemoryLong() => 0;
		public static long GetTotalUnusedReservedMemoryLong() => 0;
		public static long GetMonoUsedSizeLong() => 0;
		public static long GetMonoHeapSizeLong() => 0;
		public static long GetTempAllocatorSize() => 0;

		public static int GetTotalAllocatedMemory() => 0;
		public static int GetTotalReservedMemory() => 0;
		public static int GetMonoUsedSize() => 0;
		public static int GetMonoHeapSize() => 0;

		public static int GetAllocatedMemoryForGraphicsDriver() => 0;
		public static void GetStats(SerializedProperty stats) { }
	}
}

namespace UnityEngine
{
    public class SerializedProperty
    {
    }
}
