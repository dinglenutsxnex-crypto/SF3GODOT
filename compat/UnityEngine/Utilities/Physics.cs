using System;

namespace UnityEngine
{
	public static class Physics
	{
		public static Vector3 gravity { get; set; } = new Vector3(0, -9.81f, 0);

		public static RaycastHit[] RaycastAll(Ray ray) => new RaycastHit[0];
		public static RaycastHit[] RaycastAll(Ray ray, float maxDistance) => new RaycastHit[0];
		public static RaycastHit[] RaycastAll(Ray ray, float maxDistance, int layerMask) => new RaycastHit[0];
		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction) => new RaycastHit[0];
		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance) => new RaycastHit[0];
		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float maxDistance, int layerMask) => new RaycastHit[0];

		public static bool Raycast(Ray ray) => false;
		public static bool Raycast(Ray ray, float maxDistance) => false;
		public static bool Raycast(Ray ray, float maxDistance, int layerMask) => false;
		public static bool Raycast(Ray ray, out RaycastHit hitInfo) { hitInfo = default; return false; }
		public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance) { hitInfo = default; return false; }
		public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask) { hitInfo = default; return false; }
		public static bool Raycast(Vector3 origin, Vector3 direction) => false;
		public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance) => false;
		public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance, int layerMask) => false;
		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo) { hitInfo = default; return false; }
		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance) { hitInfo = default; return false; }
		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask) { hitInfo = default; return false; }

		public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results) => 0;
		public static Collider[] OverlapSphere(Vector3 position, float radius) => new Collider[0];
		public static Collider[] OverlapSphere(Vector3 position, float radius, int layerMask) => new Collider[0];

		public static bool Linecast(Vector3 start, Vector3 end) => false;
		public static bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo) { hitInfo = default; return false; }
		public static bool Linecast(Vector3 start, Vector3 end, int layerMask) => false;

		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction) => false;
		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo) { hitInfo = default; return false; }
		public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation) => false;

		public static int DefaultRaycastLayers => -5;
		public static int AllLayers => -1;

		public static void IgnoreCollision(Collider collider1, Collider collider2) { }
		public static void IgnoreCollision(Collider collider1, Collider collider2, bool ignore) { }
		public static void IgnoreLayerCollision(int layer1, int layer2) { }
		public static void IgnoreLayerCollision(int layer1, int layer2, bool ignore) { }
	}

	public static class Physics2D
	{
		public static Vector2 gravity { get; set; } = new Vector2(0, -9.81f);

		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction) => default;
		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance) => default;
		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask) => default;

		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction) => new RaycastHit2D[0];
		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance) => new RaycastHit2D[0];
		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask) => new RaycastHit2D[0];

		public static Collider2D[] OverlapCircleAll(Vector2 point, float radius) => new Collider2D[0];
		public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask) => new Collider2D[0];

		public static bool Linecast(Vector2 start, Vector2 end) => false;
		public static bool Linecast(Vector2 start, Vector2 end, out RaycastHit2D hitInfo) { hitInfo = default; return false; }

		public static Collider2D[] OverlapPointAll(Vector2 point) => new Collider2D[0];
		public static Collider2D[] OverlapPointAll(Vector2 point, int layerMask) => new Collider2D[0];
		public static Collider2D OverlapPoint(Vector2 point) => null;
		public static Collider2D OverlapPoint(Vector2 point, int layerMask) => null;
	}

	public struct RaycastHit2D
	{
		public float distance;
		public Vector2 point;
		public Vector2 normal;
		public Collider2D collider;
		public Transform transform;
		public Rigidbody2D rigidbody;
		public float fraction;
		public bool Equals(RaycastHit2D other) => false;
		public static implicit operator bool(RaycastHit2D hit) => hit.collider != null;
	}
}
