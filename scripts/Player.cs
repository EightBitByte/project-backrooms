using Godot;
using System;

public partial class Player : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;

		// Handling movement input
		if (Input.IsActionPressed("ui_left")) {
			velocity.X -= 1;
		}
		if (Input.IsActionPressed("ui_right")) {
			velocity.X += 1;
		}
		if (Input.IsActionPressed("ui_up")) {
			velocity.Y -= 1;
		}
		if (Input.IsActionPressed("ui_down")) {
			velocity.Y += 1;
		}

		Position += velocity;
	}
}
