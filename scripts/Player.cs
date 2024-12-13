using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public double Speed = 300.0;
    [Export] public  double JumpVelocity = -400.0;
    [Export] private double maxCharge = 1.0; // Max charge duration (in seconds)
    [Export] private double minJumpForce = 200.0;

    private bool isChargingJump = false;
    private double chargeTimer = 0.0;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        // Handle jump charging and releasing.
        if (Input.IsActionJustPressed("ui_accept"))
        {
            isChargingJump = true;
            chargeTimer = 0.0;
        }

        if (isChargingJump && Input.IsActionPressed("ui_accept"))
        {
            chargeTimer += delta;
            chargeTimer = Math.Min(chargeTimer, maxCharge);
        }

        if (Input.IsActionJustReleased("ui_accept") && IsOnFloor())
        {
            double chargeRatio = chargeTimer / maxCharge;
            double jumpForce = Mathf.Lerp((float)minJumpForce, (float)JumpVelocity, (float)chargeRatio);
            velocity.Y = (float)jumpForce;
            isChargingJump = false;
        }

        // Get the input direction and handle the movement/deceleration.
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * (float)Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, (float)Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}