using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	public const float WalkSpeed = 400.0f;
	public  float Gravity = 2500.0f;
	public bool hasJumped = false;
	public const float JumpSpeed = -920f;


	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;
		

		// handle gravity
		if(!IsOnFloor()){
			// Character falls faster after jump
			if(hasJumped){
				Gravity = 5500.0f;
			}
			velocity.Y += (float)delta * Gravity;
		}


		// handle jump
		if(Input.IsActionPressed("jump") && IsOnFloor()){
			velocity.Y = JumpSpeed;
			hasJumped = true;
			
		}
		else{
			hasJumped = false;
			Gravity = 2500.0f;
		}
		if(Input.IsActionPressed("move_left")){
			velocity.X = -WalkSpeed;
			
		}
		
		else if(Input.IsActionPressed("move_right")){
			
			velocity.X = WalkSpeed;
			
		}

		else{
			velocity.X = 0;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
