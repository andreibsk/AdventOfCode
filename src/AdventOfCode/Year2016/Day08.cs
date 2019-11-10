using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2016
{
	public class Day08 : Puzzle
	{
		private readonly Instruction[] _instructions;

		public Day08(string[] input) : base(input)
		{
			_instructions = input.Select(Instruction.Parse).ToArray();
		}

		public override DateTime Date => new DateTime(2016, 12, 8);
		public override string Title => "Two-Factor Authentication";

		public override string? CalculateSolution()
		{
			bool[,] screen = new bool[6, 50];

			foreach (Instruction instr in _instructions)
				instr.Execute(screen);

			return Solution = screen.Cast<bool>().Sum(b => b ? 1 : 0).ToString();
		}

		public override string? CalculateSolutionPartTwo()
		{
			bool[,] screen = new bool[6, 50];

			foreach (Instruction instr in _instructions)
				instr.Execute(screen);

			return SolutionPartTwo = string.Join(Environment.NewLine,
				screen.AsRowEnumerable().Select(row => string.Concat(row.Select(b => b ? '#' : '.'))));
		}

		private class Instruction
		{
			private static readonly Regex s_regex = new Regex(
				@"^(?<instr>rect |rotate row |rotate column )(?:[xy]=)?(?<a>\d+)(x| by )(?<b>\d+)$",
				RegexOptions.Compiled);

			private readonly Action<bool[,]> _implementation;

			private Instruction(Action<bool[,]> implementation)
			{
				_implementation = implementation;
			}

			public static Instruction Parse(string instructionString)
			{
				Match match = s_regex.Match(instructionString);
				if (!match.Success)
					throw new FormatException();

				int a = int.Parse(match.Groups["a"].Value);
				int b = int.Parse(match.Groups["b"].Value);

				return match.Groups["instr"].Value switch
				{
					"rect " => new Instruction(s => Rect(s, a, b)),
					"rotate row " => new Instruction(s => Rotate(s, pos: a, n: b, row: true)),
					"rotate column " => new Instruction(s => Rotate(s, pos: a, n: b, row: false)),
					_ => throw new FormatException()
				};
			}

			public void Execute(bool[,] screen) => _implementation.Invoke(screen);

			private static void Rect(bool[,] screen, int a, int b)
			{
				for (int x = 0; x < a; x++)
					for (int y = 0; y < b; y++)
						screen[y, x] = true;
			}

			private static void Rotate(bool[,] screen, int pos, int n, bool row)
			{
				ArrayLine<bool> line = row ? screen.GetRow(pos) : screen.GetColumn(pos);
				line.Rotate(n);
			}
		}
	}
}
