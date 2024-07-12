using Godot;
using System;

public partial class Slime : Node2D
{
	private const float Speed = 60;
	private int _direction = 1;
	private RayCast2D _myRayCastRight;
	private RayCast2D _myRayCastLeft;
	private AnimatedSprite2D _myAnimatedSprite;
	public override void _Ready()
	{
		_myRayCastRight = GetNode<RayCast2D>("RayCastRight");
		_myRayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		_myAnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_myRayCastRight.IsColliding())
		{
			_direction = -1;
			_myAnimatedSprite.FlipH = true;
		}
		else if (_myRayCastLeft.IsColliding())
		{
			_direction = 1;
			_myAnimatedSprite.FlipH = false;
		}

		Position = Position with { X = Position.X + _direction * Speed * (float)delta };
	}
}
