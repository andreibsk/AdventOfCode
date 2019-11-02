using System;
using System.Linq;

namespace AdventOfCode.Year2017
{
	public class Day11 : Puzzle
	{
		private readonly (int, int, int)[] _path;

		public Day11(string[] input) : base(input)
		{
			_path = input[0].Split(',').Select(s =>
			{
				return (s.ToLowerInvariant()) switch
				{
					"n" => (0, 1, -1),
					"ne" => (1, 0, -1),
					"nw" => (-1, 1, 0),
					"s" => (0, -1, 1),
					"se" => (1, -1, 0),
					"sw" => (-1, 0, 1),

					_ => throw new FormatException($"Can't parse the string '{s}' to an equivalent {nameof(Direction)}.")
				};
			}).ToArray();
		}

		public override DateTime Date => new DateTime(2017, 12, 11);
		public override string Title => "Hex Ed";

		public override string? CalculateSolution()
		{
			(int x, int y, int z) pos = (0, 0, 0);
			foreach ((int dx, int dy, int dz) in _path)
				pos = (pos.x + dx, pos.y + dy, pos.z + dz);
			int distance = (Math.Abs(pos.x) + Math.Abs(pos.y) + Math.Abs(pos.z)) / 2;
			Solution = distance.ToString();
			return Solution;
		}

		public override string? CalculateSolutionPartTwo()
		{
			int maxDistance = int.MinValue;
			(int x, int y, int z) pos = (0, 0, 0);
			foreach ((int dx, int dy, int dz) in _path)
			{
				pos = (pos.x + dx, pos.y + dy, pos.z + dz);
				int distance = (Math.Abs(pos.x) + Math.Abs(pos.y) + Math.Abs(pos.z)) / 2;
				if (distance > maxDistance) maxDistance = distance;
			}
			SolutionPartTwo = maxDistance.ToString();
			return SolutionPartTwo;
		}
	}
}
