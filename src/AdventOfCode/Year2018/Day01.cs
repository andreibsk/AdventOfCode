using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2018;

public class Day01 : Puzzle
{
	private readonly int[] _changes;

	public Day01(string[] input) : base(input)
	{
		_changes = input.Select(int.Parse).ToArray();
	}

	public override DateTime Date => new DateTime(2018, 12, 1);
	public override string Title => "Chronal Calibration";

	public override string? CalculateSolution()
	{
		return Solution = _changes.Sum().ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		int current = 0;
		var frequencies = new HashSet<int> { current };

		foreach (int delta in _changes.Repeat())
		{
			if (frequencies.Contains(current += delta))
				break;
			frequencies.Add(current);
		}

		return SolutionPartTwo = current.ToString();
	}
}
