using Godot;
using System;
using static InventoryGrid;

public partial class DragPreview : Sprite2D
{
	Vector2 center, mousePos;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition = GetGlobalMousePosition();
	}
}
