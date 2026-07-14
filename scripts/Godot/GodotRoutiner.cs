using System.Collections;
using System.Collections.Generic;
using Godot;

public partial class GodotRoutiner : Node
{
    private static GodotRoutiner _instance;
    private List<IEnumerator> _routines = new List<IEnumerator>();

    public override void _Ready()
    {
        _instance = this;
        ProcessMode = ProcessModeEnum.Always;
    }

    public override void _Process(double delta)
    {
        for (int i = _routines.Count - 1; i >= 0; i--)
        {
            var routine = _routines[i];
            var current = routine.Current;
            if (current is UnityEngine.CustomYieldInstruction cyi)
            {
                if (cyi.keepWaiting) continue;
            }
            else if (current is UnityEngine.WaitForSeconds wfs)
            {
                if (wfs.keepWaiting) continue;
            }
            else if (current is UnityEngine.AsyncOperation)
            {
                continue;
            }
            if (!routine.MoveNext())
                _routines.RemoveAt(i);
        }
    }

    public static void Go(IEnumerator routine)
    {
        if (routine != null && _instance != null)
            _instance._routines.Add(routine);
    }
}
