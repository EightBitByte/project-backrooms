using Godot;
using System;

public partial class Item : TextureButton
{
	PackedScene ITEM_PREVIEW = GD.Load<PackedScene>("res://DragPreview.tscn");
	Node2D PreviewParent;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += ItemClick;
		PreviewParent = GetNode<Node2D>("/root/Main Scene/Camera/CanvasLayer/Inventory");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void ItemClick() {
		Sprite2D preview = ITEM_PREVIEW.Instantiate<Sprite2D>();
		PreviewParent.AddChild(preview);

		// Modify item's opacity
		Color opacity = Modulate;
		opacity.A = 0.5f;
		Modulate = opacity;
	}

}
