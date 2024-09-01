using Godot;
using System;

public partial class Inventory : Sprite2D
{
	PackedScene INVENTORY_ITEM = GD.Load<PackedScene>("res://InventoryItem.tscn");
	Vector2 baseCoords = Vector2.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		baseCoords = GetNode<GridContainer>("./Inventory Grid").Position;

		CenterContainer newItem = INVENTORY_ITEM.Instantiate<CenterContainer>();
		AddChild(newItem);
		newItem.Position = baseCoords;

		Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_inventory")) {
			Input.WarpMouse(GetViewportRect().Size / 2);

			// Do magic here

			Visible = !Visible;
		}
	}
}
