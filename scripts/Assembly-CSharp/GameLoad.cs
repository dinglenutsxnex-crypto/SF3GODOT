using SF3;
using UnityEngine;

[UnityEngine.UseAsMonoBehaviour]
public partial class GameLoad : MonoBehaviour
{
	private EnterPoint _enterPoint;

	public GameObject NekkiLogo;

	protected virtual void Awake()
	{
		if (NekkiLogo != null)
			NekkiLogo.SetActive(true);
	}

	protected virtual void Start()
	{
		Sf3ConsoleCommands.AddCommands();
		_enterPoint = new EnterPoint();
		_enterPoint.Init();
	}

	protected virtual void OnDestroy()
	{
		if (NekkiLogo != null)
		{
			Debug.Log("Destroy GameLoad " + NekkiLogo.GetInstanceID());
			GlobalLoad.Unload(NekkiLogo);
		}
	}
}
