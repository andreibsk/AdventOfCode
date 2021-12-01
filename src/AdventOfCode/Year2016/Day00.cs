using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2016;

public class Day00 : Puzzle
{
	private readonly string[] _input;

	public Day00(string[] input) : base(input)
	{
		_input = input;
	}

	public override DateTime Date => new DateTime(2016, 12, 00);
	public override string Title => "";

	public override string? CalculateSolution()
	{
		return Solution = "";
	}

	public override string? CalculateSolutionPartTwo()
	{
		return SolutionPartTwo = "";
	}
}
