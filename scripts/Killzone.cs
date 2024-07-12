using Godot;
using System;

public partial class Killzone : Area2D
{
	private Timer _myTimer;
	
	public override void _Ready()
	{
		// get timer make it public
		_myTimer = GetNode<Timer>("Timer");
	}
	private void _on_body_entered(Node2D body)
	{
		Godot.GD.Print("You died!");
		Engine.TimeScale = 0.5f;
		body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
		_myTimer.Start();
	}
	private void _on_timer_timeout()
	{
		Engine.TimeScale = 1.0f;
		GetTree().ReloadCurrentScene();
	}
	
}




