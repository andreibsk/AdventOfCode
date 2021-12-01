using System;
using System.Linq;

namespace AdventOfCode.Year2019;

public class Day01 : Puzzle
{
	private readonly int[] _moduleMasses;

	public Day01(string[] input) : base(input)
	{
		_moduleMasses = input.Select(int.Parse).ToArray();
	}

	public override DateTime Date => new DateTime(2019, 12, 01);
	public override string Title => "The Tyranny of the Rocket Equation";

	public override string? CalculateSolution()
	{
		return Solution = _moduleMasses.Sum(m => m / 3 - 2).ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		return SolutionPartTwo = _moduleMasses.Sum(FuelForMass).ToString();

		static int FuelForMass(int mass)
		{
			int f = mass / 3 - 2;
			if (f <= 0)
				return 0;
			return f + FuelForMass(f);
		}
	}
}
