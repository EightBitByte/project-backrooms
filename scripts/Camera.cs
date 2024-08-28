using Godot;
using System;

public partial class Camera : Camera2D
{
	CharacterBody2D tracking;

	public override void _Ready()
	{
		MakeCurrent();
		tracking = GetNode<CharacterBody2D>("../Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = tracking.Position;
	}
}
