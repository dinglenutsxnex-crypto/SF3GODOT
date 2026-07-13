using System;
namespace UnityEngine
{
	public struct Ray
	{
		public Vector3 origin;
		public Vector3 direction;
		public Ray(Vector3 origin, Vector3 direction) { this.origin = origin; this.direction = direction; }
		public Vector3 GetPoint(float distance) => origin + direction * distance;
		public override string ToString() => $"Origin: {origin}, Direction: {direction}";
	}
}
