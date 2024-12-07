using Godot;
using System;

public partial class Icon : Sprite2D

{
    public float speed = 5;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
            // Vector to hold the direction of movement
        Vector2 movement = Vector2.Zero;

        // Check for input using the default input map for WASD or arrow keys
        if (Input.IsKeyPressed(Key.W))
        {
            movement.Y -= speed; // Move up
        }
        if (Input.IsKeyPressed(Key.S))
        {
            movement.Y += speed; // Move down
        }
        if (Input.IsKeyPressed(Key.A))
        {
            movement.X -= speed; // Move left
        }
        if (Input.IsKeyPressed(Key.D))
        {
            movement.X += speed; // Move r
        }
        // Move the sprite
        Position += movement;
    }
}