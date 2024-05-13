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
}
