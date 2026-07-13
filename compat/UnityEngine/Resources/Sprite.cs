using System;

namespace UnityEngine
{
	public class Sprite : Object
	{
		public Rect rect => default;
		public Texture2D texture => null;
		public Rect textureRect => default;
		public Vector2 textureRectOffset => default;
		public Bounds bounds => default;
		public float pixelsPerUnit => 0f;
		public Vector2 pivot => default;
		public Vector4 border => default;
		public bool packed => false;
		public SpritePackingMode packingMode { get; set; }
		public SpriteMeshType meshType { get; set; }
		public Vector2[] vertices => null;
		public ushort[] triangles => null;
		public Vector2[] uv => null;

		public Sprite() => throw new NotImplementedException();
		public Sprite(Texture2D texture, Rect rect, Vector2 pivot) => throw new NotImplementedException();
		public Sprite(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit) => throw new NotImplementedException();
		public Sprite(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude) => throw new NotImplementedException();
		public Sprite(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, int meshType) => throw new NotImplementedException();
		public Sprite(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, int meshType, Vector4 border) => throw new NotImplementedException();

		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot) => null;
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit) => null;
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude) => null;
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, int meshType) => null;
		public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, int meshType, Vector4 border) => null;

		public void OverrideGeometry(Vector2[] vertices, ushort[] triangles) { }
		public Mesh GetMesh() => null;
	}

	public enum SpritePackingMode
	{
		Tight = 0,
		Rectangle = 1,
	}

	public enum SpriteMeshType
	{
		FullRect = 0,
		Tight = 1,
	}
}
