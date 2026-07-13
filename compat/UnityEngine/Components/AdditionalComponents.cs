using System;

namespace UnityEngine
{
    public class SpriteRenderer : Renderer
    {
        public Sprite sprite { get; set; }
        public Color color { get; set; }
        public bool flipX { get; set; }
        public bool flipY { get; set; }
        public Vector2 size { get; set; }
        public float adaptiveModeThreshold { get; set; }
        public SpriteDrawMode drawMode { get; set; }
        public bool maskInteraction { get; set; }
        public bool sortingPoint { get; set; }
        public int sortingLayerID { get; set; }
        public string sortingLayerName { get; set; }
        public int sortingOrder { get; set; }
    }

    public enum SpriteDrawMode
    {
        Simple,
        Sliced,
        Tiled,
    }

    public class TextMesh : Component
    {
        public string text { get; set; }
        public Font font { get; set; }
        public int fontSize { get; set; }
        public FontStyle fontStyle { get; set; }
        public float offsetZ { get; set; }
        public TextAnchor alignment { get; set; }
        public TextAnchor anchor { get; set; }
        public float characterSize { get; set; }
        public float lineSpacing { get; set; }
        public float tabSize { get; set; }
        public bool richText { get; set; }
        public Color color { get; set; }
    }

    public class PhysicsMaterial2D : Object
    {
        public float bounciness { get; set; }
        public float friction { get; set; }
        public PhysicsMaterial2D() { }
        public PhysicsMaterial2D(string name) { }
    }

    public class VisibilityHandlerComponent : MonoBehaviour
    {
    }
}

namespace UnityEngine
{
    public partial class Canvas : Behaviour
    {
        public float overridePixelPerfect { get; set; }
        public bool pixelPerfect { get; set; }
        public int renderingOrder { get; set; }
        public RenderMode renderMode { get; set; }
        public float planeDistance { get; set; }
        public Camera worldCamera { get; set; }
        public int sortingOrder { get; set; }
        public int renderOrder { get; set; }
        public int sortingLayerID { get; set; }
        public string sortingLayerName { get; set; }
        public bool overrideSorting { get; set; }
        public float scaleFactor { get; set; }
        public float referencePixelsPerUnit { get; set; }
        public bool overridePixelPerfect2 { get; set; }
        public bool additionalShaderChannelsFlag { get; set; }
        public Canvas rootCanvas => null;
    }

    public class CanvasScaler
    {
        public enum ScaleMode
        {
            ConstantPixelSize,
            ScaleWithScreenSize,
            ConstantPhysicalSize,
        }

        public enum ScreenMatchMode
        {
            MatchWidthOrHeight,
            Expand,
            Shrink,
        }
    }
}
