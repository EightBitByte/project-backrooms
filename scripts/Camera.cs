using Godot;
using System;

public partial class Camera : Camera2D
{
	[Export]
	float SafeArea = 300;

	CharacterBody2D tracking;
	double timeElapsed;
	Vector2 mousePos;

	public override void _Ready()
	{
		MakeCurrent();
		tracking = GetNode<CharacterBody2D>("../Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timeElapsed += delta;

		mousePos = GetGlobalMousePosition();
		timeElapsed = 0;

		Vector2 center = tracking.Position;


		Vector2 calcPosition = center - (center - mousePos)/2;

		// If the distance from the center is greater than the safe area, clamp to safe area
		if (calcPosition.DistanceTo(center) > SafeArea)
			;


		Position = calcPosition;

	}
}
