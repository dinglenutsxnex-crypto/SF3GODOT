using System;

namespace UnityEngine
{
	public class Transform : Object, System.Collections.IEnumerable
	{
		public Godot.Node3D node;
		public Transform transform => this;

		public string name { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
		public GameObject gameObject { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

		public Vector3 localPosition { get; set; }
		public Vector3 localScale { get; set; }
		public Vector3 eulerAngles { get; set; }
		public Quaternion localRotation { get; set; }
		public Vector3 localEulerAngles { get; set; }
		public Matrix4x4 localToWorldMatrix => default;
		public Matrix4x4 worldToLocalMatrix => default;
		public int childCount => 0;
		public Transform parent { get; set; }
		public Transform root => null;
		public bool hasChanged { get; set; }
		public int hierarchyCapacity { get; set; }
		public string tag { get; set; }

		internal Transform(Godot.Node3D node)
		{
			this.node = node;
		}

		public Transform() { }

		public Vector3 position
		{
			get { return node.Position; }
			set { node.Position = value; }
		}

		public Quaternion rotation
		{
			get => Quaternion.Identity;
			set { }
		}

		public Vector3 lossyScale => Vector3.One;
		public Vector3 forward { get; set; }
		public Vector3 right { get; set; }
		public Vector3 up { get; set; }

		public Vector3 localPosition2D
		{
			get => Vector3.Zero;
			set { }
		}

		public void Rotate(Vector3 eulerAngles)
		{
			node.Rotate(eulerAngles.normalized, eulerAngles.magnitude * Mathf.Deg2Rad);
		}

		public void Rotate(Vector3 eulers, Space relativeTo) { }
		public void Rotate(Vector3 axis, float angle) { }
		public void Rotate(Vector3 axis, float angle, Space relativeTo) { }
		public void Rotate(float xAngle, float yAngle, float zAngle) { }
		public void Rotate(float xAngle, float yAngle, float zAngle, Space relativeTo) { }
		public void RotateAround(Vector3 point, Vector3 axis, float angle) { }

		public void SetParent(Transform parent) { }
		public void SetParent(Transform parent, bool worldPositionStays) { }

		public Vector3 InverseTransformPoint(Vector3 inPoint) => default;
		public Vector3 TransformPoint(Vector3 point) => default;
		public Vector3 TransformPoint(float x, float y, float z) => default;
		public Vector3 InverseTransformPoint(float x, float y, float z) => default;

		public Vector3 TransformDirection(Vector3 direction) => default;
		public Vector3 TransformDirection(float x, float y, float z) => default;
		public Vector3 InverseTransformDirection(Vector3 direction) => default;
		public Vector3 TransformVector(Vector3 vector) => default;
		public Vector3 TransformVector(float x, float y, float z) => default;
		public Vector3 InverseTransformVector(Vector3 vector) => default;

		public void Translate(Vector3 translation) { }
		public void Translate(Vector3 translation, Space relativeTo) { }
		public void Translate(Vector3 translation, Transform relativeTo) { }
		public void Translate(float x, float y, float z) { }
		public void Translate(float x, float y, float z, Space relativeTo) { }
		public void Translate(float x, float y, float z, Transform relativeTo) { }

		public T GetComponent<T>()
		{
			throw new NotImplementedException();
		}

		public Component GetComponent(Type type)
		{
			throw new NotImplementedException();
		}

		public T GetComponentInChildren<T>()
		{
			throw new NotImplementedException();
		}

		public T GetComponentInChildren<T>(bool includeInactive)
		{
			throw new NotImplementedException();
		}

		public T[] GetComponentsInChildren<T>()
		{
			throw new NotImplementedException();
		}

		public T[] GetComponentsInChildren<T>(bool includeInactive)
		{
			throw new NotImplementedException();
		}

		public T GetComponentInParent<T>()
		{
			throw new NotImplementedException();
		}

		public T GetComponentInParent<T>(bool includeInactive)
		{
			throw new NotImplementedException();
		}

		public T[] GetComponentsInParent<T>()
		{
			throw new NotImplementedException();
		}

		public T[] GetComponentsInParent<T>(bool includeInactive)
		{
			throw new NotImplementedException();
		}

		public T[] GetComponents<T>()
		{
			throw new NotImplementedException();
		}

		public void GetComponents<T>(System.Collections.Generic.List<T> results) { }

		public Transform GetChild(int index)
		{
			throw new NotImplementedException();
		}

		public Transform Find(string name)
		{
			throw new NotImplementedException();
		}

		public void DetachChildren() { }
		public void SetAsFirstSibling() { }
		public void SetAsLastSibling() { }
		public void SetSiblingIndex(int index) { }
		public int GetSiblingIndex() => 0;
		public bool IsChildOf(Transform parent) => false;

		public void LookAt(Transform target) { }
		public void LookAt(Transform target, Vector3 worldUp) { }
		public void LookAt(Vector3 worldPosition) { }
		public void LookAt(Vector3 worldPosition, Vector3 worldUp) { }

		public new int GetInstanceID() => 0;

		public static implicit operator bool(Transform exists) => exists != null;

		public System.Collections.IEnumerator GetEnumerator()
		{
			for (int i = 0; i < childCount; i++)
			{
				yield return GetChild(i);
			}
		}
	}
}
