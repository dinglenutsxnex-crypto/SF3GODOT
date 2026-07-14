using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Drag and Drop Container")]
public partial class UIDragDropContainer : MonoBehaviour
{
	public Transform reparentTarget;

	protected virtual void Start()
	{
		if (reparentTarget == null)
		{
			reparentTarget = base.transform;
		}
	}
}
