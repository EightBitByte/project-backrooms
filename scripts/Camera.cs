using Godot;
using System;

public partial class Camera : Camera2D
{
	[Export]
	float SafeArea = 200;

	CharacterBody2D tracking;
	double timeElapsed;
	Vector2 mousePos;
	Vector2 viewportCenter;

	bool inventoryOpen;

	public override void _Ready()
	{
		MakeCurrent();
		tracking = GetNode<CharacterBody2D>("/root/Main Scene/Player");
		inventoryOpen = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// If viewport was resized since last frame, update center
		viewportCenter = GetViewportRect().Size / 2;

		// If inventory is opened, stop moving the camera and center it on char
		if (Input.IsActionJustPressed("ui_inventory")) {
			inventoryOpen = !inventoryOpen;
			Position = tracking.Position;
		}

		Vector2 center = tracking.Position;
		mousePos = GetViewport().GetMousePosition() - viewportCenter;

		Vector2 calcPosition = center + mousePos;

		// If the camera's distance from the center is greater than the safe area, 
		// clamp to safe area
		if (Math.Abs(mousePos.X) >= SafeArea)
			calcPosition.X = mousePos.X > 0 ? center.X + SafeArea : center.X - SafeArea;

		if (Math.Abs(mousePos.Y) >= SafeArea)
			calcPosition.Y = mousePos.Y > 0 ? center.Y + SafeArea : center.Y - SafeArea;
			
		Position = inventoryOpen ? Position : calcPosition;
	}
}
