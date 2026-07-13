# Memory Index

- [Unity compat shim fixing strategy](unity-compat-shim.md) — when a Unity→Godot compat shim has a type/signature mismatch, trust the vendored Unity source (it's correct against real Unity) and fix the shim, not the call site.
- [Godot Vector3 property vs field trap](godot-vector3-out-param.md) — compat Vector3.x/y/z are properties (backed by Godot.Vector3), so `out`/`ref` on components fails; real Unity's are fields. Fix call sites, not the struct.
- [Godot C#/.NET Android export needs Gradle](godot-android-csharp-export.md) — "experimental" export error isn't "Android unsupported"; enable gradle_build/use_gradle_build + run `--install-android-build-template` headlessly.
