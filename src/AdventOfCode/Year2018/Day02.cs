using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Year2018;

public class Day02 : Puzzle
{
	private readonly string[] _boxIds;

	public Day02(string[] input) : base(input)
	{
		_boxIds = input;
	}

	public override DateTime Date => new DateTime(2018, 12, 02);
	public override string Title => "Inventory Management System";

	public override string? CalculateSolution()
	{
		int twos = _boxIds.Select(id => id.GroupBy(c => c)).Count(id => id.Any(g => g.Count() == 2));
		int threes = _boxIds.Select(id => id.GroupBy(c => c)).Count(id => id.Any(g => g.Count() == 3));

		return Solution = (twos * threes).ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		var ids = new SortedSet<string>(new DiffByOneComparer());

		foreach (string id1 in _boxIds)
			if (ids.TryGetValue(id1, out string? id2))
			{
				return SolutionPartTwo = string.Concat(id1.Where((c, i) => c == id2[i]));
			}
			else
				ids.Add(id1);

		return SolutionPartTwo;
	}

	private class DiffByOneComparer : IComparer<string>
	{
		public int Compare([AllowNull] string x, [AllowNull] string y)
		{
			if (x == null && y == null)
				return 0;

			int d = (x?.Length ?? -1) - (y?.Length ?? -1);
			if (d != 0)
				return d;

			bool byOne = false;
			for (int i = 0; i < x!.Length; i++)
			{
				if (x[i] != y![i])
					if (byOne)
						return x[i] - y[i];
					else
						byOne = true;
			}

			return 0;
		}
	}
}
