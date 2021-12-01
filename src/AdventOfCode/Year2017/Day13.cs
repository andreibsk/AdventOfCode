using System;
using System.Linq;

namespace AdventOfCode.Year2017;

public class Day13 : Puzzle
{
	private readonly (int Depth, int Range)[] _layers;

	public Day13(string[] input) : base(input)
	{
		_layers = input.Select(line =>
			(int.Parse(line.Substring(0, line.IndexOf(": "))),
			int.Parse(line.Substring(line.IndexOf(": ") + ": ".Length)))
		).ToArray();
	}

	public override DateTime Date => new DateTime(2017, 12, 13);
	public override string Title => "Packet Scanners";

	public override string? CalculateSolution()
	{
		Solution = _layers.Select(l => l.Depth % ((l.Range - 1) * 2) == 0 ? l.Range * l.Depth : 0).Sum().ToString();
		return Solution;
	}

	public override string? CalculateSolutionPartTwo()
	{
		int delay;
		for (delay = 0; _layers.Any(l => (l.Depth + delay) % ((l.Range - 1) * 2) == 0); delay++) ;
		SolutionPartTwo = delay.ToString();
		return SolutionPartTwo;
	}
}
