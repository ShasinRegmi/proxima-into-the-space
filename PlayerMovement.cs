using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	public const float WalkSpeed = 300.0f;
	public const float Gravity = 500.0f;
	public const float JumpSpeed = -300f;


	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;

		// handle gravity
		if(!IsOnFloor()){
			velocity.Y += (float)delta * Gravity;
		}


		// handle jump
		if(Input.IsActionPressed("jump") && IsOnFloor()){
			velocity.Y = JumpSpeed;
		}
		if(Input.IsActionPressed("ui_left")){
			velocity.X = -WalkSpeed;
		}
		
		else if(Input.IsActionPressed("ui_right")){
			velocity.X = WalkSpeed;
		}

		else{
			velocity.X = 0;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
