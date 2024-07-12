using Godot;
using System;

public partial class Killzone : Area2D
{
	private void _on_body_entered(Node2D body)
	{
		Godot.GD.Print("You died!");
	}
}


