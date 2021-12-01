using System;
using System.Linq;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2017;

public class Day14 : Puzzle
{
	private readonly string _key;

	public Day14(string[] input) : base(input)
	{
		_key = input[0];
	}

	public override DateTime Date => new DateTime(2017, 12, 14);
	public override string Title => "Disk Defragmentation";

	public override string? CalculateSolution()
	{
		bool[,] disk = Enumerable.Range(0, 128)
			.Select(i => _key + '-' + i)
			.Select(s => Day10.GetKnotHash(s))
			.Select(h => h.SelectMany(c => c.ToHexBits()))
			.To2DArray(128, 128);

		return Solution = disk.Cast<bool>().Count(b => b).ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		int?[,] disk = Enumerable.Range(0, 128)
			.Select(i => _key + '-' + i)
			.Select(s => Day10.GetKnotHash(s))
			.Select(h => h.SelectMany(c => c.ToHexBits().Select(b => b ? 0 : (int?)null)))
			.To2DArray(128, 128);

		int len0 = disk.GetLength(0);
		int len1 = disk.GetLength(1);
		int count = 0;

		for (int i = 0; i < len0; i++)
			for (int j = 0; j < len1; j++)
				if (disk[i, j] == 0)
					SetRegion(i, j, ++count);

		return SolutionPartTwo = count.ToString();

		void SetRegion(int x, int y, int id)
		{
			disk[x, y] = id;

			if (x - 1 >= 0 && disk[x - 1, y] == 0)
				SetRegion(x - 1, y, id);

			if (y - 1 >= 0 && disk[x, y - 1] == 0)
				SetRegion(x, y - 1, id);

			if (x + 1 < len0 && disk[x + 1, y] == 0)
				SetRegion(x + 1, y, id);

			if (y + 1 < len1 && disk[x, y + 1] == 0)
				SetRegion(x, y + 1, id);
		}
	}
}
