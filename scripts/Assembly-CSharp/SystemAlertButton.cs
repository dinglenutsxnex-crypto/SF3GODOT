using UnityEngine;

public partial class SystemAlertButton : MonoBehaviour
{
	[SerializeField]
	private LocalizationText label;

	public void SetLabel(string alias)
	{
		label.SetAlias(alias);
	}
}
