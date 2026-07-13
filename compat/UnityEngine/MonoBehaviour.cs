using System.Collections;
using System.Collections.Generic;

namespace UnityEngine
{
	public class MonoBehaviour : Component
    {
        List<IEnumerator> coroutines = new List<IEnumerator>();

		public GameObject gameObject { get; set; }
		public new Transform transform => gameObject?.transform ?? null;

		public string tag { get; set; }
		public bool enabled { get; set; } = true;

		public bool isActiveAndEnabled => enabled;
		public bool isActiveAndEnabled1 => true;

		public MonoBehaviour()
		{
			gameObject = new GameObject();
		}

		public static implicit operator GameObject(MonoBehaviour m) => m?.gameObject;

		public static void DontDestroyOnLoad(object obj) { }

		public static void Destroy(object obj) { }
		public static void DestroyImmediate(object obj) { }
		public static void Destroy(Object obj) { }
		public static void DestroyImmediate(Object obj) { }
		public static void DestroyObject(object obj) { }

		public void SendMessage(string methodName) { }
		public void SendMessage(string methodName, object value) { }
		public void SendMessage(string methodName, SendMessageOptions options) { }
		public void SendMessageUpwards(string methodName) { }
		public void BroadcastMessage(string methodName) { }
		public void Invoke(string methodName, float time) { }
		public void InvokeRepeating(string methodName, float time, float repeatRate) { }
		public void CancelInvoke() { }
		public void CancelInvoke(string methodName) { }
		public bool IsInvoking() => false;
		public bool IsInvoking(string methodName) => false;
		public Coroutine StartCoroutine(string methodName) => null;
		public Coroutine StartCoroutine(IEnumerator routine) => null;
		public Coroutine StartCoroutine(string methodName, object value) => null;
		public void StopCoroutine(Coroutine routine) { }
		public void StopCoroutine(IEnumerator routine) { }
		public void StopCoroutine(string methodName) { }
		public void StopAllCoroutines() { }
		public Component GetComponent(System.Type type) => null;
		public T GetComponent<T>() => default;
		public Component GetComponent(string type) => null;
		public T GetComponentInChildren<T>() => default;
		public T GetComponentInChildren<T>(bool includeInactive) => default;
		public Component GetComponentInChildren(System.Type type) => null;
		public T[] GetComponentsInChildren<T>() => new T[0];
		public T[] GetComponentsInChildren<T>(bool includeInactive) => new T[0];
		public T GetComponentInParent<T>() => default;
		public T[] GetComponentsInParent<T>() => new T[0];
		public T[] GetComponents<T>() => new T[0];
		public void GetComponents<T>(System.Collections.Generic.List<T> results) { }
		public bool TryGetComponent<T>(out T component) { component = default; return false; }

		protected virtual void Awake() { }
		protected virtual void OnDestroy() { }
		protected virtual void OnEnable() { }
		protected virtual void OnDisable() { }
		protected virtual void Start() { }
		protected virtual void Update() { }
		protected virtual void LateUpdate() { }
		protected virtual void FixedUpdate() { }

		public static implicit operator bool(MonoBehaviour exists) => exists != null;

		public static void print(object message) => Debug.Log(message);
	}
}