using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017;

public class Day15 : Puzzle
{
	private readonly int _seedA;
	private readonly int _seedB;

	public Day15(string[] input) : base(input)
	{
		_seedA = int.Parse(input[0]);
		_seedB = int.Parse(input[1]);
	}

	public override DateTime Date => new DateTime(2017, 12, 15);
	public override string Title => "Dueling Generators";

	public override string? CalculateSolution()
	{
		IEnumerable<int> generatorA = Generator(_seedA, factor: 16807);
		IEnumerable<int> generatorB = Generator(_seedB, factor: 48271);

		return Solution = generatorA
			.Zip(generatorB, (a, b) => (a & 0xFFFF) == (b & 0xFFFF))
			.Take(40_000_000)
			.Count(p => p)
			.ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		IEnumerable<int> generatorA = Generator(_seedA, factor: 16807).Where(v => v % 4 == 0);
		IEnumerable<int> generatorB = Generator(_seedB, factor: 48271).Where(v => v % 8 == 0);

		return SolutionPartTwo = generatorA
			.Zip(generatorB, (a, b) => (a & 0xFFFF) == (b & 0xFFFF))
			.Take(5_000_000)
			.Count(p => p)
			.ToString();
	}

	private static IEnumerable<int> Generator(double seed, int factor)
	{
		double val = seed;
		while (true)
			yield return (int)(val = val * factor % 2147483647);
	}
}
