using UnityEngine;

public partial class TestFightGUI : MonoBehaviour
{
	public HUD userHUD;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void AddHealth(string value)
	{
		float result;
		float.TryParse(value, out result);
		if ((object)userHUD == null)
		{
		}
	}
}
