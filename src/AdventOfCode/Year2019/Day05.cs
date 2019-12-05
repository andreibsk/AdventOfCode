using System;
using System.Linq;

namespace AdventOfCode.Year2019
{
	public class Day05 : Puzzle
	{
		private readonly int[] _initialMemory;

		public Day05(string[] input) : base(input)
		{
			_initialMemory = input[0].Split(',').Select(int.Parse).ToArray();
		}

		public override DateTime Date => new DateTime(2019, 12, 05);
		public override string Title => "Sunny with a Chance of Asteroids";

		public override string? CalculateSolution()
		{
			int[] localMem = _initialMemory.ToArray();
			return Solution = ExecuteProgram(localMem, input: 1);
		}

		public override string? CalculateSolutionPartTwo()
		{
			int[] localMem = _initialMemory.ToArray();
			return SolutionPartTwo = ExecuteProgram(localMem, input: 5);
		}

		private static string ExecuteProgram(int[] memory, int input)
		{
			int output = 0;

			for (int ip = 0; memory[ip] % 100 != Opcode.Exit; ip++)
			{
				int p1 = 0, p2 = 0;
				int opcode = memory[ip] % 100;
				int mode1 = memory[ip] / 100 % 10;
				int mode2 = memory[ip] / 1000 % 10;

				if (opcode != Opcode.Input && opcode != Opcode.Output)
				{
					p1 = mode1 == 1 ? memory[++ip] : memory[memory[++ip]];
					p2 = mode2 == 1 ? memory[++ip] : memory[memory[++ip]];
				}

				switch (opcode)
				{
					case Opcode.Add:
						memory[memory[++ip]] = p1 + p2;
						break;

					case Opcode.Multiply:
						memory[memory[++ip]] = p1 * p2;
						break;

					case Opcode.Input:
						memory[memory[++ip]] = input;
						break;

					case Opcode.Output:
						output = memory[memory[++ip]];
						break;

					case Opcode.JumpIfTrue:
						if (p1 != 0)
							ip = p2 - 1;
						break;

					case Opcode.JumpIfFalse:
						if (p1 == 0)
							ip = p2 - 1;
						break;

					case Opcode.LessThan:
						memory[memory[++ip]] = p1 < p2 ? 1 : 0;
						break;

					case Opcode.Equals:
						memory[memory[++ip]] = p1 == p2 ? 1 : 0;
						break;

					default:
						throw new InvalidOperationException();
				}
			}

			return output.ToString();
		}

		private static class Opcode
		{
			public const int Add = 1;
			public new const int Equals = 8;
			public const int Exit = 99;
			public const int Input = 3;
			public const int JumpIfFalse = 6;
			public const int JumpIfTrue = 5;
			public const int LessThan = 7;
			public const int Multiply = 2;
			public const int Output = 4;
		}
	}
}
