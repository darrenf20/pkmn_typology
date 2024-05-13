using System;

public static class TypeChart {
	public enum Types {
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

	public static int numTypes = Enum.GetNames(typeof(Types)).Length;
	public static sbyte[,] typeChart = new sbyte[numTypes, numTypes];

	// Initializes the type chart
	static TypeChart()
	{
		// Give every cell a default value of 1
		for (var i = 0; i < typeChart.GetLength(0); i++)
		{
			for (var j = 0; j < typeChart.GetLength(1); j++)
			{
				typeChart[i, j] = 1;
			}
		}

		// Set the damage modifiers for each type
	}
}
