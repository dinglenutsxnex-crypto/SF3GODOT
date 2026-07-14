using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
    public enum CanvasUpdate
    {
        Prelayout, Layout, PostLayout, PreRender, LatePreRender, MaxUpdateValue,
    }

    public class Graphic : MonoBehaviour
    {
        public RectTransform rectTransform => GetComponent<RectTransform>();
        public virtual Material mainMaterial { get; set; }
        public virtual Material material { get; set; }
        public virtual Color color { get; set; }
        public bool raycastTarget { get; set; }
        public virtual void SetAllDirty() { }
        public virtual void SetLayoutDirty() { }
        public virtual void SetVerticesDirty() { }
        public virtual void SetMaterialDirty() { }
        public virtual void Rebuild(UnityEngine.UI.CanvasUpdate update) { }
        public virtual void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha) { }
        public virtual void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale) { }
    }

    public class MaskableGraphic : Graphic
    {
        public bool maskable { get; set; }
    }

    public class Text : MaskableGraphic
    {
        protected string m_Text;
        public virtual string text { get => m_Text; set => m_Text = value; }
        public Font font { get; set; }
        public int fontSize { get; set; }
        public FontStyle fontStyle { get; set; }
        public TextAnchor alignment { get; set; }
        public bool supportRichText { get; set; }
        public HorizontalWrapMode horizontalOverflow { get; set; }
        public VerticalWrapMode verticalOverflow { get; set; }
        public float lineSpacing { get; set; }
        public bool resizeTextForBestFit { get; set; }
        public int resizeTextMinSize { get; set; }
        public int resizeTextMaxSize { get; set; }
        public float preferredWidth => 0;
        public float preferredHeight => 0;
        public virtual void SetVerticesDirty() { }
        public virtual void SetMaterialDirty() { }
        public UnityEngine.TextGenerator cachedTextGenerator => null;
        protected virtual void OnPopulateMesh(VertexHelper toFill) { }
        protected virtual void OnPopulateMesh(Mesh mesh) { }
    }

    public class Image : MaskableGraphic
    {
        public Sprite sprite { get; set; }
        public Image.Type type { get; set; }
        public bool preserveAspect { get; set; }
        public bool fillCenter { get; set; }
        public Image.FillMethod fillMethod { get; set; }
        public float fillAmount { get; set; }
        public bool fillClockwise { get; set; }
        public int fillOrigin { get; set; }
        public override Material mainMaterial { get; set; }
        public enum Type { Simple, Sliced, Tiled, Filled }
        public enum FillMethod { Horizontal, Vertical, Radial90, Radial180, Radial360 }
    }

    public class RawImage : MaskableGraphic
    {
        public Texture texture { get; set; }
        public Rect uvRect { get; set; }
    }

    public class Button : MonoBehaviour
    {
        public ButtonClickedEvent onClick;
        public ColorBlock colors { get; set; }
        public bool interactable { get; set; }
        public void Select() { }
        [Serializable]
        public class ButtonClickedEvent
        {
            public void AddListener(UnityEngine.Events.UnityAction call) { }
            public void RemoveListener(UnityEngine.Events.UnityAction call) { }
            public void Invoke() { }
        }
    }

    public class Toggle : MonoBehaviour
    {
        public bool isOn { get; set; }
        public ToggleEvent onValueChanged;
        public bool interactable { get; set; }
        public void Select() { }
        [Serializable]
        public class ToggleEvent { public void AddListener(UnityEngine.Events.UnityAction<bool> call) { } public void RemoveListener(UnityEngine.Events.UnityAction<bool> call) { } }
    }

    public class Slider : MonoBehaviour
    {
        public float value { get; set; }
        public float minValue { get; set; }
        public float maxValue { get; set; }
        public bool wholeNumbers { get; set; }
        public SliderEvent onValueChanged;
        public bool interactable { get; set; }
        [Serializable]
        public class SliderEvent { public void AddListener(UnityEngine.Events.UnityAction<float> call) { } public void RemoveListener(UnityEngine.Events.UnityAction<float> call) { } }
    }

    public class InputField : MonoBehaviour
    {
        public string text { get; set; }
        public int characterLimit { get; set; }
        public ContentType contentType { get; set; }
        public LineType lineType { get; set; }
        public OnChangeEvent onValueChanged;
        public SubmitEvent onEndEdit;
        public bool interactable { get; set; }
        public void ActivateInputField() { }
        public void DeactivateInputField() { }
        public enum ContentType { Standard, Autocorrected, IntegerNumber, DecimalNumber, Alphanumeric, Name, EmailAddress, Password, Pin, Custom }
        public enum LineType { SingleLine, MultiLineSubmit, MultiLineNewline }
        [Serializable] public class OnChangeEvent { public void AddListener(UnityEngine.Events.UnityAction<string> call) { } public void RemoveListener(UnityEngine.Events.UnityAction<string> call) { } }
        [Serializable] public class SubmitEvent { public void AddListener(UnityEngine.Events.UnityAction<string> call) { } public void RemoveListener(UnityEngine.Events.UnityAction<string> call) { } }
    }

    public class ScrollRect : MonoBehaviour
    {
        public RectTransform content { get; set; }
        public bool horizontal { get; set; }
        public bool vertical { get; set; }
        public float horizontalNormalizedPosition { get; set; }
        public float verticalNormalizedPosition { get; set; }
        public ScrollRectEvent onValueChanged;
        public Scrollbar horizontalScrollbar { get; set; }
        public Scrollbar verticalScrollbar { get; set; }
        [Serializable] public class ScrollRectEvent { public void AddListener(UnityEngine.Events.UnityAction<UnityEngine.Vector2> call) { } public void RemoveListener(UnityEngine.Events.UnityAction<UnityEngine.Vector2> call) { } }
    }

    public class Scrollbar : MonoBehaviour
    {
        public float value { get; set; }
        public ScrollEvent onValueChanged;
        public bool interactable { get; set; }
        [Serializable] public class ScrollEvent { public void AddListener(UnityEngine.Events.UnityAction<float> call) { } public void RemoveListener(UnityEngine.Events.UnityAction<float> call) { } }
    }

    public class Dropdown : MonoBehaviour
    {
        public int value { get; set; }
        public List<OptionData> options;
        public DropdownEvent onValueChanged;
        public bool interactable { get; set; }
        public void ClearOptions() { }
        public void AddOptions(List<string> opts) { }
        public void RefreshShownValue() { }
        [Serializable] public class OptionData { public string text; public Sprite image; public OptionData() { } public OptionData(string text) { this.text = text; } }
        [Serializable] public class DropdownEvent { public void AddListener(UnityEngine.Events.UnityAction<int> call) { } public void RemoveListener(UnityEngine.Events.UnityAction<int> call) { } }
    }

    public class GraphicRaycaster : MonoBehaviour
    {
        public bool ignoreReversedGraphics { get; set; }
        public BlockingObjects blockingObjects { get; set; }
        public LayerMask blockingMask { get; set; }
        public enum BlockingObjects { None, TwoD, ThreeD, All }
    }

    public class ContentSizeFitter : MonoBehaviour
    {
        public FitMode horizontalFit { get; set; }
        public FitMode verticalFit { get; set; }
        public enum FitMode { Unconstrained, MinSize, PreferredSize }
    }

    public class HorizontalLayoutGroup : HorizontalOrVerticalLayoutGroup { }
    public class VerticalLayoutGroup : HorizontalOrVerticalLayoutGroup { }
    public class HorizontalOrVerticalLayoutGroup : LayoutGroup { }

    public class LayoutGroup : MonoBehaviour
    {
        public UnityEngine.RectOffset padding { get; set; }
        public TextAnchor childAlignment { get; set; }
        public virtual void SetLayoutHorizontal() { }
        public virtual void SetLayoutVertical() { }
    }

    public class LayoutElement : MonoBehaviour
    {
        public virtual bool ignoreLayout { get; set; }
        public virtual float minWidth { get; set; }
        public virtual float minHeight { get; set; }
        public virtual float preferredWidth { get; set; }
        public virtual float preferredHeight { get; set; }
        public virtual float flexibleWidth { get; set; }
        public virtual float flexibleHeight { get; set; }
        public virtual int layoutPriority { get; set; }
    }

    public class Shadow : MonoBehaviour
    {
        public UnityEngine.Color effectColor { get; set; }
        public UnityEngine.Vector2 effectDistance { get; set; }
        public bool useGraphicAlpha { get; set; }
    }

    public class Outline : Shadow { }

    public class VertexHelper : IDisposable
    {
        public VertexHelper() { }
        public void Dispose() { }
        public void Clear() { }
        public int currentVertCount => 0;
        public int currentTriCount => 0;
        public void AddVert(UnityEngine.Vector3 position, UnityEngine.Color32 color, UnityEngine.Vector2 uv) { }
        public void AddVert(UIVertex v) { }
        public void AddTriangle(int idx0, int idx1, int idx2) { }
        public void AddUIVertexQuad(UIVertex[] verts) { }
        public void GetUIVertexStream(List<UIVertex> stream) { }
        public void PopulateUIVertex(ref UIVertex vertex, int index) { vertex = default; }
        public void SetUIVertex(UIVertex vertex, int index) { }
    }

    [Serializable]
    public struct ColorBlock
    {
        public Color normalColor;
        public Color highlightedColor;
        public Color pressedColor;
        public Color selectedColor;
        public Color disabledColor;
        public float fadeDuration;
        public static ColorBlock defaultColorBlock => default;
    }

    public struct UIVertex
    {
        public UnityEngine.Vector3 position;
        public UnityEngine.Vector3 normal;
        public UnityEngine.Vector4 tangent;
        public UnityEngine.Color32 color;
        public UnityEngine.Vector2 uv0;
        public UnityEngine.Vector2 uv1;
        public UnityEngine.Vector2 uv2;
        public UnityEngine.Vector3 worldPos;
        public static UIVertex simpleVert;
    }
}

