using System;
using System.Linq;

namespace AdventOfCode.Year2019;

public class Day05 : Puzzle
{
	private readonly long[] _initialMemory;

	public Day05(string[] input) : base(input)
	{
		_initialMemory = input[0].Split(',').Select(long.Parse).ToArray();
	}

	public override DateTime Date => new DateTime(2019, 12, 05);
	public override string Title => "Sunny with a Chance of Asteroids";

	public override string? CalculateSolution()
	{
		return Solution = new IntcodeComputer(_initialMemory).Execute(input: 1).Where(o => o != 0).Single().ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		return SolutionPartTwo = new IntcodeComputer(_initialMemory).Execute(input: 5).Where(o => o != 0).Single().ToString();
	}
}
