using Godot;
using System;

public partial class Coin : Area2D
{
	private GameManager _myGameManager;
	private AnimationPlayer _myAnimationPlayer;
	
	public override void _Ready()
	{
		_myGameManager = GetNode<GameManager>("%GameManager");
		_myAnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}
	private void _on_body_entered(Node2D body)
	{
		_myGameManager.AddPoint();
		_myAnimationPlayer.Play("pickup");
	}
}



