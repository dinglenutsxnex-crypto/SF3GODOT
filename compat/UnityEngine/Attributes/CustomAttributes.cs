using System;

namespace UnityEngine
{
    [AttributeUsage(AttributeTargets.Field)]
    public class HideInInspector : Attribute
    {
        public HideInInspector() { }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class AddComponentMenu : Attribute
    {
        public string componentMenu;
        public int componentOrder;
        public AddComponentMenu(string menuName) { componentMenu = menuName; }
        public AddComponentMenu(string menuName, int order) { componentMenu = menuName; componentOrder = order; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ExecuteInEditMode : Attribute { }

    [AttributeUsage(AttributeTargets.Class)]
    public class ExecuteAlways : Attribute { }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RequireComponent : Attribute
    {
        public Type m_Type0;
        public Type m_Type1;
        public Type m_Type2;
        public RequireComponent(Type requiredComponent) { m_Type0 = requiredComponent; }
        public RequireComponent(Type requiredComponent, Type requiredComponent2) { m_Type0 = requiredComponent; m_Type1 = requiredComponent2; }
        public RequireComponent(Type requiredComponent, Type requiredComponent2, Type requiredComponent3) { m_Type0 = requiredComponent; m_Type1 = requiredComponent2; m_Type2 = requiredComponent3; }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ContextMenu : Attribute
    {
        public string menuItem;
        public ContextMenu(string itemName) { menuItem = itemName; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class Header : Attribute
    {
        public string header;
        public int order;
        public Header(string header) { this.header = header; }
        public Header(string header, int order) { this.header = header; this.order = order; }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class Tooltip : Attribute
    {
        public string tooltip;
        public Tooltip(string tooltip) { this.tooltip = tooltip; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class SpaceAttribute : Attribute
    {
        public float height;
        public SpaceAttribute() { height = 8f; }
        public SpaceAttribute(float height) { this.height = height; }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class RangeAttribute : Attribute
    {
        public float min;
        public float max;
        public RangeAttribute(float min, float max) { this.min = min; this.max = max; }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class Multiline : Attribute
    {
        public int lines;
        public Multiline() { lines = 3; }
        public Multiline(int lines) { this.lines = lines; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class DisallowMultipleComponent : Attribute { }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ImageEffectOpaque : Attribute { }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ImageEffectTransformsToLDR : Attribute { }

    [AttributeUsage(AttributeTargets.Field)]
    public class TextArea : Attribute
    {
        public int minLines;
        public int maxLines;
        public TextArea() { }
        public TextArea(int minLines, int maxLines) { this.minLines = minLines; this.maxLines = maxLines; }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ColorUsage : Attribute
    {
        public bool showAlpha;
        public bool hdr;
        public ColorUsage(bool showAlpha) { this.showAlpha = showAlpha; }
        public ColorUsage(bool showAlpha, bool hdr) { this.showAlpha = showAlpha; this.hdr = hdr; }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class Min : Attribute
    {
        public float min;
        public Min(float min) { this.min = min; }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class Max : Attribute
    {
        public float max;
        public Max(float max) { this.max = max; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class SelectionBaseAttribute : Attribute { }
}
