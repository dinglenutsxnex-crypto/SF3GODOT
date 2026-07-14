using UnityEngine;
using UnityEngine.SceneManagement;

public partial class ScreenLoader : MonoBehaviour
{
	private void Start()
	{
		SceneManager.LoadSceneAsync("loadScreen");
	}
}
