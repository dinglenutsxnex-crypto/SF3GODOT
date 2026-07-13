namespace UnityEngine
{
	public class AssetBundle
	{
		public string name { get; set; }
		public Object mainAsset => null;
		public bool isStreamedSceneAssetBundle => false;

		public static AssetBundleCreateRequest LoadFromFileAsync(string path) => null;
		public static AssetBundle LoadFromFile(string path) => null;
		public static AssetBundleCreateRequest LoadFromMemoryAsync(byte[] binary) => null;
		public static AssetBundleCreateRequest LoadFromStreamAsync(System.IO.Stream stream) => null;
		public static AssetBundle LoadFromFile(string path, uint crc) => null;
		public static AssetBundle LoadFromFile(string path, uint crc, ulong offset) => null;

		public AssetBundleRequest LoadAssetAsync(string name) => null;
		public AssetBundleRequest LoadAssetAsync(string name, System.Type type) => null;
		public T LoadAsset<T>(string name) where T : class => default;
		public Object LoadAsset(string name) => null;
		public Object LoadAsset(string name, System.Type type) => null;
		public Object[] LoadAllAssets() => new Object[0];
		public T[] LoadAllAssets<T>() where T : class => new T[0];
		public AssetBundleRequest LoadAllAssetsAsync() => null;
		public AssetBundleRequest LoadAllAssetsAsync(System.Type type) => null;

		public void Unload(bool unloadAllLoadedObjects) { }
		public bool Contains(string name) => false;
		public string[] GetAllAssetNames() => new string[0];
		public string[] GetAllScenePaths() => new string[0];

		public static implicit operator bool(AssetBundle exists) => exists != null;

		public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name) => null;
		public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name, System.Type type) => null;

		public Object[] LoadAssetWithSubAssets(string name) => new Object[0];
		public Object[] LoadAssetWithSubAssets(string name, System.Type type) => new Object[0];
		public T[] LoadAssetWithSubAssets<T>(string name) where T : class => new T[0];
	}

	public class AssetBundleCreateRequest : AsyncOperation
	{
		public AssetBundle assetBundle => null;
	}

	public class AssetBundleRequest : AsyncOperation
	{
		public Object asset => null;
		public Object[] allAssets => null;
		public T GetAsset<T>() where T : class => default;
		public Object GetAsset() => null;
	}

	public class AssetBundleLoadFromFile : AssetBundleRequest
	{
		public new AssetBundle assetBundle => null;
	}
}
