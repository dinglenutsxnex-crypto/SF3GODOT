using System;
using System.Collections;
using UnityEngine.EventSystems;

namespace UnityEngine
{
    public class Behaviour : Component
    {
        public bool enabled { get; set; }
        public bool isActiveAndEnabled => enabled;
    }

    public class Animator : Behaviour
    {
        public RuntimeAnimatorController runtimeAnimatorController { get; set; }
        public RuntimeAnimatorController GetRuntimeAnimatorController() => runtimeAnimatorController;
        public void SetTrigger(string name) { }
        public void SetTrigger(int id) { }
        public void ResetTrigger(string name) { }
        public void ResetTrigger(int id) { }
        public void SetBool(string name, bool value) { }
        public void SetBool(int id, bool value) { }
        public bool GetBool(string name) => false;
        public bool GetBool(int id) => false;
        public void SetInteger(string name, int value) { }
        public void SetInteger(int id, int value) { }
        public int GetInteger(string name) => 0;
        public int GetInteger(int id) => 0;
        public void SetFloat(string name, float value) { }
        public void SetFloat(int id, float value) { }
        public float GetFloat(string name) => 0f;
        public float GetFloat(int id) => 0f;
        public void Play(string stateName) { }
        public void Play(string stateName, int layer) { }
        public void Play(string stateName, int layer, float normalizedTime) { }
        public void Play(int stateNameHash) { }
        public void Play(int stateNameHash, int layer) { }
        public void Play(int stateNameHash, int layer, float normalizedTime) { }
        public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex) => default;
        public AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex) => default;
        public bool IsInTransition(int layerIndex) => false;
        public int layerCount => 0;
        public float speed { get; set; }
        public bool ApplyRootMotion { get; set; }
        public void Update(float deltaTime) { }
        public void Update() { }
    }

    public struct AnimatorStateInfo
    {
        public int fullPathHash => 0;
        public int shortNameHash => 0;
        public int fullPathHash2 => 0;
        public float normalizedTime => 0f;
        public float length => 0f;
        public float speed => 0f;
        public float speedMultiplier => 1f;
        public int tagHash => 0;
        public bool IsName(string name) => false;
        public bool IsTag(string tag) => false;
    }

    public class RuntimeAnimatorController : Object { }

    public class Animation : Behaviour
    {
        public AnimationClip this[string name] { get => null; }
        public AnimationClip clip { get; set; }
        public bool playAutomatically { get; set; }
        public bool isPlaying => false;
        public WrapMode wrapMode { get; set; }
        public AnimationState this[AnimationState state] { get => null; }
        public void Sample() { }
        public void Play() { }
        public void Play(string animation) { }
        public void Play(string animation, PlayMode mode) { }
        public void Stop() { }
        public void Stop(string animation) { }
        public void Rewind() { }
        public void Rewind(string animation) { }
        public bool IsPlaying(string animation) => false;
        public void AddClip(AnimationClip clip, string newName) { }
        public void AddClip(AnimationClip clip, string newName, int firstFrame, int lastFrame) { }
        public void RemoveClip(AnimationClip clip) { }
        public int GetClipCount() => 0;
        public AnimationState AddClip(AnimationClip clip, string name, bool legacy) => null;
        public void RemoveClip(string clipName) { }
        public System.Collections.IEnumerator GetEnumerator() => null;
    }

    public class AnimationState
    {
        public float time { get; set; }
        public float speed { get; set; }
        public AnimationClip clip => null;
        public string name => "";
        public bool enabled { get; set; }
        public float weight { get; set; }
        public float length => 0f;
        public void Sample(Animation anim) { }
        public AnimationClip clip2 { get; set; }
        public AnimationBlendMode blendMode { get; set; }
    }

    public enum AnimationBlendMode
    {
        Blend,
        Additive,
    }

    public class AnimationClip : UnityEngineObject
    {
        public float length => 0f;
        public float normalizedTime => 0f;
        public WrapMode wrapMode { get; set; }
        public AnimationEvent[] animationEvents { get; set; }
        public bool empty => true;
        public void SampleAnimation(GameObject go, float time) { }
    }

    public class AnimationEvent
    {
        public string functionName;
        public float time;
        public float floatParameter;
        public int intParameter;
        public string stringParameter;
        public Object objectReferenceParameter;
    }

    public enum PlayMode
    {
        StopSameLayer,
        StopAll,
        Queue,
        MixIn,
    }

    public enum WrapMode
    {
        Once = 1,
        Loop = 2,
        PingPong = 4,
        Default = 0,
        ClampForever = 8,
    }

    public class AnimationCurve
    {
        public Keyframe[] keys { get; set; }
        public Keyframe this[int index] => keys[index];
        public int length => keys?.Length ?? 0;
        public AnimationCurveMode preWrapMode { get; set; }
        public AnimationCurveMode postWrapMode { get; set; }
        public AnimationCurve(params Keyframe[] keys) { this.keys = keys; }
        public float Evaluate(float time) => 0f;
        public int AddKey(float time, float value) => 0;
        public int AddKey(Keyframe key) => 0;
        public void RemoveKey(int index) { }
        public static AnimationCurve Linear(float timeStart, float valueStart, float timeEnd, float valueEnd) => new AnimationCurve();
        public static AnimationCurve EaseInOut(float timeStart, float valueStart, float timeEnd, float valueEnd) => new AnimationCurve();
        public void SmoothTangents(int index, float weight) { }
    }

    public enum AnimationCurveMode
    {
        Wrap,
        Clamp,
    }

    public struct Keyframe
    {
        public float time;
        public float value;
        public float inTangent;
        public float outTangent;
        public Keyframe(float time, float value) { this.time = time; this.value = value; inTangent = 0; outTangent = 0; }
        public Keyframe(float time, float value, float inTangent, float outTangent) { this.time = time; this.value = value; this.inTangent = inTangent; this.outTangent = outTangent; }
    }

    public class AudioListener : Behaviour
    {
        public static float volume { get; set; }
        public bool pause { get; set; }
    }

    public class AudioBehaviour : Behaviour { }

    public class Light : Behaviour
    {
        public LightType type { get; set; }
        public Color color { get; set; }
        public float intensity { get; set; }
        public float range { get; set; }
        public float spotAngle { get; set; }
        public float bounceIntensity { get; set; }
        public float shadowStrength { get; set; }
    }

    public enum LightType
    {
        Spot,
        Directional,
        Point,
        Area,
    }

    public class LineRenderer : Renderer
    {
        public int positionCount { get; set; }
        public float startWidth { get; set; }
        public float endWidth { get; set; }
        public Color startColor { get; set; }
        public Color endColor { get; set; }
        public int numCapVertices { get; set; }
        public bool useWorldSpace { get; set; }
        public void SetPosition(int index, Vector3 position) { }
        public Vector3 GetPosition(int index) => default;
        public void SetPositions(Vector3[] positions) { }
        public void SetColors(Color start, Color end) { }
    }

    public class TrailRenderer : Renderer
    {
        public float time { get; set; }
        public float startWidth { get; set; }
        public float endWidth { get; set; }
        public Color startColor { get; set; }
        public Color endColor { get; set; }
        public int positionCount => 0;
        public void Clear() { }
    }

    public class MeshFilter : Component
    {
        public Mesh mesh { get; set; }
        public Mesh sharedMesh { get; set; }
    }

    public class SkinnedMeshRenderer : Renderer
    {
        public Mesh sharedMesh { get; set; }
        public Transform rootBone { get; set; }
        public Transform[] bones { get; set; }
        public Bounds localBounds { get; set; }
        public ShadowCastingMode shadowCastingMode { get; set; }
        public bool receiveShadows { get; set; }
        public void SetBlendShapeWeight(int index, float value) { }
        public float GetBlendShapeWeight(int index) => 0f;
        public Material material { get; set; }
        public void BakeMesh(Mesh mesh) { }
        public void BakeMesh(Mesh mesh, bool useScale) { }
        public Mesh GetBlendShapeBuffer() => null;
    }

    public class ParticleSystem : Component
    {
        public bool isPlaying => false;
        public bool isStopped => false;
        public bool isPaused => false;
        public bool isEmitting => false;
        public void Play() { }
        public void Play(bool withChildren) { }
        public void Stop() { }
        public void Stop(bool withChildren) { }
        public void Stop(bool withChildren, ParticleSystemStopBehavior stopBehavior) { }
        public void Pause() { }
        public void Pause(bool withChildren) { }
        public void Clear() { }
        public void Clear(bool withChildren) { }
        public bool IsAlive() => false;
        public bool IsAlive(bool withChildren) => false;
        public void Simulate(float t) { }
        public void Simulate(float t, bool withChildren) { }
        public void Simulate(float t, bool withChildren, bool resetTimeHierarchy) { }
        public int particleCount => 0;
        public float duration => 0f;
        public float time { get; set; }
        public bool loop { get; set; }
        public bool playOnAwake { get; set; }
        public float simulationSpeed { get; set; }
        public float startLifetime { get; set; }
        public float startSpeed { get; set; }
        public float startSize { get; set; }
        public Color startColor { get; set; }
        public float startRotation { get; set; }
        public float gravityModifier { get; set; }
        public int maxParticles { get; set; }
        public MainModule main => default;
        public EmissionModule emission => default;
        public ShapeModule shape => default;
        public MinMaxCurve startLifetimeCurve => default;
        public MinMaxCurve startSpeedCurve => default;
        public MinMaxCurve startSizeCurve => default;
        public MinMaxGradient startColorGradient => default;
        public MinMaxCurve startRotationCurve => default;

        public struct MainModule
        {
            public MinMaxCurve startLifetime { get; set; }
            public MinMaxCurve startSpeed { get; set; }
            public MinMaxCurve startSize { get; set; }
            public MinMaxGradient startColor { get; set; }
            public MinMaxCurve startRotation { get; set; }
            public bool flipRotation { get; set; }
            public float gravityModifier { get; set; }
            public bool playOnAwake { get; set; }
            public float simulationSpeed { get; set; }
            public bool loop { get; set; }
            public bool prewarm { get; set; }
            public int maxParticles { get; set; }
            public float duration => 0f;
            public ParticleSystemSimulationSpace simulationSpace { get; set; }
            public ParticleSystemScalingMode scalingMode { get; set; }
        }

        public struct EmissionModule
        {
            public bool enabled { get; set; }
            public MinMaxCurve rateOverTime { get; set; }
            public MinMaxCurve rateOverDistance { get; set; }
            public int burstCount => 0;
        }

        public struct ShapeModule
        {
            public bool enabled { get; set; }
            public ParticleSystemShapeType shapeType { get; set; }
            public float radius { get; set; }
            public float angle { get; set; }
            public Vector3 position { get; set; }
            public Vector3 rotation { get; set; }
            public Vector3 scale { get; set; }
        }

        public struct MinMaxGradient
        {
            public Color color;
            public Gradient gradient;
            public MinMaxGradient(Color color) { this.color = color; gradient = null; }
            public MinMaxGradient(Gradient gradient) { this.gradient = gradient; color = default; }
            public static implicit operator MinMaxGradient(Color color) => new MinMaxGradient(color);
            public static implicit operator MinMaxGradient(Gradient gradient) => new MinMaxGradient(gradient);
        }

        public struct MinMaxCurve
        {
            public float constant;
            public float constantMin;
            public float constantMax;
            public MinMaxCurve(float constant) { this.constant = constant; constantMin = constant; constantMax = constant; }
            public MinMaxCurve(float min, float max) { constant = 0; constantMin = min; constantMax = max; }
            public static implicit operator MinMaxCurve(float constant) => new MinMaxCurve(constant);
        }
    }

    public enum ParticleSystemStopBehavior
    {
        StopEmittingAndClear,
        StopEmitting,
    }

    public enum ParticleSystemSimulationSpace
    {
        Local,
        World,
        Custom,
    }

    public enum ParticleSystemScalingMode
    {
        Hierarchy,
        Local,
        Shape,
    }

    public enum ParticleSystemShapeType
    {
        Sphere,
        SphereShell,
        Hemisphere,
        HemisphereShell,
        Cone,
        Box,
        Mesh,
        ConeShell,
        ConeVolume,
        ConeVolumeShell,
        Circle,
        CircleEdge,
        SingleSidedEdge,
        MeshRenderer,
        SkinnedMeshRenderer,
        BoxShell,
        BoxEdge,
        Donut,
        Rectangle,
        Particle,
    }

    public class Projector : Behaviour
    {
        public Material material { get; set; }
        public Material[] materials { get; set; }
        public bool orthographic { get; set; }
        public float orthographicSize { get; set; }
        public float fieldOfView { get; set; }
        public float nearClipPlane { get; set; }
        public float farClipPlane { get; set; }
        public float aspectRatio { get; set; }
    }

    public class EventTrigger : MonoBehaviour
    {
        public System.Collections.Generic.List<Entry> triggers;
        public class Entry
        {
            public EventTriggerType eventID;
            public UnityEngine.Events.UnityEvent<BaseEventData> callback = new UnityEngine.Events.UnityEvent<BaseEventData>();
        }
    }

    public class CanvasGroup : Component
    {
        public float alpha { get; set; }
        public bool interactable { get; set; }
        public bool blocksRaycasts { get; set; }
        public bool ignoreParentGroups { get; set; }
    }

    public enum ForceMode
    {
        Force,
        Acceleration,
        Impulse,
        VelocityChange,
    }

    public enum ForceMode2D
    {
        Force,
        Impulse,
    }

    public class Component : UnityEngineObject
    {
        public GameObject gameObject { get; set; }
        public Transform transform { get; set; }
        public string tag { get; set; }
        public T GetComponent<T>() => default;
        public Component GetComponent(Type type) => null;
        public Component GetComponent(string type) => null;
        public T GetComponentInChildren<T>() => default;
        public T GetComponentInChildren<T>(bool includeInactive) => default;
        public Component GetComponentInChildren(Type type) => null;
        public Component GetComponentInChildren(Type type, bool includeInactive) => null;
        public T[] GetComponentsInChildren<T>() => null;
        public T[] GetComponentsInChildren<T>(bool includeInactive) => null;
        public void GetComponentsInChildren<T>(System.Collections.Generic.List<T> results) { }
        public void GetComponentsInChildren<T>(bool includeInactive, System.Collections.Generic.List<T> results) { }
        public T GetComponentInParent<T>() => default;
        public T GetComponentInParent<T>(bool includeInactive) => default;
        public T[] GetComponentsInParent<T>() => null;
        public T[] GetComponentsInParent<T>(bool includeInactive) => null;
        public T[] GetComponents<T>() => null;
        public void GetComponents<T>(System.Collections.Generic.List<T> results) { }
        public bool TryGetComponent<T>(out T component) { component = default; return false; }
        public void SendMessage(string methodName) { }
        public void SendMessage(string methodName, object value) { }
        public void SendMessage(string methodName, SendMessageOptions options) { }
        public void SendMessageUpwards(string methodName) { }
        public void SendMessageUpwards(string methodName, object value) { }
        public void BroadcastMessage(string methodName) { }
        public void BroadcastMessage(string methodName, object parameter) { }
        public void BroadcastMessage(string methodName, SendMessageOptions options) { }
        public void BroadcastMessage(string methodName, object parameter, SendMessageOptions options) { }
        public bool CompareTag(string tag) => false;
    }
}
