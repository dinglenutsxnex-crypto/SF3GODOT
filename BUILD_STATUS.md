# Build Status — SF3 → Godot Port

Last updated: 2026-07-13

## What was done this pass

The project previously failed to compile with **137 unique C# build errors**. All of
them are now resolved — `dotnet build SF3GODOT.csproj` succeeds with **0 errors,
0 warnings**.

The fixes fell into three categories:

### 1. Compat shim corrections (bulk of the work)

The hand-written `compat/UnityEngine/*` layer (which stands in for the real
`UnityEngine` assembly) had many type/signature mismatches against what the
vendored Unity game scripts actually expect. Since the vendored scripts are a
straight copy of a real, working Unity project, the shim — not the game code —
was the thing that needed to change. Fixed to match real Unity's actual API
shape:

- `Material` / `Transform` now inherit `UnityEngine.Object`; `Transform`
  supports `foreach (Transform child in transform)`.
- `ParticleSystem.MainModule` / `EmissionModule` / `ShapeModule` /
  `MinMaxCurve` / `MinMaxGradient` are now nested types inside `ParticleSystem`
  (matches real Unity's nested-type API).
- `RenderTexture`: added the 5-argument constructor; `MarkRestoreExpected()`
  is an instance method (was incorrectly static).
- `GL.Begin` takes `int` (with `GL.TRIANGLES`/`LINES`/`QUADS` constants), not
  a custom enum. Added `GL.ClearWithSkybox` overload.
- `Gradient.colorKeys` / `alphaKeys` are typed `GradientColorKey[]` /
  `GradientAlphaKey[]` (modern Unity API), fixing DOTween and in-game color
  animation code.
- `AnimationCurve` got an indexer (`curve[i]`).
- `AssetBundle.LoadFromFile` returns `AssetBundle` (was a custom async-only
  type).
- `Graphics`: added missing `Blit(Texture, Material, int)`,
  `SetRenderTarget(RenderTexture, int)`, and
  `DrawProceduralIndirectNow(MeshTopology, ComputeBuffer, int)` overloads.
- `Input.GetKey/GetKeyDown/GetKeyUp` got `string`-based overloads (used by
  debug key bindings).
- `Object.FindObjectsOfType(Type)` / `(Type, bool)` and
  `Resources.FindObjectsOfTypeAll(Type)` non-generic overloads added (used by
  NGUI utility code).
- `EventTrigger.Entry.callback` retyped to `UnityEvent<BaseEventData>` so
  `.AddListener(...)` works.
- Added a minimal `UnityEngine.Social` / `ISocialPlatform` / `ILocalUser`
  stub for the (unused, single-player) Game Center integration code.
- `RectTransformUtility.WorldToScreenPoint` corrected to take a `Camera` as
  its first argument (was wrongly typed as `RectTransform`).
- Added a minimal `TextEditor` stub (clipboard get/set on NGUI).
- Fixed a duplicate/ambiguous `ColorBlock` definition (it only exists in
  `UnityEngine.UI` in real Unity, not the bare `UnityEngine` namespace).
- Fixed static/instance mismatches: `AudioListener.volume` is static,
  `Camera.stereoActiveEye` is an instance property.
- `UnityEngine.UI.Text` now exposes the `m_Text` protected backing field that
  some subclasses (e.g. rich-text rendering) access directly; `UI.Graphic`
  now has both `mainMaterial` and `material`.
- `Mathf.SmoothDampAngle` got the 5-argument overload (default `maxSpeed`).
- `DownloadHandlerScript` now correctly derives from `DownloadHandler`.
- Added `Observable.EveryUpdate()` to the minimal UniRx shim.

### 2. Vendored third-party library cleanup

- Removed dead Windows-only self-extracting-EXE code from the vendored
  `Ionic.Zip` (`System.CodeDom`/`CSharpCodeProvider` — unreachable on this
  platform anyway).
- Removed the vendored `Newtonsoft.Json` source entirely and replaced it with
  the real `Newtonsoft.Json` NuGet package (13.0.3) — the vendored copy used
  legacy .NET Framework Code Access Security APIs that don't exist in
  `net8.0`.
- Suppressed build-breaking "obsolete API" errors (`SYSLIB0003`, `SYSLIB0011`,
  `SYSLIB0022`) for legacy crypto/serialization code paths that are copied
  as-is from Unity and not worth rewriting right now.

### 3. One call-site fix

`TriggerActionShakeCamera.cs` used `out`/`ref` on `Vector3.x/y/z` components.
In this shim, `Vector3` wraps a `Godot.Vector3` and exposes `x/y/z` as
computed properties (not fields like real Unity), so they can't be passed by
`ref`/`out`. Reworked to read into local floats first, then construct the
`Vector3`.

## Current state

- `dotnet build SF3GODOT.csproj` — **passes cleanly**.
- No Godot workflow/run command is configured yet in this environment (this
  is a compile-only C# port at this stage; nothing renders yet).
- A GitHub Actions workflow (`.github/workflows/android-build.yml`) has been
  added that builds the project and exports a debug Android APK on every push
  — see the section below for caveats.

## What's remaining

1. **Scene conversion (not started).** `assets/scenes/enterPoint.scene.json`
   and `assets/scenes/fight.scene.json` are a custom pre-converted format (not
   real Godot `.tscn`). They still need a converter that reads this JSON and
   emits proper Godot scene files with correctly wired node trees, resource
   references, and GUIDs. Partial `.meta` GUID coverage exists from the
   uploaded Unity source zip (`/tmp/unity_original`); full coverage may
   require the user to supply more `.meta` files, or the converter can
   proceed and flag any GUIDs it can't resolve.
2. **Runtime verification.** The project has never actually been run in the
   Godot editor/headless — compiling is necessary but not sufficient. Once
   scenes exist, expect a further round of runtime errors (null refs, missing
   resource loads, NGUI layout issues, animation binary parsing, etc.) that
   won't show up as compiler errors.
3. **No Godot workflow configured** in this Replit environment yet. Once
   there's an actual playable scene, a workflow should be set up so the game
   is visible/testable in the preview (or over remote debug, since Godot's
   GUI won't render directly in the web preview pane the way a normal web app
   does).
4. **SmartFox2X networking is stubbed** (single-player only, by design per
   `PLAN.md`) — no further work planned there unless requirements change.
5. **CI Android export caveats** — see below. The workflow is a best-effort
   setup; it downloads Godot 4.4 mono export templates and a bare Android
   SDK toolchain, generates a throwaway debug keystore, and produces a debug
   APK. Since there's no in-game content/scenes yet, the resulting APK will
   build but won't show meaningful gameplay until item 1 above is done. The
   Godot version pinned in the workflow should be bumped if the project is
   later upgraded past 4.4.x.
