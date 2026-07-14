using System;

namespace UnityEngine
{
	// Renamed from Object to avoid CS0104 ambiguity with System.Object
	public class UnityEngineObject
	{
		public string name { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
		public HideFlags hideFlags { get; set; }

		public int GetInstanceID() => throw new NotImplementedException();

		public static void Destroy(object target)
		{
			throw new NotImplementedException();
		}

		public static void Destroy(object target, float t)
		{
			throw new NotImplementedException();
		}

		public static void DestroyImmediate(object target)
		{
			throw new NotImplementedException();
		}

		public static void DestroyImmediate(object target, bool allowDestroyingAssets)
		{
			throw new NotImplementedException();
		}

		public static void DestroyObject(object obj) { }

		public static void DontDestroyOnLoad(object target)
		{
			throw new NotImplementedException();
		}

		public static T FindObjectOfType<T>() where T : class
		{
			throw new NotImplementedException();
		}

		public static T FindObjectOfType<T>(bool includeInactive) where T : class
		{
			throw new NotImplementedException();
		}

		public static UnityEngineObject FindObjectOfType(Type type)
		{
			throw new NotImplementedException();
		}

		public static T[] FindObjectsOfType<T>() where T : class
		{
			throw new NotImplementedException();
		}

		public static T[] FindObjectsOfType<T>(bool includeInactive) where T : class
		{
			throw new NotImplementedException();
		}

		public static UnityEngineObject[] FindObjectsOfType(Type type)
		{
			throw new NotImplementedException();
		}

		public static UnityEngineObject[] FindObjectsOfType(Type type, bool includeInactive)
		{
			throw new NotImplementedException();
		}

		public static UnityEngineObject Instantiate(UnityEngineObject original)
		{
			throw new NotImplementedException();
		}

		public static T Instantiate<T>(T original) where T : class
		{
			throw new NotImplementedException();
		}

		public static UnityEngineObject Instantiate(UnityEngineObject original, Transform parent)
		{
			throw new NotImplementedException();
		}

		public static T Instantiate<T>(T original, Transform parent) where T : class
		{
			throw new NotImplementedException();
		}

		public static UnityEngineObject Instantiate(UnityEngineObject original, Transform parent, bool instantiateInWorldSpace)
		{
			throw new NotImplementedException();
		}

		public static T Instantiate<T>(T original, Transform parent, bool instantiateInWorldSpace) where T : class
		{
			throw new NotImplementedException();
		}

		public static UnityEngineObject Instantiate(UnityEngineObject original, Vector3 position, Quaternion rotation)
		{
			throw new NotImplementedException();
		}

		public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : class
		{
			throw new NotImplementedException();
		}

		public static UnityEngineObject Instantiate(UnityEngineObject original, Vector3 position, Quaternion rotation, Transform parent)
		{
			throw new NotImplementedException();
		}

		public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation, Transform parent) where T : class
		{
			throw new NotImplementedException();
		}

		public override string ToString() => name;

		public static implicit operator bool(UnityEngineObject exists) => exists != null;
	}
}
