using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;
	private AnimatedSprite2D _myAnimatedSprite;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		_myAnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		
		// Flip the sprite based on the direction.
		if (direction > Vector2.Zero)
			_myAnimatedSprite.FlipH = false;
		else if (direction < Vector2.Zero)
			_myAnimatedSprite.FlipH = true;
		
		// Play various animations.
		if (IsOnFloor())
			_myAnimatedSprite.Play(direction == Vector2.Zero ? "idle" : "run");
		else
			_myAnimatedSprite.Play("jump");
		
		// Move the player.
		if (direction != Vector2.Zero)
			velocity.X = direction.X * Speed;
		else
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
