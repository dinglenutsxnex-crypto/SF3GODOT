namespace UnityEngine.SceneManagement
{
	public class Scene
	{
		public int buildIndex = 0;
		public string name = "";
		public string path = "";
		public bool isLoaded => false;
		public int rootCount => 0;
		public GameObject[] GetRootGameObjects() => new GameObject[0];
		public void GetRootGameObjects(System.Collections.Generic.List<GameObject> rootGameObjects) { }
	}
}