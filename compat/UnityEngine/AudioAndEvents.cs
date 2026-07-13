using System;

namespace UnityEngine.Audio
{
    public class AudioMixer : Object
    {
        public bool SetFloat(string name, float value) => false;
        public bool GetFloat(string name, out float value) { value = 0; return false; }
        public bool ClearFloat(string name) => false;
        public AudioMixerGroup FindMatchingGroups(string subPath) => null;
        public AudioMixerSnapshot FindSnapshot(string name) => null;
    }

    public class AudioMixerGroup : Object
    {
        public AudioMixer audioMixer => null;
        public string Name => "";
    }

    public class AudioMixerSnapshot : Object
    {
        public AudioMixer audioMixer => null;
        public void TransitionTo(float timeToReach) { }
    }
}

namespace UnityEngine.Events
{
    [Serializable]
    public class UnityEvent
    {
        public void Invoke() { }
        public void AddListener(UnityAction call) { }
        public void RemoveListener(UnityAction call) { }
        public void RemoveAllListeners() { }
    }

    [Serializable]
    public class UnityEvent<T0>
    {
        public void Invoke(T0 arg0) { }
        public void AddListener(UnityAction<T0> call) { }
        public void RemoveListener(UnityAction<T0> call) { }
    }

    [Serializable]
    public class UnityEvent<T0, T1>
    {
        public void Invoke(T0 arg0, T1 arg1) { }
        public void AddListener(UnityAction<T0, T1> call) { }
        public void RemoveListener(UnityAction<T0, T1> call) { }
    }

    [Serializable]
    public class UnityEvent<T0, T1, T2>
    {
        public void Invoke(T0 arg0, T1 arg1, T2 arg2) { }
        public void AddListener(UnityAction<T0, T1, T2> call) { }
        public void RemoveListener(UnityAction<T0, T1, T2> call) { }
    }

    [Serializable]
    public class UnityEvent<T0, T1, T2, T3>
    {
        public void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3) { }
        public void AddListener(UnityAction<T0, T1, T2, T3> call) { }
        public void RemoveListener(UnityAction<T0, T1, T2, T3> call) { }
    }

    public delegate void UnityAction();
    public delegate void UnityAction<T0>(T0 arg0);
    public delegate void UnityAction<T0, T1>(T0 arg0, T1 arg1);
    public delegate void UnityAction<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2);
    public delegate void UnityAction<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3);
}

namespace UnityEngine.EventSystems
{
    public class BaseEventData
    {
        public BaseEventData(EventSystem eventSystem) { }
        public bool used => false;
    }

    public interface IEventSystemHandler { }
    public interface IPointerEnterHandler : IEventSystemHandler { void OnPointerEnter(PointerEventData eventData); }
    public interface IPointerExitHandler : IEventSystemHandler { void OnPointerExit(PointerEventData eventData); }
    public interface IPointerDownHandler : IEventSystemHandler { void OnPointerDown(PointerEventData eventData); }
    public interface IPointerUpHandler : IEventSystemHandler { void OnPointerUp(PointerEventData eventData); }
    public interface IPointerClickHandler : IEventSystemHandler { void OnPointerClick(PointerEventData eventData); }
    public interface IBeginDragHandler : IEventSystemHandler { void OnBeginDrag(PointerEventData eventData); }
    public interface IDragHandler : IEventSystemHandler { void OnDrag(PointerEventData eventData); }
    public interface IEndDragHandler : IEventSystemHandler { void OnEndDrag(PointerEventData eventData); }
    public interface IDropHandler : IEventSystemHandler { void OnDrop(PointerEventData eventData); }
    public interface IScrollHandler : IEventSystemHandler { void OnScroll(PointerEventData eventData); }
    public interface ISelectHandler : IEventSystemHandler { void OnSelect(BaseEventData eventData); }
    public interface IDeselectHandler : IEventSystemHandler { void OnDeselect(BaseEventData eventData); }
    public interface ISubmitHandler : IEventSystemHandler { void OnSubmit(BaseEventData eventData); }
    public interface ICancelHandler : IEventSystemHandler { void OnCancel(BaseEventData eventData); }
    public interface IInitializePotentialDragHandler : IEventSystemHandler { void OnInitializePotentialDrag(PointerEventData eventData); }
    public interface IMoveHandler : IEventSystemHandler { void OnMove(AxisEventData eventData); }

