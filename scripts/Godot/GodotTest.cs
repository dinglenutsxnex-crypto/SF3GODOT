using Godot;
using System;

public partial class GodotTest : Node
{
	public override void _Ready()
	{
		GD.Print("GodotTest._Ready() called! Time=" + Time.GetTicksMsec());
	}
}