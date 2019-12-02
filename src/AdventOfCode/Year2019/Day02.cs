using System;
using System.Linq;

namespace AdventOfCode.Year2019
{
	public class Day02 : Puzzle
	{
		private readonly int[] _initialMemory;

		public Day02(string[] input) : base(input)
		{
			_initialMemory = input[0].Split(',').Select(int.Parse).ToArray();
		}

		public override DateTime Date => new DateTime(2019, 12, 02);

		public override string Title => "1202 Program Alarm";

		public override string? CalculateSolution()
		{
			int[] localMem = _initialMemory.ToArray();
			localMem[1] = 12;
			localMem[2] = 2;

			return Solution = ExecuteProgram(localMem).ToString();
		}

		public override string? CalculateSolutionPartTwo()
		{
			int[] localMem = new int[_initialMemory.Length];

			for (int noun = 0; noun <= 99; noun++)
			{
				for (int verb = 0; verb <= 99; verb++)
				{
					Array.Copy(_initialMemory, localMem, _initialMemory.Length);
					localMem[1] = noun;
					localMem[2] = verb;

					if (ExecuteProgram(localMem) == 19690720)
						return SolutionPartTwo = (100 * noun + verb).ToString();
				}
			}

			return SolutionPartTwo = "";
		}

		private static int ExecuteProgram(int[] memory)
		{
			int v;
			for (int ip = 0; memory[ip] != Opcode.Exit; ip++)
			{
				switch (memory[ip])
				{
					case Opcode.Add:
						v = memory[memory[++ip]] + memory[memory[++ip]];
						memory[memory[++ip]] = v;
						break;

					case Opcode.Multiply:
						v = memory[memory[++ip]] * memory[memory[++ip]];
						memory[memory[++ip]] = v;
						break;

					default:
						throw new InvalidOperationException();
				}
			}

			return memory[0];
		}

		private static class Opcode
		{
			public const int Add = 1;
			public const int Exit = 99;
			public const int Multiply = 2;
		}
	}
}
