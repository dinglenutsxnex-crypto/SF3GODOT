using System;
using Godot;
using System.Reflection;

namespace UnityEngine
{
	public class GameObject : UnityEngineObject
    {
		Node _node;

		public new string name
		{
			get { return _node.GetName(); }
			set { _node.SetName(value); }
		}

		public Transform transform { get; private set; }
		public GameObject gameObject => this;
		public int layer { get; set; }
		public string tag { get; set; }
		public bool activeSelf { get { try { var v = _node.Get("Visible"); return v.VariantType == Godot.Variant.Type.Bool && (bool)v; } catch { return false; } } }
		public bool activeInHierarchy => activeSelf;
		public bool isStatic { get; set; }
		public HideFlags hideFlags { get; set; }

		internal GameObject(Node node)
		{
			_node = node;
		}

		public GameObject()
		{
			_node = new Node();
			name = "Game Object";
			UnityEngineAutoLoad.Instance.AddChild(_node);
		}

		public GameObject(string name)
		{
			_node = new Node();
			this.name = name;
			UnityEngineAutoLoad.Instance.AddChild(_node);
		}

		public GameObject(string name, params Type[] components)
		{
			_node = new Node();
			this.name = name;
			UnityEngineAutoLoad.Instance.AddChild(_node);
		}

		public void SetActive(bool active)
		{
			PropertyInfo visibleProperty = _node.GetType().GetProperty("Visible");
			if (visibleProperty != null)
			{
				visibleProperty.SetValue(_node, active);
			}
		}

		public new int GetInstanceID() => (int)_node.GetInstanceId();

		public static Node Find(string name)
		{
			Node root = UnityEngineAutoLoad.Instance.GetTree().GetRoot();
			return FindChild(root, name);
		}

		static Node FindChild(Node parent, string name)
		{
			int childCount = parent.GetChildCount();

			if (parent.GetName().Equals(name))
			{
				return parent;
			}

			if (childCount > 0)
			{
				for (int i = 0; i < childCount; i++)
				{
					Node node = FindChild(parent.GetChild(i), name);
					if (node != null)
					{
						return node;
					}
				}
			}

			return null;
		}

		public T GetComponent<T>()
		{
			return default;
		}

		public T AddComponent<T>()
		{
			return default;
		}

		public void SendMessage(string methodName) { }
		public void SendMessage(string methodName, object value) { }
		public void SendMessage(string methodName, SendMessageOptions options) { }
		public void SendMessage(string methodName, object value, SendMessageOptions options) { }
		public void SendMessageUpwards(string methodName) { }
		public void SendMessageUpwards(string methodName, object value) { }
		public void BroadcastMessage(string methodName) { }
		public void BroadcastMessage(string methodName, object parameter) { }
		public void BroadcastMessage(string methodName, SendMessageOptions options) { }
		public void BroadcastMessage(string methodName, object parameter, SendMessageOptions options) { }

		public T[] GetComponents<T>() => new T[0];

		public static GameObject[] FindGameObjectsWithTag(string tag) => new GameObject[0];
		public static GameObject FindGameObjectWithTag(string tag) => null;
		public static GameObject FindWithTag(string tag) => null;

		public bool CompareTag(string tag) => false;

		public void SetTag(string tag) { }

		public static implicit operator Node(GameObject gameObject)
		{
			return gameObject._node;
		}

		public static implicit operator GameObject(Node node)
		{
			return new GameObject(node);
		}

		public static implicit operator bool(GameObject exists) => exists != null && exists._node != null;

		public static GameObject CreatePrimitive(PrimitiveType type) => new GameObject();

		public Component GetComponent(Type type) => null;
		public Component GetComponent(string type) => null;
		public T GetComponentInChildren<T>() => default;
		public T GetComponentInChildren<T>(bool includeInactive) => default;
		public Component GetComponentInChildren(Type type) => null;
		public T[] GetComponentsInChildren<T>() => new T[0];
		public T[] GetComponentsInChildren<T>(bool includeInactive) => new T[0];
		public T GetComponentInParent<T>() => default;
		public T[] GetComponentsInParent<T>() => new T[0];
		public Component AddComponent(Type componentType) => null;
		public void GetComponents<T>(System.Collections.Generic.List<T> results) { }
		public bool TryGetComponent<T>(out T component) { component = default; return false; }
	}
}
