---
name: Unity compat shim fixing strategy
description: How to resolve dotnet build errors in a hand-written UnityEngine compat layer used to port Unity C# scripts to Godot .NET.
---

When a wholesale-copied Unity `Assembly-CSharp` codebase is built against a hand-written `compat/UnityEngine/*` shim (instead of real Unity), build errors are almost always because the shim's type shape (signature, inheritance, nested types, static-vs-instance) doesn't match real Unity's actual API — not because the vendored game code is wrong.

**Why:** The vendored scripts are decompiled/copied from a real, working Unity project. The compat layer was hand-authored quickly and is the fragile side. Rewriting call sites to work around a wrong shim just spreads the divergence across many files instead of fixing it once.

**How to apply:** For each build error, find the real Unity API shape (from Unity docs/behavior knowledge or by cross-referencing multiple call sites) and fix the shim to match, e.g.:
- `Material`/`Transform` must inherit `UnityEngine.Object`.
- `Transform` needs `GetEnumerator()` for `foreach (Transform child in transform)`.
- `ParticleSystem.MainModule`/`EmissionModule`/`ShapeModule`/`MinMaxCurve`/`MinMaxGradient` must be nested types inside `ParticleSystem`, not top-level.
- `RenderTexture.MarkRestoreExpected()` is an instance method in real Unity, not static.
- `GL.Begin` takes `int` (mode constants), not a custom enum.
- `Gradient.colorKeys`/`alphaKeys` are `GradientColorKey[]`/`GradientAlphaKey[]`.
- `AudioListener.volume` is static; `Camera.stereoActiveEye` is instance.
- `ColorBlock` lives in `UnityEngine.UI`, not bare `UnityEngine` (avoid duplicate/ambiguous definitions across namespaces).
- `UnityEngine.UI.Text` exposes a protected `m_Text` field backing the `text` property (subclasses access it directly).
- `Graphic` (UI) has both `mainMaterial` and a separate `material` property.
- Only fall back to editing the vendored call site itself when the mismatch is structural/architectural on the shim side and not worth a broad refactor (e.g. Vector3 component access via `out` params — see the Godot Vector3 topic file).

One exception worth flagging separately: legacy .NET-Framework-only APIs used only for dead/unreachable code paths (e.g. Windows self-extracting EXE generation via `CSharpCodeProvider`/`CompilerParameters`, or CAS `ReflectionPermission`/`SecurityPermission` checks) are best stubbed out or removed rather than shimmed, since they don't exist in modern .NET and the code path is unreachable at runtime anyway.
