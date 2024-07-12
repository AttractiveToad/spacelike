using Godot;
using System;

public partial class Killzone : Area2D
{
	public override void _Ready()
	{
		// get note timer
		Timer myTimer = GetNode<Timer>("Timer");
	}
	
	private void _on_body_entered(Node2D body)
	{
		Godot.GD.Print("You died!")
	}
}


