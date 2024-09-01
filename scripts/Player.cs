using System;
using Godot;

public partial class Player : CharacterBody2D
{
	[Export]
	public float MomentumRetained = 0.92f;

	[Export]
	public float StopThreshold { get; set; } = 0.3f;

	[Export]
	public int Speed { get; set; } = 200;


	private Vector2 calcVelocity = Vector2.Zero;
	private bool inventoryOpen = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _PhysicsProcess(double delta)
    {
		Vector2 moveDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		calcVelocity.X = moveDirection.X != 0 ? moveDirection.X : calcVelocity.X;
		calcVelocity.Y = moveDirection.Y != 0 ? moveDirection.Y : calcVelocity.Y;

		if (Input.IsActionJustPressed("ui_inventory"))
			inventoryOpen = !inventoryOpen;

		// If no keys are held, slowly slow down the player
		if (moveDirection.Y == 0 && moveDirection.X == 0) {
			calcVelocity.Y *= Math.Abs(calcVelocity.Y) < StopThreshold ? 0 : MomentumRetained;
			calcVelocity.X *= Math.Abs(calcVelocity.X) < StopThreshold ? 0 : MomentumRetained;

		// Otherwise, if we are holding move in one axis but not the other, stop moving in that other axis immediately
		} else if (moveDirection.X != 0 && moveDirection.Y == 0) {
			calcVelocity.Y = 0;
		}
		else if (moveDirection.X == 0 && moveDirection.Y != 0) {
			calcVelocity.X = 0;
		}

		if (!inventoryOpen) {
			Velocity = calcVelocity * Speed;
			MoveAndSlide();
		}
    }
}

