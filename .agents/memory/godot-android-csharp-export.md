---
name: Godot C#/.NET Android export requires Gradle build
description: Why "Exporting to Android when using C#/.NET is experimental" blocks CI Android exports in Godot 4.x Mono projects, and how to fix it headlessly.
---

Godot 4.x refuses to export a C#/.NET (Mono) project to Android unless the
export preset has Gradle build enabled (`gradle_build/use_gradle_build=true`
in `export_presets.cfg`). With it left `false` (the default when a preset is
first created), export fails with:
`ERROR: Cannot export project with preset "Android" due to configuration
errors: Exporting to Android when using C#/.NET is experimental.`
This is unrelated to whether Godot "supports" Android for C# — it does; the
preset just isn't configured for it.

**Why:** the pre-built APK export templates don't bundle the .NET/Mono
runtime glue; only the Gradle-based Android build (a Java/Kotlin project
Godot generates under `res://android/build`) can assemble a working C# APK.

**How to apply:** in `export_presets.cfg`, set
`gradle_build/use_gradle_build=true` (plus reasonable `min_sdk`/`target_sdk`).
In headless/CI contexts there's no GUI "Install Android Build Template" menu
item; use the `--install-android-build-template` CLI flag (added in Godot 4.3
via PR godotengine/godot#85819). That flag only takes effect when passed on
the *same* invocation as `--export-debug`/`--export-release` — it's read by
`main.cpp` into a variable that's only consumed inside the export codepath,
so a separate standalone `--install-android-build-template --quit` run is a
no-op. Combine them: `godot --headless --install-android-build-template
--export-debug "Android" out.apk` (this same command implicitly sets editor
mode, so `--editor` isn't needed here).

A second, separate silent failure mode: Android/mobile export requires the
project setting `rendering/textures/vram_compression/import_etc2_astc=true`
in `project.godot`. If it's unset, `has_valid_project_configuration()` in
Godot's Android export plugin returns false with **no error message at
all** (unlike every other config problem, which prints a reason) — the log
just shows the generic "Exporting to Android when using C#/.NET is
experimental" advisory line and then a bare export failure. Source:
`ResourceImporterTextureSettings::should_import_etc2_astc()` /
`EditorExportPlatformAndroid::has_valid_project_configuration()`.
