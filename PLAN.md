# SF3 → Godot Port Plan

**Project:** Shadow Fight 3 (Nekki) → Godot 4.4 (.NET/C#)
**Unity original:** 2021.3.25f1, HDRP, NGUI, SmartFox2X
**Godot target:** 4.4 Mono, GL Compatibility renderer

---

## Decisions Locked

| Decision | Choice |
|----------|--------|
| **NGUI** | Full compatibility layer — UISprite, UILabel, UIButton, UIWidget, UIPanel, UITexture, UIScrollBar, UIProgressBar, UIInput, NGUITools, TweenPosition/Alpha/Scale/Color, UIAtlas, UIRoot, EventDelegate |
| **DOTween** | Keep as-is — compile source library directly, do NOT convert to Godot Tween |
| **Animation .bytes** | Ship as-is, deserialize at runtime via existing `AnimationBinaries`/`MovesParser` C# code, feed into Godot AnimationTree |
| **Third-party libs** | Exact Unity source copies (DOTween, UniRx, Newtonsoft.Json, Google.Protobuf, Ionic.Zip, BouncyCastle) |
| **SmartFox2X** | Stubbed out — single-player only |
| **UI approach** | Full NGUI compat layer (not rewriting to native Godot Controls) |

---

## Project Structure

```
SF3GODOT/
├── scripts/
│   ├── Core/
│   │   ├── GodotBehaviour.cs       # MonoBehaviour → Godot lifecycle mapping
│   │   ├── UnityCompat.cs           # Vector2/3, Mathf, Color, Time, Input shims
│   │   ├── ResourceLoader.cs        # Resources.Load → GD.Load
│   │   └── ExtentionBehaviour.cs    # Custom Nekki base class
│   ├── NGUI/                        # Full NGUI compatibility layer
│   │   ├── UISprite.cs
│   │   ├── UILabel.cs
│   │   ├── UIButton.cs
│   │   ├── UIWidget.cs
│   │   ├── UIPanel.cs
│   │   ├── UITexture.cs
│   │   ├── UIScrollBar.cs
│   │   ├── UIProgressBar.cs
│   │   ├── UIInput.cs
│   │   ├── UISlider.cs
│   │   ├── NGUITools.cs
│   │   ├── TweenPosition.cs
│   │   ├── TweenAlpha.cs
│   │   ├── TweenScale.cs
│   │   ├── TweenColor.cs
│   │   ├── UIRoot.cs
│   │   ├── UIAtlas.cs
│   │   ├── UISpriteData.cs
│   │   ├── EventDelegate.cs
│   │   └── UICamera.cs
│   ├── NekkiFramework/              # Nekki UI layer (thin wrappers over NGUI)
│   │   ├── NekkiUIRoot.cs
│   │   ├── NekkiUIRootModules.cs
│   │   ├── NekkiUIModule.cs
│   │   ├── NekkiUILabel.cs
│   │   ├── NekkiUISprite.cs
│   │   ├── NekkiUITexture.cs
│   │   ├── NekkiUIDialog.cs
│   │   ├── NekkiUIElements.cs
│   │   └── NekkiCanvasRoot.cs
│   ├── Assembly-CSharp/             # Main game logic (ported)
│   │   ├── Battle/                  # BattleController, FightController, RoundController
│   │   ├── Model/                   # Model, Skeleton, Skins, Collision
│   │   ├── Animation/               # AnimationBinaries, MovesParser, AnimationFrame
│   │   ├── Effects/                 # Hit effects, camera shake, slow-mo, particles
│   │   ├── Audio/                   # AudioManager, ModelAudio
│   │   ├── Items/                   # Item, Equipment, Perk, Inventory
│   │   ├── Triggers/                # TriggerEvent*, TriggerAction*
│   │   ├── Tactics/                 # Tactics, AI behaviors
│   │   ├── UI/                      # HUD, menus, dialogs
│   │   ├── Network/                 # Stubbed out (SFS*, NetworkState*)
│   │   ├── Utils/                   # JsonUtils, DtoExtensions, etc.
│   │   └── Data/                    # Constants, Settings, DTOs
│   └── Libs/                        # Third-party (exact Unity source copies)
│       ├── DOTween/
│       ├── UniRx/
│       ├── Newtonsoft.Json/
│       ├── Google.Protobuf/
│       ├── Ionic.Zip.Unity/
│       └── BouncyCastle/
├── assets/                          # Copied from assets-recoveredfromunity
│   ├── animations/                  # .bytes (shipped as-is)
│   ├── audio/                       # .mp3
│   ├── configs/                     # .json, .txt settings
│   ├── effects/                     # .glb
│   ├── fonts/                       # .ttf
│   ├── locations/                   # .glb
│   ├── shaders/                     # .gdshader (rewritten from Unity .shader)
│   ├── skins/                       # .glb + .png
│   ├── tactics/                     # .bytes
│   ├── textures/                    # .png
│   └── weapons/                     # .glb + .png
├── scenes/
│   ├── Fight.tscn                   # Main fight scene
│   └── MainMenu.tscn                # Simple scene for iteration
├── addons/godot_mcp/                # Existing MCP addon
├── project.godot
└── PLAN.md
```

---

## Key Unity → Godot Mappings

| Unity API | Godot Equivalent |
|-----------|-----------------|
| `MonoBehaviour` | `GodotBehaviour` (custom class) |
| `MonoBehaviour.Awake()` | `GodotBehaviour._Ready()` (track `_awake` flag) |
| `MonoBehaviour.Start()` | `GodotBehaviour._Ready()` (track `_started` flag) |
| `MonoBehaviour.Update()` | `GodotBehaviour._Process(double delta)` |
| `MonoBehaviour.FixedUpdate()` | `GodotBehaviour._PhysicsProcess(double delta)` |
| `MonoBehaviour.LateUpdate()` | `GodotBehaviour._Process()` (after main update) |
| `GameObject` | `Node` / `Node3D` |
| `Transform` | `Node3D` (position/rotation/scale) |
| `Instantiate(prefab)` | `GD.Load<PackedScene>(path).Instantiate()` |
| `Destroy(obj)` | `obj.QueueFree()` |
| `GetComponent<T>()` | `GetNode<T>()` / `GetChild<T>()` |
| `Resources.Load<T>(path)` | `GD.Load<T>(path)` |
| `Input.GetKey` / `GetButton` | `Input.IsKeyPressed` / `Input.IsActionPressed` |
| `Physics.Raycast` | `PhysicsDirectSpaceState3D.IntersectRay` |
| `Time.deltaTime` | `GetProcessDeltaTime()` |
| `Time.timeScale` | `Engine.TimeScale` |
| `Time.fixedDeltaTime` | `Engine.PhysicsTicksFixedHZ` |
| `Coroutine` | `await ToSignal(GetTree().CreateTimer(delay), "timeout")` |
| `OnTriggerEnter` | `_on_area_entered` signal |
| `OnCollisionEnter` | `_on_body_entered` signal |
| `SkinnedMeshRenderer` | `MeshInstance3D` + `Skeleton3D` |
| `AnimationClip` | `Animation` resource |
| `Animator` | `AnimationTree` + `AnimationNodeBlendTree` / `AnimationNodeStateMachine` |
| `Material` | `ShaderMaterial` / `StandardMaterial3D` |
| `MonoBehaviour.OnGUI` | `Control._Draw()` |
| `Screen.width` / `height` | `DisplayServer.WindowGetSize()` |
| `Random.Range` | `GD.RandRange` |
| `Mathf.Lerp` | `Mathf.Lerp` |
| `Vector3.Lerp` | `Vector3.Lerp` |
| `Quaternion.LookRotation` | `Quaternion.LookingAt` |
| `Object.DontDestroyOnLoad` | `SceneTree.MakeCurrent()` / auto-load |
| `layer` (LayerMask) | `collision_layer` / `collision_mask` |

---

## Implementation Phases

### Phase 1: Core Engine Adapter
- `GodotBehaviour` base class with Awake/Start/Update/LateUpdate/FixedUpdate mapped to Godot lifecycle
- `UnityCompat` — Vector2, Vector3, Quaternion, Color, Color32, Mathf, Time, Input, Random, WaitForSeconds, WaitForEndOfFrame, Coroutine
- `GameObject` / `Transform` shim classes wrapping Node/Node3D
- `Resources.Load<T>` → `GD.Load<T>` wrapper
- `Instantiate` → PackedScene.Instantiate
- `Destroy` → QueueFree
- `GetComponent<T>` → GetNode/GetChild helpers
- `Debug.Log/Warning/Error` → GD.Print

### Phase 2: Full NGUI Compatibility Layer
Implement every NGUI class used by the game:
- **UIWidget**: Base class for all NGUI widgets. Maps to Godot `Control`. Properties: width, height, alpha, color, pivot, depth, localToWorld, worldToLocal, cachedTransform, gameObject, GetComponent
- **UISprite**: Texture + atlas region. Maps to `TextureRect` with region rect. Supports `UISpriteData` for atlas lookups.
- **UILabel**: Text rendering. Maps to Godot `Label`. Supports `NGUIText.StripSymbols`, text wrapping, alignment, font size, gradient, effect (shadow/outline).
- **UIButton**: Clickable button. Maps to Godot `Button`. Supports `EventDelegate` for onClick, hover/normal/pressed colors, tween targeting.
- **UITexture**: Raw texture display. Maps to `TextureRect`.
- **UIPanel**: Clipping container. Maps to Godot `Panel` or `CanvasLayer`. Supports alpha, depth, clipping, draw calls.
- **UIScrollBar**: Maps to `ScrollContainer` with scrollbar.
- **UIProgressBar**: Maps to `ProgressBar`.
- **UIInput**: Maps to `LineEdit`.
- **UISlider**: Maps to `HSlider` / `VSlider`.
- **UIGrid** / **UITable**: Maps to `GridContainer`.
- **NGUITools**: `AddChild`, `SetActive`, `GetActive`, `screenSize`, `FindInParents`, `AddWidgetCollider`, `Destroy`, `DestroyImmediate`, `BringForward`, `SendBackward`, `MarkParentAsChanged`, `RegisterManagedWidget`
- **TweenPosition/TweenAlpha/TweenScale/TweenColor**: Map to Godot `Tween` animations.
- **UIRoot**: Resolution scaling logic.
- **UIAtlas** / **UISpriteData**: Atlas management → Godot `AtlasTexture` resources.
- **EventDelegate**: Multicast delegate system for UI callbacks.
- **UICamera**: Input event handling (NGUI event system → Godot Input signals).

### Phase 3: Nekki Framework Layer
- `NekkiUIRoot` → Singleton UI root with CanvasLayer
- `NekkiUIRootModules` → Module mount/unmount system
- `NekkiUIModule` → Base module with sprite/texture caching
- `NekkiUILabel` → Label with alias support
- `NekkiUISprite` → Sprite with no-image fallback
- `NekkiUITexture` → Texture extension
- `NekkiUIDialog` → Dialog panel management
- `NekkiUIElements` → Element lookup by alias
- `NekkiUICamera` → NGUI event camera → Godot Camera3D

### Phase 4: Third-Party Libraries
Copy source from Unity project (exact versions):
- `DOTween/` → Keep all 4 variants, compile as-is
- `UniRx/` (~200 files) → Reactive extensions
- `Newtonsoft.Json/` → JSON serialization
- `Google.Protobuf/` → Protocol Buffers
- `Ionic.Zip.Unity/` → ZIP compression
- `BouncyCastle/` → Cryptography (from TcpClientImplementation)
- `SmartFox2X/` → Stubbed (networking disabled)
- `Antlr3.Runtime/` → Stubbed (only used by JS engine)

### Phase 5: Data-only C# Classes (no engine deps)
Port all classes that have minimal or no MonoBehaviour dependency:
- ConstantsSF3, GameVariables, ClientSettings, InternalSettingsSF3
- Item, Equipment, Perk, WeaponTypes, Boosterpack
- Inventory, ShopItem, ShopManager (data layer only)
- UserDataController, Player, Account
- All DTOs (DtoExtensions, SF3TypesConvertExtentions)
- All interfaces (IEquipment, IPerk, IBattleInfo, etc.)
- All enums (EQuadrants, EWeaponType, etc.)
- All utility classes (JsonUtils, StringWrapper, CollectionExtensions)
- AnimationFrame, AnimationTransition, AnimationBinaries, MovesParser
- TriggerEventBase, all TriggerEvent types (~30)
- TriggerActionBase, all TriggerAction types (~60)
- Rule, FightRule, RoundRule, RulesController
- Tactics, TacticsBehaviorRegular, TacticsBehaviorTriggers
- ReactionAnalyzer, AiMode

### Phase 6: Animation Pipeline
- Use existing `AnimationBinaries.cs` / `MovesParser.cs` to deserialize `.bytes` at runtime
- Convert parsed animation frames into Godot `Animation` resources (or direct bone transforms)
- Build an `AnimationTree` with `AnimationNodeBlendTree` for state machine:
  - Idle, Walk, Run, Jump states
  - Attack states (punch, kick, weapon slash, etc.)
  - Hit/Block/Stagger states
  - Shadow form states
- Support animation blending between states
- Hook `ModelMoves.cs` to drive the AnimationTree

### Phase 7: Scene Setup
- **fight.tscn**: 
  - `Camera3D` (BattleCamera)
  - `WorldEnvironment` (fog, tonemap, ambient from `fight.scene.json`)
  - `DirectionalLight3D` + maybe `OmniLight3D`
  - Floor/location mesh (`.glb` from assets/locations/)
  - 2x `CharacterBody3D` for player + opponent
  - `Node3D` for effects (particles, trails)
  - `Control` HUD overlay (via NGUI compat layer)
  - `AnimationTree` for each character

- **MainMenu.tscn**:
  - Simple scene with "Start Fight" button
  - Load fight scene on click

### Phase 8: Battle System
- `BattleController` — scene entry point, initializes all systems
- `FightController` — round count, fight lifecycle
- `RoundController` — per-round logic, start/fight/end states
- `Model` — loads skin meshes & weapons from `.glb`, manages skeleton
- `ModelMoves` — drives animation based on current move
- `ModelCollision` — hitbox setup via Godot `Area3D`, collision detection
- `ModelPhysics` — physics integration, gravity, knockback
- `ModelHPStatus` — health, shadow energy, effects
- `BattleKeyManager` — action queuing (punch, kick, block, weapon, shadow)
- `KeyboardController` — input → game actions
- `BattleCamera` — camera with dolly zoom, shake, follow
- `HUD` / `BattleInterface` — health bars, shadow energy, action buttons, round indicator
- `AudioManager` — music + SFX via `AudioStreamPlayer`
- `EffectsManager` — hit effects, slow-mo, freeze frame, glow

### Phase 9: Asset Pipeline
| Source | Target | Action |
|--------|--------|--------|
| `.glb` (492) | `assets/models/` | Copy, set Godot import presets |
| `.png` (1,579) | `assets/textures/` | Copy |
| `.mp3` (337) | `assets/audio/` | Copy |
| `.ttf` (11) | `assets/fonts/` | Copy |
| `.bytes` animation (500) | `assets/animations/` | Copy (runtime import) |
| `.bytes` tactics (68) | `assets/tactics/` | Copy |
| `.json` configs | `assets/configs/` | Copy |
| `.asset` atlases (152) | — | Write converter → Godot AtlasTexture `.tres` |
| `.shader` Unity (42) | `assets/shaders/` | Manually rewrite as `.gdshader` |
| `.prefab` bones (139) | — | Manually rebuild as Godot PackedScene |
| `.mat` (65) | — | Convert to Godot ShaderMaterial |
| `.scene.json` (2) | `scenes/` | Manually create `.tscn` |

### Phase 10: Iteration & Testing
- Main menu with "Start Fight" button
- Hard-coded player loadout (weapon, armor, perks, shadow form)
- Hard-coded opponent loadout
- One playable fight: move, attack, block, dodge, take damage
- Round win/lose → restart option
- Debug console (Sf3ConsoleCommands) for variables, spawning, GodMode
- CLI args or config to skip menu and load fight directly

---

## Phase Dependencies

```
Phase 1 (GodotBehaviour)
    └─► Phase 2 (NGUI compat)
           └─► Phase 3 (Nekki Framework)
                  └─► Phase 4 (Libs)
                         └─► Phase 5 (Data classes)
                                ├─► Phase 6 (Animation)
                                ├─► Phase 7 (Scenes)
                                ├─► Phase 8 (Battle)
                                │      └─► All of above
                                └─► Phase 9 (Assets)
                                       └─► Phase 10 (Iteration)
```

---

## File Count Estimates by Phase

| Phase | Files | Est. Effort |
|-------|-------|-------------|
| 1. Core adapter | ~10 | Small |
| 2. NGUI compat | ~40 | Large |
| 3. Nekki framework | ~30 | Medium |
| 4. Third-party libs | ~800+ (copy) | Medium |
| 5. Data classes | ~300 | Medium |
| 6. Animation pipeline | ~20 | Medium |
| 7. Scene setup | ~5 | Small |
| 8. Battle system | ~80 | Large |
| 9. Asset pipeline | ~4,000 (copy) | Large |
| 10. Iteration | ~10 | Small |
