using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2017;

public class Day21 : Puzzle
{
	private readonly int? _configIterations;

	private readonly IDictionary<int, IIndexable2D<bool>> _rules2;
	private readonly IDictionary<int, IIndexable2D<bool>> _rules3;

	private readonly IIndexable2D<bool> _startingPattern = PatternStringToIndexable(".#./..#/###");

	public Day21(string[] input) : this(input, config: null)
	{
	}

	public Day21(string[] input, string? config) : base(input)
	{
		_configIterations = config == null ? (int?)null : int.Parse(config);

		_rules2 = BuildRules(size: 2);
		_rules3 = BuildRules(size: 3);

		IDictionary<int, IIndexable2D<bool>> BuildRules(int size)
		{
			return input
				.Where(s => s[size] == '/')
				.SelectMany(s =>
				{
					(IIndexable2D<bool>? pattern, IIndexable2D<bool>? result) = s
						.Split(" => ")
						.Select(ps => PatternStringToIndexable(ps));
					return AllSourceOrientations(pattern!, result!);
				})
				.Select(sd => (source: GetPatternCode(sd.source), sd.destination))
				.Distinct(sd => sd.source)
				.ToDictionary(sd => sd.source, sd => sd.destination);
		}
	}

	public override DateTime Date => new DateTime(2017, 12, 21);
	public override string Title => "Fractal Art";

	public override string? CalculateSolution()
	{
		return Solution = ExpandGrid(_startingPattern, iterations: _configIterations ?? 5)
			.AsEnumerable()
			.Count(p => p)
			.ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		return SolutionPartTwo = ExpandGrid(_startingPattern, iterations: _configIterations ?? 18)
			.AsEnumerable()
			.Count(p => p)
			.ToString();
	}

	private static IEnumerable<(IIndexable2D<bool> source, IIndexable2D<bool> destination)> AllSourceOrientations(IIndexable2D<bool> source,
		IIndexable2D<bool> destination)
	{
		yield return (source, destination);
		yield return (source.Flip(), destination);

		source = source.Rotate();
		yield return (source, destination);
		yield return (source.Flip(), destination);

		source = source.Rotate();
		yield return (source, destination);
		yield return (source.Flip(), destination);

		source = source.Rotate();
		yield return (source, destination);
		yield return (source.Flip(), destination);
	}

	private static int GetPatternCode(IIndexable2D<bool> block)
	{
		int value = 0;

		for (int i = 0; i < block.Length0; i++)
			for (int j = 0; j < block.Length1; j++)
				value = (value << 1) + (block[i, j] ? 1 : 0);

		return value;
	}

	private static IIndexable2D<bool> PatternStringToIndexable(string str)
	{
		return str.Split('/')
			.Select(r => r.Select(c => c == '#' ? true : false))
			.To2DArray()
			.AsIndexable();
	}

	private IIndexable2D<bool> ExpandGrid(IIndexable2D<bool> grid, int iterations)
	{
		for (int i = 0; i < iterations; i++)
		{
			int size = grid.Length0 % 2 == 0 ? 2 : 3;
			IIndexable2D<IIndexable2D<bool>> newg = grid.Split(size);

			for (int x = 0; x < newg.Length0; x++)
				for (int y = 0; y < newg.Length1; y++)
					newg[x, y] = (size == 2 ? _rules2 : _rules3)[GetPatternCode(newg[x, y])];

			grid = newg.AsMergedIndexable();
		}

		return grid;
	}
}
