using System;

namespace UnityEngine
{
    public partial class Renderer : Component
    {
        public Material sharedMaterial { get; set; }
        public Material material { get; set; }
        public Material[] materials { get; set; }
        public Material[] sharedMaterials { get; set; }
        public bool enabled { get; set; }
        public Bounds bounds { get; }
        public Bounds localBounds { get; set; }
        public int sortingLayerID { get; set; }
        public string sortingLayerName { get; set; }
        public int sortingOrder { get; set; }
        public bool isVisible => false;
        public LightProbeUsage lightProbeUsage { get; set; }
        public ReflectionProbeUsage reflectionProbeUsage { get; set; }
        public Transform probeAnchor { get; set; }
        public int rendererPriority { get; set; }
        public RenderingLayerMask renderingLayerMask { get; set; }
        public void SetPropertyBlock(MaterialPropertyBlock properties) { }
        public void SetPropertyBlock(MaterialPropertyBlock properties, int materialIndex) { }
        public void GetPropertyBlock(MaterialPropertyBlock properties) { }
    }

    public class MeshRenderer : Renderer { }

    public enum LightProbeUsage { Off, BlendProbes, UseProxyVolume, CustomProvided }
    public enum ReflectionProbeUsage { Off, BlendProbes, Simple }
    public struct RenderingLayerMask { public int mask; public static implicit operator int(RenderingLayerMask m) => m.mask; }
}
