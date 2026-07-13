---
name: Godot Vector3 property vs field trap
description: Why UnityEngine.Vector3.x/y/z in a Godot-backed compat shim can't be used as out/ref parameters, and how to work around it.
---

In a Unity→Godot compat shim, `UnityEngine.Vector3` is typically implemented as a wrapper struct holding an internal `Godot.Vector3`, with `x`/`y`/`z` exposed as computed properties (get/set that read/write the wrapped Godot vector). Real Unity's `Vector3.x/y/z` are plain public fields.

**Why this matters:** Any vendored Unity code that does `SomeMethod(out vector.x, ...)` or `ref vector.y` compiles fine against real Unity (fields support `ref`/`out`) but fails with CS0206 ("non ref-returning property... may not be used as an out or ref value") against the compat shim, because properties can't be passed by `ref`/`out`.

**How to apply:** Don't try to make `x`/`y`/`z` real fields — that requires abandoning the Godot-vector backing used everywhere else and is too invasive. Instead, at the specific call site, introduce local `float` variables for each component, pass those by `out`/`ref`, then construct the `Vector3` from them afterward. This was needed for a handful of isolated call sites (e.g. a YAML-driven camera-shake trigger reading `AmpX`/`AmpY`/`AmpZ` into a `Vector3` field) — not worth a shim-wide fix.
