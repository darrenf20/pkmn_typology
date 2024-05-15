using Godot;
using System;
using System.Collections;
using static TypeChart;

public partial class Gui : Node
{
	private static ImageTexture[] icons = new ImageTexture[TypeChart.numTypes];
	private static Hashtable outputTable = new Hashtable();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get the nodes we need to prepare
		OptionButton option = GetNode<OptionButton>("%TypeButton");

		var output = GetNode("%Output");
		outputTable.Add(4.00f, output.GetNode("X4_1/Panel/List"));
		outputTable.Add(2.00f, output.GetNode("X2_1/Panel/List"));
		outputTable.Add(1.00f, output.GetNode("X1_1/Panel/List"));
		outputTable.Add(0.50f, output.GetNode("X1_2/Panel/List"));
		outputTable.Add(0.25f, output.GetNode("X1_4/Panel/List"));
		outputTable.Add(0.00f, output.GetNode("X0_1/Panel/List"));

		// Load the type icons
		for (var i = 0; i < TypeChart.numTypes; i++)
		{
			// Create TextureImages for a type
			string name = Enum.GetName(typeof(TypeChart.Type), i);
			string path = "images/" + name.ToLower() + ".png";
			var image = Image.LoadFromFile(path);
			icons[i] = ImageTexture.CreateFromImage(image);

			// Add it to type selectors
			option.AddIconItem(icons[i], "");
		}

		// Remove radio buttons next to icons
		var popup = option.GetPopup();
		for (var i = 0; i < numTypes; i++)
		{
			popup.SetItemAsRadioCheckable(i, false);
		}

		// Fill in the type options
		UpdateOutput();
	}

	private void UpdateOutput()
	{
		foreach (ItemList list in outputTable.Values)
		{
			list.Clear();
		}

		var selectedType = (TypeChart.Type)GetNode<OptionButton>("%TypeButton").GetSelectedId();

		// Start with single types
		for (var i = 0; i < TypeChart.numTypes; i++)
		{
			ImageTexture firstIcon = icons[i];
			var modifier = TypeChart.GetModifier(selectedType, (TypeChart.Type)i);
			var list = outputTable[modifier] as ItemList;
			list.AddIconItem(firstIcon, false);
			list.AddIconItem(null, false); // Fill in empty slot of second column

			// Go over the dual typings
			for (var j = i + 1; j < TypeChart.numTypes; j++)
			{
				ImageTexture secondIcon = icons[j];
				var modifier2 = modifier * TypeChart.GetModifier(selectedType, (TypeChart.Type)j);
				list = outputTable[modifier2] as ItemList;
				list.AddIconItem(firstIcon, false);
				list.AddIconItem(secondIcon, false);
			}
		}

		// Show how many entries are in each list
		foreach (ItemList list in outputTable.Values)
		{
			var count = list.ItemCount / 2;
			list.GetNode<Label>("../../Head/Count").Text = "(" + count + ") ";
		}
	}

	private void _on_type_button_item_selected(long index)
	{
		UpdateOutput();
	}
}


