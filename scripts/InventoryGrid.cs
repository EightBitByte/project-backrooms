using Godot;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

public partial class InventoryGrid : GridContainer
{
	TextureButton[] slots;
	bool[] slotIsOccupied = new bool[20];

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		slots = GetChildren().OfType<TextureButton>().ToArray();

		int slotNum = 0;
		foreach (TextureButton slot in slots) {
			int currentSlotNum = slotNum;
			Callable lambda = Callable.From(() => {PlaceItem(currentSlotNum);});
			
			slot.Connect("pressed", lambda, 0);
			++slotNum;
		}

	}

	private void PlaceItem(int slotNum) {
		GD.Print("Placing in slot ", slotNum);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
