using Godot;
using System;

public partial class pkmntc : Node
{
	enum Types {
		Normal,
		Fighting,
		Flying,
		Poison,
		Ground,
		Rock,
		Bug,
		Ghost,
		Steel,
		Fire,
		Water,
		Grass,
		Electric,
		Psychic,
		Ice,
		Dragon,
		Dark,
		Fairy,
	}

	private static int numTypes = Enum.GetNames(typeof(Types)).Length;
	private ImageTexture[] icons = new ImageTexture[numTypes];

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get the nodes we need to prepare
		OptionButton option = GetNode<OptionButton>("Tabs/Attacking/Vbox/Center/TypeSelect/OptionButton");

		// Load the type icons
		for (int i = 0; i < numTypes; i++) {
			// Create TextureImages for a type
			string name = Enum.GetName(typeof(Types), i);
			string path = "images/" + name.ToLower() + ".png";
			var image = Image.LoadFromFile(path);
			icons[i] = ImageTexture.CreateFromImage(image);

			// Add it to type selectors
			option.AddIconItem(icons[i], "");
		}

		// Fill in the type options
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
