using System;
using System.Linq;

namespace AdventOfCode.Year2017
{
	public class Day11 : Puzzle
	{
		private (int, int, int)[] _path;

		public override DateTime Date => new DateTime(2017, 12, 11);
		public override string Title => "Hex Ed";

		public override string CalculateSolution()
		{
			(int x, int y, int z) pos = (0, 0, 0);
			foreach ((int dx, int dy, int dz) in _path)
				pos = (pos.x + dx, pos.y + dy, pos.z + dz);
			int distance = (Math.Abs(pos.x) + Math.Abs(pos.y) + Math.Abs(pos.z)) / 2;
			Solution = distance.ToString();
			return Solution;
		}

		public override string CalculateSolutionPartTwo()
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

		protected override void ParseInput(string[] input)
		{
			_path = input[0].Split(',').Select(s =>
			{
				switch (s.ToLowerInvariant())
				{
					case "n": return (0, 1, -1);
					case "ne": return (1, 0, -1);
					case "nw": return (-1, 1, 0);
					case "s": return (0, -1, 1);
					case "se": return (1, -1, 0);
					case "sw": return (-1, 0, 1);

					default:
						throw new FormatException(
							$"Can't parse the string '{s}' to an equivalent {nameof(Direction)}.");
				}
			}).ToArray();
		}
	}
}