namespace UnityEngine
{
    public enum FontStyle
    {
        Normal, Bold, Italic, BoldAndItalic,
    }

    public enum TextAnchor
    {
        UpperLeft, UpperCenter, UpperRight,
        MiddleLeft, MiddleCenter, MiddleRight,
        LowerLeft, LowerCenter, LowerRight,
    }

    public enum VerticalWrapMode
    {
        Truncate, Overflow,
    }

    public enum HorizontalWrapMode
    {
        Wrap, Overflow,
    }

    public class Font : UnityEngineObject
    {
        public string[] fontNames { get; set; }
        public int fontSize { get; set; }
        public Material material { get; set; }
        public bool dynamic => false;
        public int ascent => 0;
        public int lineHeight => 0;
        public Texture2D texture => null;
        public static event System.Action<Font> textureRebuilt;
        public bool HasCharacter(char c) => false;
        public string[] fontNames2 { get; set; }
        public void RequestCharactersInTexture(string characters, int size, FontStyle style) { }
        public void RequestCharactersInTexture(string characters, int size) { }
        public void RequestCharactersInTexture(string characters) { }
        public bool GetCharacterInfo(char ch, out CharacterInfo info, int size, FontStyle style) { info = default; return false; }
        public bool GetCharacterInfo(char ch, out CharacterInfo info, int size) { info = default; return false; }
        public bool GetCharacterInfo(char ch, out CharacterInfo info) { info = default; return false; }
        public int[] GetKerning(int first, int second) => new int[0];
    }

    public class TextGenerator
    {
        public int characterCountVisible => 0;
        public float preferredWidth => 0;
        public float preferredHeight => 0;
        public TextGenerator() { }
        public TextGenerator(int initialCapacity) { }
        public void Invalidate() { }
    }

    public struct TextGenerationSettings
    {
        public Font font;
        public Color color;
        public int fontSize;
        public float scaleFactor;
        public float lineSpacing;
        public bool richText;
    }
}
