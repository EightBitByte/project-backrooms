using Godot;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

public partial class InventoryGrid : GridContainer
{
	[Signal]
	public delegate void KillPreviewEventHandler();

	PackedScene INVENTORY_ITEM = GD.Load<PackedScene>("res://scenes/InventoryItem.tscn");
	Sprite2D INVENTORY_ROOT;
	TextureButton[] slots;
	bool[] slotIsOccupied = new bool[20];
	Godot.Collections.Array<CenterContainer> Items;

	private enum Item {
		GreyThermos,
		GreenThermos,
		RedThermos,
		BlueThermos
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Connect slot click signals to method
		slots = GetChildren().OfType<TextureButton>().ToArray();

		int slotNum = 0;
		foreach (TextureButton slot in slots) {
			int currentSlotNum = slotNum;
			Callable lambda = Callable.From(() => {PlaceItem(currentSlotNum);});
			
			slot.Connect("pressed", lambda, 0);
			++slotNum;
		}

		// Get and hide inventory root
		INVENTORY_ROOT = GetParent<Sprite2D>();
		INVENTORY_ROOT.Visible = false;
	}

	private void PlaceItem (int slotNum) {
		GD.Print("Placing in slot ", slotNum);
	}

	private void PickupItem (int itemIndex) {
		GD.Print("Picking up item ", itemIndex);
	}

	private void AddNewItem (Item item) {
		Texture2D itemSprite = null;

		switch (item) {
			case Item.GreyThermos:
				itemSprite = GD.Load<Texture2D>("res://assets/thermos_grey.svg");
				break;

			case Item.GreenThermos:
				itemSprite = GD.Load<Texture2D>("res://assets/thermos_green.svg");
				break;
				
			case Item.RedThermos:
				itemSprite = GD.Load<Texture2D>("res://assets/thermos_red.svg");
				break;

			case Item.BlueThermos:
				itemSprite = GD.Load<Texture2D>("res://assets/thermos_blue.svg");
				break;
			
		}

		// Make new item and add child to inventory root
		CenterContainer newItem = INVENTORY_ITEM.Instantiate<CenterContainer>();
		INVENTORY_ROOT.AddChild(newItem);

		//NOTE: Will need to find first available position to place item instead of overlapping
		newItem.Position = Position;
		newItem.GetChild<TextureButton>(0).GetChild<Sprite2D>(0).Texture = itemSprite;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_inventory")) {
			Input.WarpMouse(GetViewportRect().Size / 2);
			INVENTORY_ROOT.Visible = !INVENTORY_ROOT.Visible;
		}

		if (Input.IsActionJustPressed("ui_accept")) {
			AddNewItem(Item.RedThermos);
		}
	}
}
