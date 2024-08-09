using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	CharacterBody2D player;
	Vector2 velocity;

	[Export]
	float speed = 0.75f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<CharacterBody2D>("../Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (player.GlobalPosition.X > Position.X) {
			velocity.X = speed;
		}

		if (player.GlobalPosition.X < Position.X) {
			velocity.X = speed * -1;
		}

		if (player.GlobalPosition.Y > Position.Y) {
			velocity.Y = speed;
		}

		if (player.GlobalPosition.Y < Position.Y) {
			velocity.Y = speed * -1;
		}

		Position += velocity;
	}
}
