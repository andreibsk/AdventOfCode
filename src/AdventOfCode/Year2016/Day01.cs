using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2016
{
	public class Day01 : Puzzle
	{
		private readonly (char turnDirection, int distance)[] _sequence;

		public Day01(string[] input) : base(input)
		{
			_sequence = input[0]
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(s =>
				{
					if (s[0] != 'R' && s[0] != 'L')
						throw new FormatException("Invalid direction.");
					return (s[0], int.Parse(s[1..]));
				})
				.ToArray();
		}

		public override DateTime Date => new DateTime(2016, 12, 1);
		public override string Title => "No Time for a Taxicab";

		public override string? CalculateSolution()
		{
			Position pos = (0, 0);
			Direction direction = Direction.North;

			foreach ((char turnDirection, int distance) in _sequence)
			{
				direction = turnDirection == 'R' ? direction.ToRight() : direction.ToLeft();
				pos += direction * distance;
			}

			Solution = pos.BlockDistanceTo(Position.Zero).ToString();
			return Solution;
		}

		public override string? CalculateSolutionPartTwo()
		{
			Position pos = Position.Zero;
			var visited = new HashSet<Position>() { pos };
			Direction direction = Direction.North;

			foreach ((char turnDirection, int distance) in _sequence)
			{
				direction = turnDirection == 'R' ? direction.ToRight() : direction.ToLeft();

				// Walk
				for (int i = 0; i < distance; i++)
				{
					pos += direction * 1;
					if (!visited.Add(pos))
					{
						// Been here before...
						SolutionPartTwo = pos.BlockDistanceTo(Position.Zero).ToString();
						return SolutionPartTwo;
					}
				}
			}

			return SolutionPartTwo;
		}
	}
}
