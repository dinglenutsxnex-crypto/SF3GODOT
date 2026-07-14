using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine
{
    public partial class Collider : Component
    {
        public bool enabled { get; set; }
        public bool isTrigger { get; set; }
        public float contactOffset { get; set; }
        public Rigidbody attachedRigidbody => null;
        public Bounds bounds { get; }
        public PhysicMaterial sharedMaterial { get; set; }
        public PhysicMaterial material { get; set; }
        public new T GetComponent<T>() => default;
        public Vector3 ClosestPointOnBounds(Vector3 position) => default;
    }

    public class PhysicMaterial : UnityEngineObject
    {
        public float dynamicFriction { get; set; }
        public float staticFriction { get; set; }
        public float bounciness { get; set; }
    }

    public partial class Rigidbody : Component
    {
        public float mass { get; set; }
        public float drag { get; set; }
        public float angularDrag { get; set; }
        public bool useGravity { get; set; }
        public bool isKinematic { get; set; }
        public Vector3 velocity { get; set; }
        public Vector3 angularVelocity { get; set; }
        public Vector3 position { get; set; }
        public Quaternion rotation { get; set; }
        public RigidbodyInterpolation interpolation { get; set; }
        public RigidbodyConstraints constraints { get; set; }
        public void AddForce(Vector3 force) { }
        public void AddForce(Vector3 force, ForceMode mode) { }
        public void AddForce(float x, float y, float z) { }
        public void AddForce(float x, float y, float z, ForceMode mode) { }
        public void AddTorque(Vector3 torque) { }
        public void AddTorque(Vector3 torque, ForceMode mode) { }
        public void AddTorque(float x, float y, float z) { }
        public void AddTorque(float x, float y, float z, ForceMode mode) { }
        public void AddTorque(float torque) { }
        public void MovePosition(Vector3 position) { }
        public void MoveRotation(Quaternion rot) { }
        public void Sleep() { }
        public bool IsSleeping() => false;
        public void WakeUp() { }
    }

    public partial class Rigidbody2D : Component
    {
        public float mass { get; set; }
        public float drag { get; set; }
        public float angularDrag { get; set; }
        public float gravityScale { get; set; }
        public bool isKinematic { get; set; }
        public bool freezeRotation { get; set; }
        public Vector2 velocity { get; set; }
        public float angularVelocity { get; set; }
        public Vector2 position { get; set; }
        public float rotation { get; set; }
        public RigidbodySleepMode2D sleepMode { get; set; }
        public RigidbodyConstraints2D constraints { get; set; }
        public RigidbodyInterpolation2D interpolation { get; set; }
        public CollisionDetectionMode2D collisionDetectionMode { get; set; }
        public PhysicsMaterial2D sharedMaterial { get; set; }
        public void AddForce(Vector2 force) { }
        public void AddForce(Vector2 force, ForceMode2D mode) { }
        public void AddForceAtPosition(Vector2 force, Vector2 position) { }
        public void AddForceAtPosition(Vector2 force, Vector2 position, ForceMode2D mode) { }
        public void AddTorque(float torque) { }
        public void AddTorque(float torque, ForceMode2D mode) { }
        public void MovePosition(Vector2 position) { }
        public void MoveRotation(float angle) { }
        public bool IsSleeping() => false;
        public bool IsAwake() => false;
        public void Sleep() { }
        public void WakeUp() { }
        public bool IsTouching(Collider2D collider) => false;
        public Vector2 GetPoint(Vector2 point) => default;
        public Vector2 GetRelativePoint(Vector2 relativePoint) => default;
        public Vector2 GetVector(Vector2 vector) => default;
        public Vector2 GetRelativeVector(Vector2 relativeVector) => default;
        public Vector2 GetPointVelocity(Vector2 point) => default;
        public Vector2 GetRelativePointVelocity(Vector2 relativePoint) => default;
        public void OverlapCollider(ContactFilter2D contactFilter, List<Collider2D> results) { }
    }

    public struct ContactFilter2D
    {
        public bool useTriggers;
        public bool useLayerMask;
        public LayerMask layerMask;
        public bool useDepth;
        public float minDepth;
        public float maxDepth;
        public bool useNormalAngle;
        public float minNormalAngle;
        public float maxNormalAngle;
        public static ContactFilter2D NoFilter => default;
    }

    public enum RigidbodySleepMode2D
    {
        NeverSleep = 0,
        StartAwake = 1,
        StartAsleep = 2,
    }

    public enum RigidbodyConstraints2D
    {
        None = 0,
        FreezePositionX = 1,
        FreezePositionY = 2,
        FreezeRotation = 4,
        FreezePosition = 3,
        FreezeAll = 7,
    }

    public enum RigidbodyInterpolation2D
    {
        None = 0,
        Interpolate = 1,
        Extrapolate = 2,
    }

    public enum CollisionDetectionMode2D
    {
        None = 0,
        Discrete = 1,
        Continuous = 2,
        ContinuousDynamic = 3,
        ContinuousSpeculative = 4,
    }

    public enum RigidbodyInterpolation
    {
        None = 0,
        Interpolate = 1,
        Extrapolate = 2,
    }

    public class BoxCollider : Collider { public Vector3 center { get; set; } public Vector3 size { get; set; } }
    public class SphereCollider : Collider { public Vector3 center { get; set; } public float radius { get; set; } }
    public class CapsuleCollider : Collider { public Vector3 center { get; set; } public float radius { get; set; } public float height { get; set; } public int direction { get; set; } }

    public partial class CharacterJoint : Component
    {
        public Rigidbody connectedBody { get; set; }
        public Vector3 swingAxis { get; set; }
        public SoftJointLimit lowTwistLimit { get; set; }
        public SoftJointLimit highTwistLimit { get; set; }
        public SoftJointLimit swing1Limit { get; set; }
        public SoftJointLimit swing2Limit { get; set; }
        public SoftJointLimitSpring twistLimitSpring { get; set; }
        public SoftJointLimitSpring swingLimitSpring { get; set; }
        public float projectionDistance { get; set; }
        public float projectionAngle { get; set; }
        public bool enablePreprocessing { get; set; }
        public bool enableProjection { get; set; }
        public bool enableCollision { get; set; }
        public Vector3 anchor { get; set; }
        public Vector3 axis { get; set; }
        public Vector3 connectedAnchor { get; set; }
        public bool autoConfigureConnectedAnchor { get; set; }
        public float breakForce { get; set; }
        public float breakTorque { get; set; }
    }

    public struct SoftJointLimit
    {
        public float limit;
        public float bounciness;
        public float contactDistance;
    }

    public struct SoftJointLimitSpring
    {
        public float spring;
        public float damper;
    }
    public partial class HingeJoint : Component { public Rigidbody connectedBody { get; set; } public bool useMotor { get; set; } public bool useLimits { get; set; } public JointMotor motor { get; set; } public JointLimits limits { get; set; } }
    public partial class FixedJoint : Component
    {
        public Rigidbody connectedBody { get; set; }
        public float breakForce { get; set; }
        public float breakTorque { get; set; }
    }
    public partial class Joint : Component
    {
        public Rigidbody connectedBody { get; set; }
        public float breakForce { get; set; }
        public float breakTorque { get; set; }
        public Vector3 axis { get; set; }
        public Vector3 anchor { get; set; }
        public bool autoConfigureConnectedAnchor { get; set; }
        public Vector3 connectedAnchor { get; set; }
        public bool enablePreprocessing { get; set; }
    }

    public struct JointMotor
    {
        public float targetVelocity;
        public float force;
        public bool useMotor;
    }

    public struct JointLimits
    {
        public float minAngle;
        public float maxAngle;
        public float minBounce;
        public float maxBounce;
        public float contactDistance;
        public bool enabled;
        public float min;
        public float max;
    }

    public partial class Collider2D : Behaviour { public bool isTrigger { get; set; } public Bounds bounds { get; } public PhysicsMaterial2D sharedMaterial { get; set; } }
    public class BoxCollider2D : Collider2D { public Vector2 size { get; set; } public Vector2 offset { get; set; } }
    public class PolygonCollider2D : Collider2D { public Vector2[] points { get; set; } public int pathCount { get; set; } }
    public class CircleCollider2D : Collider2D { public float radius { get; set; } public Vector2 offset { get; set; } }

    public partial class Cloth : Component { public float stretchingStiffness { get; set; } public bool useGravity { get; set; } public bool enabled { get; set; } public float bendingStiffness { get; set; } public float damping { get; set; } public float friction { get; set; } public float externalAcceleration { get; set; } public float collisionMass { get; set; } public int solverFrequency { get; set; } }

    public class Collision
    {
        public Collider collider => null;
        public Transform transform => null;
        public GameObject gameObject => null;
        public Rigidbody rigidbody => null;
        public ContactPoint[] contacts => null;
        public Vector3 impulse => default;
    }

    public struct ContactPoint
    {
        public Vector3 point;
        public Vector3 normal;
        public Collider thisCollider;
        public Collider otherCollider;
    }

    public class AndroidJavaClass : IDisposable
    {
        public AndroidJavaClass(string className) { }
        public void Dispose() { }
        public T Call<T>(string methodName, params object[] args) => default;
        public void Call(string methodName, params object[] args) { }
        public T CallStatic<T>(string methodName, params object[] args) => default;
        public void CallStatic(string methodName, params object[] args) { }
        public T Get<T>(string fieldName) => default;
        public void Set<T>(string fieldName, T val) { }
        public T GetStatic<T>(string fieldName) => default;
        public void SetStatic<T>(string fieldName, T val) { }
        public global::System.IntPtr GetRawClass() => default;
    }

    public class AndroidJavaObject : IDisposable
    {
        public AndroidJavaObject() { }
        public AndroidJavaObject(string className, params object[] args) { }
        public void Dispose() { }
        public T Call<T>(string methodName, params object[] args) => default;
        public void Call(string methodName, params object[] args) { }
        public T CallStatic<T>(string methodName, params object[] args) => default;
        public void CallStatic(string methodName, params object[] args) { }
        public T Get<T>(string fieldName) => default;
        public void Set<T>(string fieldName, T val) { }
        public static implicit operator AndroidJavaObject(AndroidJavaClass cls) => null;
    }
}
