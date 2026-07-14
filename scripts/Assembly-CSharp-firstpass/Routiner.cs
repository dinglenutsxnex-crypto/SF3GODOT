using System;
using System.Collections;
using UnityEngine;

public partial class Routiner
{
	public static void Init()
	{
	}

	public static Coroutine Go(IEnumerator routine)
	{
		GodotRoutiner.Go(routine);
		return null;
	}

	public static void AddUpdate(Action action)
	{
	}

	public static void Stop(Coroutine routine)
	{
	}

	public static Coroutine GoDelayed(Action action, float delay)
	{
		Go(WaitForRealSeconds(delay, action));
		return null;
	}

	private static IEnumerator WaitForRealSeconds(float delay, Action action)
	{
		double start = Godot.Time.GetTicksMsec() / 1000.0;
		while ((Godot.Time.GetTicksMsec() / 1000.0) <= start + delay + 0.0001f)
		{
			yield return null;
		}
		action();
	}

	public static Coroutine GoDelayed(IEnumerator routine, float delay)
	{
		Go(WaitForRealSeconds(delay, routine));
		return null;
	}

	private static IEnumerator WaitForRealSeconds(float delay, IEnumerator routine)
	{
		double start = Godot.Time.GetTicksMsec() / 1000.0;
		while ((Godot.Time.GetTicksMsec() / 1000.0) <= start + delay + 0.0001f)
		{
			yield return null;
		}
		while (routine.MoveNext())
		{
			yield return routine.Current;
		}
	}
}
