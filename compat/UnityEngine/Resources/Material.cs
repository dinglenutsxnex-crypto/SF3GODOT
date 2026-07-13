using System;

namespace UnityEngine
{
	public class Material
	{
		public string name { get; set; }
		public HideFlags hideFlags { get; set; }
		public Texture mainTexture { get; set; }
		public Vector2 mainTextureOffset { get; set; }
		public Vector2 mainTextureScale { get; set; }
		public Color color { get; set; }
		public Shader shader { get; set; }
		public int renderQueue { get; set; }
		public int passCount => 0;
		public string[] shaderKeywords { get; set; }

		public Material() => throw new NotImplementedException();
		public Material(Material source) => throw new NotImplementedException();
		public Material(Shader shader) => throw new NotImplementedException();

		public void SetVector(string name, Vector4 value) { }
		public void SetVector(int nameID, Vector4 value) { }
		public void SetFloat(string name, float value) { }
		public void SetFloat(int nameID, float value) { }
		public void SetTexture(string name, Texture value) { }
		public void SetTexture(int nameID, Texture value) { }
		public void SetColor(string name, Color value) { }
		public void SetColor(int nameID, Color value) { }
		public void SetMatrix(string name, Matrix4x4 value) { }
		public void SetMatrix(int nameID, Matrix4x4 value) { }
		public void SetInt(string name, int value) { }
		public void SetInt(int nameID, int value) { }

		public Vector4 GetVector(string name) => default;
		public Vector4 GetVector(int nameID) => default;
		public float GetFloat(string name) => 0f;
		public float GetFloat(int nameID) => 0f;
		public Texture GetTexture(string name) => null;
		public Texture GetTexture(int nameID) => null;
		public Color GetColor(string name) => default;
		public Color GetColor(int nameID) => default;
		public Matrix4x4 GetMatrix(string name) => default;
		public int GetInt(string name) => 0;

		public void SetTextureOffset(string name, Vector2 value) { }
		public void SetTextureOffset(int nameID, Vector2 value) { }
		public void SetTextureScale(string name, Vector2 value) { }
		public void SetTextureScale(int nameID, Vector2 value) { }

		public bool HasProperty(string name) => false;
		public bool HasProperty(int nameID) => false;
		public bool IsKeywordEnabled(string keyword) => false;
		public void EnableKeyword(string keyword) { }
		public void DisableKeyword(string keyword) { }
		public bool SetPass(int pass) => false;

		public Material[] materials { get; set; }
		public Material[] sharedMaterials { get; set; }

		public bool HasConstantBuffer(string name) => false;
		public void SetConstantBuffer(string name, ComputeBuffer value) { }
		public void SetConstantBuffer(int nameID, ComputeBuffer value) { }
		public void SetBuffer(string name, ComputeBuffer value) { }
		public void SetBuffer(int nameID, ComputeBuffer value) { }
		public Vector2 GetTextureOffset(string name) => default;
		public Vector2 GetTextureOffset(int nameID) => default;
		public Vector2 GetTextureScale(string name) => default;
		public Vector2 GetTextureScale(int nameID) => default;

		public int GetTag(string tag, bool searchFallbacks) => 0;
		public string GetTag(string tag, bool searchFallbacks, string defaultValue) => "";
		public void SetOverrideTag(string tag, string val) { }
		public bool IsPassEnabled(int pass) => false;

		public int shaderPassEnabled(string passName) => 0;

		public static implicit operator bool(Material exists) => exists != null;

		public void CopyPropertiesFromMaterial(Material mat) { }
		public int GetInstanceID() => 0;
	}
}
