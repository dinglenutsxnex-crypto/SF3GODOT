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
item, so run `godot --headless --install-android-build-template --quit`
before the `--export-debug`/`--export-release` step (CLI flag added in Godot
4.3 via PR godotengine/godot#85819; source: `main/main.cpp`, look for
`install_android_build_template`).
