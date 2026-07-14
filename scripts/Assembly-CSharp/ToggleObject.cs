using UnityEngine;

public partial class ToggleObject : MonoBehaviour
{
	private void Start()
	{
		base.gameObject.SetActive(false);
		base.gameObject.SetActive(true);
	}
}
