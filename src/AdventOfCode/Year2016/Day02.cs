using System;
using System.Linq;
using System.Text;
using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2016
{
	public class Day02 : Puzzle
	{
		private readonly Direction[][] _instructions;

		private readonly char?[,] _pad = new char?[,]
		{
			{ null, null, '1', null, null },
			{ null,  '2', '3',  '4', null },
			{ '5',   '6', '7',  '8',  '9' },
			{ null,  'A', 'B',  'C', null },
			{ null, null, 'D', null, null }
		};

		public Day02(string[] input) : base(input)
		{
			_instructions = input.Select(s => s.Select(Direction.Parse).ToArray()).ToArray();
		}

		public override DateTime Date => new DateTime(2016, 12, 2);
		public override string Title => "Bathroom Security";

		public override string? CalculateSolution()
		{
			var code = new StringBuilder();
			int button = 5; // Start on 5.

			foreach (Direction[] line in _instructions)
			{
				foreach (Direction d in line)
				{
					if (d == Direction.North && button > 3) button -= 3;
					else if (d == Direction.South && button < 7) button += 3;
					else if (d == Direction.West && button % 3 != 1) button -= 1;
					else if (d == Direction.East && button % 3 != 0) button += 1;
				}
				code.Append((char)('0' + button));
			}

			Solution = code.ToString();
			return Solution;
		}

		public override string? CalculateSolutionPartTwo()
		{
			var code = new StringBuilder();
			Position pos = (0, 2); // Start on 5.

			foreach (Direction[] line in _instructions)
			{
				foreach (Direction d in line)
				{
					Position newpos = pos + d * 1;
					if (_pad.ElementAtOrDefault(newpos).HasValue) pos = newpos;
				}
				code.Append(_pad[pos.Y, pos.X]);
			}

			SolutionPartTwo = code.ToString();
			return SolutionPartTwo;
		}
	}
}
