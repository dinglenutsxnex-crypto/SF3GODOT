namespace UnityEngine.SceneManagement
{
	public static class SceneManager
	{
		public static void LoadScene(int index)
		{
			Debug.Log("SceneManager.LoadScene not implemented");
		}

		public static void LoadScene(string name)
		{
			Debug.Log("SceneManager.LoadScene not implemented");
		}

		public static AsyncOperation LoadSceneAsync(int index) => null;
		public static AsyncOperation LoadSceneAsync(string sceneName) => null;
		public static AsyncOperation LoadSceneAsync(int index, LoadSceneMode mode) => null;
		public static AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode mode) => null;

		public static Scene GetActiveScene()
		{
			Debug.Log("SceneManager.GetActiveScene not implemented");
			return new Scene();
		}
	}

	public enum LoadSceneMode
	{
		Single,
		Additive,
	}
}
