using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode.Year2017;

public class Day03 : Puzzle
{
	private readonly int _square;

	public Day03(string[] input) : base(input)
	{
		_square = int.Parse(input[0]);
	}

	public override DateTime Date => new DateTime(2017, 12, 3);
	public override string Title => "Spiral Memory";

	public override string? CalculateSolution()
	{
		Position p = PositionOf(_square);
		int distance = Math.Abs(p.X) + Math.Abs(p.Y);

		Solution = distance.ToString();
		return Solution;
	}

	public override string? CalculateSolutionPartTwo()
	{
		var memory = new Dictionary<Position, int>
			{
				{ (0, 0), 1 }
			};

		Position pos = (0, 0);
		Direction direction = Direction.East;
		int c = 1; // Distance to next corner;
		int dc = 1; // Distance between corners;
		bool grow = false; // True if next corner is a growth corner (increase dc).
		int n;

		while (true)
		{
			// Go forward.
			pos += direction;
			c--;

			// Calculate the number.
			n = 0;
			foreach (Direction d in Direction.All) n += memory.GetValueOrDefault(pos + d);
			if (n > _square) break; // Reached destination.

			// Save the number.
			memory.Add(pos, n);

			// Change direction if on corner.
			if (c == 0)
			{
				if (grow) dc++;
				c += dc;
				grow = !grow;
				direction = direction.ToLeft();
			}
		}

		SolutionPartTwo = n.ToString();
		return SolutionPartTwo;
	}

	private Position PositionOf(int n)
	{
		int root = (int)Math.Floor(Math.Sqrt(n - 1));
		int layer = (int)Math.Ceiling(root / 2D);
		int sign = (int)Math.Pow(-1, root + 1);
		int modifier = root * (root + 1) - n + 1;

		int x = sign * layer + sign * (modifier - Math.Abs(modifier)) / 2;
		int y = -sign * layer + sign * (modifier + Math.Abs(modifier)) / 2;
		return (x, y);
	}
}