    public class PointerEventData : BaseEventData
    {
        public PointerEventData(EventSystem eventSystem) : base(eventSystem) { }
        public GameObject pointerPress => null;
        public GameObject pointerDrag => null;
        public Vector2 position { get; set; }
        public Vector2 delta { get; set; }
        public Vector2 pressPosition { get; set; }
        public int clickCount { get; set; }
        public bool dragging { get; set; }
        public bool eligibleForClick { get; set; }
    }

    public class AxisEventData : BaseEventData
    {
        public Vector2 moveVector { get; set; }
        public MoveDirection moveDir { get; set; }
        public AxisEventData(EventSystem eventSystem) : base(eventSystem) { }
    }

    public enum MoveDirection { Left, Up, Right, Down, None }

    public class EventSystem : MonoBehaviour
    {
        public static EventSystem current { get; set; }
        public GameObject currentSelectedGameObject => null;
        public void SetSelectedGameObject(GameObject selected) { }
    }

    public static class ExecuteEvents
    {
        public delegate void EventFunction<T1>(T1 handler, BaseEventData eventData);
        public static EventFunction<T> GetEventHandler<T>(GameObject root) where T : class, IEventSystemHandler => null;
        public static bool Execute<T>(GameObject target, BaseEventData eventData, EventFunction<T> functor) where T : IEventSystemHandler => false;

        public static EventFunction<IPointerClickHandler> pointerClickHandler => (h, e) => h.OnPointerClick((PointerEventData)e);
        public static EventFunction<IPointerDownHandler> pointerDownHandler => (h, e) => h.OnPointerDown((PointerEventData)e);
        public static EventFunction<IPointerUpHandler> pointerUpHandler => (h, e) => h.OnPointerUp((PointerEventData)e);
        public static EventFunction<IPointerEnterHandler> pointerEnterHandler => (h, e) => h.OnPointerEnter((PointerEventData)e);
        public static EventFunction<IPointerExitHandler> pointerExitHandler => (h, e) => h.OnPointerExit((PointerEventData)e);
        public static EventFunction<IBeginDragHandler> beginDragHandler => (h, e) => h.OnBeginDrag((PointerEventData)e);
        public static EventFunction<IDragHandler> dragHandler => (h, e) => h.OnDrag((PointerEventData)e);
        public static EventFunction<IEndDragHandler> endDragHandler => (h, e) => h.OnEndDrag((PointerEventData)e);
        public static EventFunction<IDropHandler> dropHandler => (h, e) => h.OnDrop((PointerEventData)e);
        public static EventFunction<IScrollHandler> scrollHandler => (h, e) => h.OnScroll((PointerEventData)e);
        public static EventFunction<IInitializePotentialDragHandler> initializePotentialDrag => (h, e) => h.OnInitializePotentialDrag((PointerEventData)e);
    }

    public class StandaloneInputModule : MonoBehaviour { }
}

namespace UnityEngine.Rendering
{
    public enum CameraEvent
    {
        BeforeDepthTexture = 0,
        AfterDepthTexture = 1,
        BeforeDepthNormalsTexture = 2,
        AfterDepthNormalsTexture = 3,
        BeforeOpaques = 10,
        AfterOpaques = 15,
        BeforeSkybox = 20,
        AfterSkybox = 25,
        BeforeTransparents = 30,
        AfterTransparents = 35,
        BeforeOverlay = 40,
        AfterOverlay = 45,
        BeforeReflections = 50,
        BeforeImageEffectsOpaque = 55,
        BeforeImageEffects = 60,
    }
}
