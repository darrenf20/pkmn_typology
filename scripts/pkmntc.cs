using Godot;
using System;
using static TypeChart;

public partial class pkmntc : Node
{
	private static ImageTexture[] icons = new ImageTexture[TypeChart.numTypes];

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Fill in the type type chart
		for (var i = 0; i < typeChart.GetLength(0); i++)
		{
			for (var j = 0; j < typeChart.GetLength(1); j++)
			{
				typeChart[i, j] = 1;
			}
		}


		// Get the nodes we need to prepare
		OptionButton option = GetNode<OptionButton>("%TypeButton");

		// Load the type icons
		for (var i = 0; i < numTypes; i++)
		{
			// Create TextureImages for a type
			string name = Enum.GetName(typeof(TypeChart.Types), i);
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

	public void UpdateOutput()
	{
		var output = GetNode<HFlowContainer>("%Output");

		foreach (Node node in output.GetChildren()) {
			var list = node.GetNode<VBoxContainer>("Panel/Scroll/List");
			
			for (var i = 0; i < 20; i++)
			{
				var label = new Label();
				label.Text = "Test";
				list.AddChild(label);
			}
		}
	}
}
