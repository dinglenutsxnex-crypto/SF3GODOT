using System;

namespace UnityEngine
{
	public class GUIStyle
	{
		public Font font;
		public FontStyle fontStyle;
		public bool wordWrap;
		public TextAnchor alignment;

		public GUIStyle() { }
		public GUIStyle(GUIStyle original) { }
		public static implicit operator GUIStyle(string name) => new GUIStyle();

		public float CalcHeight(GUIContent content, float width)
		{
			return 0f;
		}
	}
}