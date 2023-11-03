using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed = 150f;
	[Export]
	public float JumpVelocity = -200f;
	[Export]
	public float DoubleJumpVelocity = -150f;

	[Export]
	public Sprite2D Sprite = null;
	public Boolean HasDoubleJumped = false;
	public Vector2 direction;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _PhysicsProcess(double delta)
	{
		GetInputDirection(delta);
		UpdateFacingDirection();
		MoveAndSlide();
		Shoot();
	}

	public void GetInputDirection(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
		}
		else
		{
			HasDoubleJumped = false;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump"))
		{
			if(IsOnFloor())
			{
				velocity.Y = JumpVelocity;
			}
			else if (!HasDoubleJumped)
			{
				velocity.Y = DoubleJumpVelocity;
				HasDoubleJumped = true;
			}
		}

		direction = Input.GetVector("left", "right", "up", "down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
	}

	public void UpdateFacingDirection()
	{
		if(direction.X > 0)
		{
			Sprite.FlipH = false;
		}
		else if(direction.X < 0)
		{
			Sprite.FlipH = true;
		}
	}

	public void Shoot()
	{
		if(Input.IsActionJustPressed("shoot"))
		{
			GD.Print("Atirar!");
		}
		
	}
}
