using System;

public static class TypeChart {
	public enum Type {
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

	public static int numTypes = Enum.GetNames(typeof(Type)).Length;
	private static float[,] grid = new float[numTypes, numTypes];

	// Initializes the type chart
	static TypeChart()
	{
		// Give every cell a default value of 1
		for (var i = 0; i < grid.GetLength(0); i++)
		{
			for (var j = 0; j < grid.GetLength(1); j++)
			{
				grid[i, j] = 1.0f;
			}
		}

		// Set the damage modifiers for each type
		// Type chart format: grid[AttackingType, DefendingType]
		grid[(int)Type.Normal, (int)Type.Rock]  = 0.5f;
		grid[(int)Type.Normal, (int)Type.Ghost] = 0.0f;
		grid[(int)Type.Normal, (int)Type.Steel] = 0.5f;

		grid[(int)Type.Fighting, (int)Type.Normal]  = 2.0f;
		grid[(int)Type.Fighting, (int)Type.Flying]  = 0.5f;
		grid[(int)Type.Fighting, (int)Type.Poison]  = 0.5f;
		grid[(int)Type.Fighting, (int)Type.Rock]    = 2.0f;
		grid[(int)Type.Fighting, (int)Type.Bug]     = 0.5f;
		grid[(int)Type.Fighting, (int)Type.Ghost]   = 0.0f;
		grid[(int)Type.Fighting, (int)Type.Steel]   = 2.0f;
		grid[(int)Type.Fighting, (int)Type.Psychic] = 0.5f;
		grid[(int)Type.Fighting, (int)Type.Ice]     = 2.0f;
		grid[(int)Type.Fighting, (int)Type.Dark]    = 2.0f;
		grid[(int)Type.Fighting, (int)Type.Fairy]   = 0.5f;

		grid[(int)Type.Flying, (int)Type.Fighting] = 2.0f;
		grid[(int)Type.Flying, (int)Type.Rock]     = 0.5f;
		grid[(int)Type.Flying, (int)Type.Bug]      = 2.0f;
		grid[(int)Type.Flying, (int)Type.Steel]    = 0.5f;
		grid[(int)Type.Flying, (int)Type.Grass]    = 2.0f;
		grid[(int)Type.Flying, (int)Type.Electric] = 0.5f;

		grid[(int)Type.Poison, (int)Type.Poison] = 0.5f;
		grid[(int)Type.Poison, (int)Type.Ground] = 0.5f;
		grid[(int)Type.Poison, (int)Type.Rock]   = 0.5f;
		grid[(int)Type.Poison, (int)Type.Ghost]  = 0.5f;
		grid[(int)Type.Poison, (int)Type.Steel]  = 0.0f;
		grid[(int)Type.Poison, (int)Type.Grass]  = 2.0f;
		grid[(int)Type.Poison, (int)Type.Fairy]  = 2.0f;

		grid[(int)Type.Ground, (int)Type.Flying]   = 0.0f;
		grid[(int)Type.Ground, (int)Type.Poison]   = 2.0f;
		grid[(int)Type.Ground, (int)Type.Rock]     = 2.0f;
		grid[(int)Type.Ground, (int)Type.Bug]      = 0.5f;
		grid[(int)Type.Ground, (int)Type.Steel]    = 2.0f;
		grid[(int)Type.Ground, (int)Type.Fire]     = 2.0f;
		grid[(int)Type.Ground, (int)Type.Grass]    = 0.5f;
		grid[(int)Type.Ground, (int)Type.Electric] = 2.0f;

		grid[(int)Type.Rock, (int)Type.Fighting] = 0.5f;
		grid[(int)Type.Rock, (int)Type.Flying]   = 2.0f;
		grid[(int)Type.Rock, (int)Type.Ground]   = 0.5f;
		grid[(int)Type.Rock, (int)Type.Bug]      = 2.0f;
		grid[(int)Type.Rock, (int)Type.Steel]    = 0.5f;
		grid[(int)Type.Rock, (int)Type.Fire]     = 2.0f;
		grid[(int)Type.Rock, (int)Type.Ice]      = 2.0f;

		grid[(int)Type.Bug, (int)Type.Fighting] = 0.5f;
		grid[(int)Type.Bug, (int)Type.Flying]   = 0.5f;
		grid[(int)Type.Bug, (int)Type.Poison]   = 0.5f;
		grid[(int)Type.Bug, (int)Type.Ghost]    = 0.5f;
		grid[(int)Type.Bug, (int)Type.Steel]    = 0.5f;
		grid[(int)Type.Bug, (int)Type.Fire]     = 0.5f;
		grid[(int)Type.Bug, (int)Type.Grass]    = 2.0f;
		grid[(int)Type.Bug, (int)Type.Psychic]  = 2.0f;
		grid[(int)Type.Bug, (int)Type.Dark]     = 2.0f;
		grid[(int)Type.Bug, (int)Type.Fairy]    = 0.5f;

		grid[(int)Type.Ghost, (int)Type.Normal]  = 0.0f;
		grid[(int)Type.Ghost, (int)Type.Ghost]   = 2.0f;
		grid[(int)Type.Ghost, (int)Type.Psychic] = 2.0f;
		grid[(int)Type.Ghost, (int)Type.Dark]    = 0.5f;

		grid[(int)Type.Steel, (int)Type.Rock]     = 2.0f;
		grid[(int)Type.Steel, (int)Type.Steel]    = 0.5f;
		grid[(int)Type.Steel, (int)Type.Fire]     = 0.5f;
		grid[(int)Type.Steel, (int)Type.Water]    = 0.5f;
		grid[(int)Type.Steel, (int)Type.Electric] = 0.5f;
		grid[(int)Type.Steel, (int)Type.Ice]      = 2.0f;
		grid[(int)Type.Steel, (int)Type.Fairy]    = 2.0f;

		grid[(int)Type.Fire, (int)Type.Rock]   = 0.5f;
		grid[(int)Type.Fire, (int)Type.Bug]    = 2.0f;
		grid[(int)Type.Fire, (int)Type.Steel]  = 2.0f;
		grid[(int)Type.Fire, (int)Type.Fire]   = 0.5f;
		grid[(int)Type.Fire, (int)Type.Water]  = 0.5f;
		grid[(int)Type.Fire, (int)Type.Grass]  = 2.0f;
		grid[(int)Type.Fire, (int)Type.Ice]    = 2.0f;
		grid[(int)Type.Fire, (int)Type.Dragon] = 0.5f;

		grid[(int)Type.Water, (int)Type.Ground] = 2.0f;
		grid[(int)Type.Water, (int)Type.Rock]   = 2.0f;
		grid[(int)Type.Water, (int)Type.Fire]   = 2.0f;
		grid[(int)Type.Water, (int)Type.Water]  = 0.5f;
		grid[(int)Type.Water, (int)Type.Grass]  = 0.5f;
		grid[(int)Type.Water, (int)Type.Dragon] = 0.5f;

		grid[(int)Type.Grass, (int)Type.Flying] = 0.5f;
		grid[(int)Type.Grass, (int)Type.Poison] = 0.5f;
		grid[(int)Type.Grass, (int)Type.Ground] = 2.0f;
		grid[(int)Type.Grass, (int)Type.Rock]   = 2.0f;
		grid[(int)Type.Grass, (int)Type.Bug]    = 0.5f;
		grid[(int)Type.Grass, (int)Type.Steel]  = 0.5f;
		grid[(int)Type.Grass, (int)Type.Fire]   = 0.5f;
		grid[(int)Type.Grass, (int)Type.Water]  = 2.0f;
		grid[(int)Type.Grass, (int)Type.Grass]  = 0.5f;
		grid[(int)Type.Grass, (int)Type.Dragon] = 0.5f;

		grid[(int)Type.Electric, (int)Type.Flying]   = 2.0f;
		grid[(int)Type.Electric, (int)Type.Ground]   = 0.0f;
		grid[(int)Type.Electric, (int)Type.Water]    = 2.0f;
		grid[(int)Type.Electric, (int)Type.Grass]    = 0.5f;
		grid[(int)Type.Electric, (int)Type.Electric] = 0.5f;
		grid[(int)Type.Electric, (int)Type.Dragon]   = 0.5f;

		grid[(int)Type.Psychic, (int)Type.Fighting] = 2.0f;
		grid[(int)Type.Psychic, (int)Type.Poison]   = 2.0f;
		grid[(int)Type.Psychic, (int)Type.Steel]    = 0.5f;
		grid[(int)Type.Psychic, (int)Type.Psychic]  = 0.5f;
		grid[(int)Type.Psychic, (int)Type.Dark]     = 0.0f;

		grid[(int)Type.Ice, (int)Type.Flying] = 2.0f;
		grid[(int)Type.Ice, (int)Type.Ground] = 2.0f;
		grid[(int)Type.Ice, (int)Type.Steel]  = 0.5f;
		grid[(int)Type.Ice, (int)Type.Fire]   = 0.5f;
		grid[(int)Type.Ice, (int)Type.Water]  = 0.5f;
		grid[(int)Type.Ice, (int)Type.Grass]  = 2.0f;
		grid[(int)Type.Ice, (int)Type.Ice]    = 0.5f;
		grid[(int)Type.Ice, (int)Type.Dragon] = 0.5f;

		grid[(int)Type.Dragon, (int)Type.Steel]  = 0.5f;
		grid[(int)Type.Dragon, (int)Type.Dragon] = 2.0f;
		grid[(int)Type.Dragon, (int)Type.Fairy]  = 0.0f;

		grid[(int)Type.Dark, (int)Type.Fighting] = 0.5f;
		grid[(int)Type.Dark, (int)Type.Ghost]    = 2.0f;
		grid[(int)Type.Dark, (int)Type.Psychic]  = 2.0f;
		grid[(int)Type.Dark, (int)Type.Dark]     = 0.5f;
		grid[(int)Type.Dark, (int)Type.Fairy]    = 0.5f;

		grid[(int)Type.Fairy, (int)Type.Fighting] = 2.0f;
		grid[(int)Type.Fairy, (int)Type.Poison]   = 0.5f;
		grid[(int)Type.Fairy, (int)Type.Steel]    = 0.5f;
		grid[(int)Type.Fairy, (int)Type.Fire]     = 0.5f;
		grid[(int)Type.Fairy, (int)Type.Dragon]   = 2.0f;
		grid[(int)Type.Fairy, (int)Type.Dark]     = 2.0f;
	}

	/// <summary>
	/// Returns the multiplier value of the attacking type versus the defending type
	/// </summary>
	public static float GetModifier(Type attacking, Type defending)
	{
		return grid[(int)attacking, (int)defending];
	}
}
