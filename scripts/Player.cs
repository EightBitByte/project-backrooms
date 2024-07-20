using Godot;
using System;

public partial class Player : Sprite2D
{
	Vector2 velocity;

	[Export]
	public float SlowdownMult = 0.95f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var velocity = Vector2.Zero;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.

	// NOTE: I'm not sure as of yet, but this current movement system (I assume) 
	// makes those with higher framerates faster. Look into using deltatime.
	public override void _Process(double delta)
	{
		bool horizKeyDown = false, vertKeyDown = false;

		// Handling movement input
		if (Input.IsActionPressed("ui_left")) {
			velocity.X = -1;
			horizKeyDown = true;
		}
		if (Input.IsActionPressed("ui_right")) {
			velocity.X = 1;
			horizKeyDown = true;
		}
		if (Input.IsActionPressed("ui_up")) {
			velocity.Y = -1;
			vertKeyDown = true;
		}
		if (Input.IsActionPressed("ui_down")) {
			velocity.Y = 1;
			vertKeyDown = true;
		}

		// Slow down the velocity until below a threshold to stop

		// Ensuring skid-stop doesn't occur along other axis if we're still moving
		if (!vertKeyDown && !horizKeyDown) {
			velocity.Y *= Math.Abs(velocity.Y) < 0.2 ? 0 : SlowdownMult;
		} else if (!vertKeyDown && horizKeyDown) {
			velocity.Y = 0;
		}

		if (!horizKeyDown && !vertKeyDown) {
			velocity.X *= Math.Abs(velocity.X) < 0.2 ? 0 : SlowdownMult;
		} else if (!horizKeyDown && vertKeyDown) {
			velocity.Y = 0;
		}

		// Apply velocity to object position
		Position += velocity;
	}
}
