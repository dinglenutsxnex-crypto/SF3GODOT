namespace UnityEngine
{
	public static class Resources
	{
		public static AsyncOperation UnloadUnusedAssets()
		{
			AsyncOperation asyncOp = new AsyncOperation();
			Debug.Log("Resources.UnloadUnusedAssets not implemented");
			asyncOp.isDone = true;
			return asyncOp;
		}

		public static T Load<T>(string path) where T : class => default;
		public static Object Load(string path) => null;
		public static Object Load(string path, System.Type systemTypeInstance) => null;
		public static T[] LoadAll<T>(string path) where T : class => new T[0];
		public static Object[] LoadAll(string path) => new Object[0];
		public static Object[] LoadAll(string path, System.Type systemTypeInstance) => new Object[0];
		public static void UnloadAsset(Object assetToUnload) { }
		public static T[] FindObjectsOfTypeAll<T>() where T : Object => new T[0];
public static Object[] FindObjectsOfTypeAll(System.Type type) => new Object[0];
	}
}
