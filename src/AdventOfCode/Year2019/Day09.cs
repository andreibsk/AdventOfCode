using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2019
{
	public class Day09 : Puzzle
	{
		private readonly long[] _initialMemory;

		public Day09(string[] input) : base(input)
		{
			_initialMemory = input[0].Split(',').Select(long.Parse).ToArray();
		}

		public override DateTime Date => new DateTime(2019, 12, 09);

		public override string Title => "Sensor Boost";

		public override string? CalculateSolution()
		{
			IDynamicIndexable<long> localMem = _initialMemory.ToDynamicIndexable();
			return Solution = string.Join(',', ExecuteProgram(localMem, 1L));
		}

		public override string? CalculateSolutionPartTwo()
		{
			IDynamicIndexable<long> localMem = _initialMemory.ToDynamicIndexable();
			return SolutionPartTwo = string.Join(',', ExecuteProgram(localMem, 2L));
		}

		internal static IEnumerable<long> ExecuteProgram(IDynamicIndexable<long> memory, params long[] input)
		{
			return ExecuteProgram(memory, new Queue<long>(input));
		}

		internal static IEnumerable<long> ExecuteProgram(IDynamicIndexable<long> memory, Queue<long> input)
		{
			int relativeBase = 0;

			int opcode;
			for (int ip = 0; (opcode = (int)(memory[ip] % 100)) != Opcode.Exit; ip++)
			{
				long Arg(int i) => memory[Addr(i)];
				int Addr(int i) => ((int)memory[ip] / (int)Math.Pow(10, i + 1) % 10) switch
				{
					0 => (int)memory[ip + i],
					1 => ip + i,
					2 => relativeBase + (int)memory[ip + i],
					_ => throw new ArgumentException()
				};

				switch (opcode)
				{
					case Opcode.Add:
						memory[Addr(3)] = Arg(1) + Arg(2);
						ip += 3;
						break;

					case Opcode.Multiply:
						memory[Addr(3)] = Arg(1) * Arg(2);
						ip += 3;
						break;

					case Opcode.Input:
						memory[Addr(1)] = input.Dequeue();
						ip += 1;
						break;

					case Opcode.Output:
						yield return Arg(1);
						ip += 1;
						break;

					case Opcode.JumpIfTrue:
						if (Arg(1) != 0)
							ip = (int)Arg(2) - 1;
						else
							ip += 2;
						break;

					case Opcode.JumpIfFalse:
						if (Arg(1) == 0)
							ip = (int)Arg(2) - 1;
						else
							ip += 2;
						break;

					case Opcode.LessThan:
						memory[Addr(3)] = Arg(1) < Arg(2) ? 1 : 0;
						ip += 3;
						break;

					case Opcode.Equals:
						memory[Addr(3)] = Arg(1) == Arg(2) ? 1 : 0;
						ip += 3;
						break;

					case Opcode.SetRelativeBase:
						relativeBase += (int)Arg(1);
						ip += 1;
						break;

					default:
						throw new InvalidOperationException();
				}
			}
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
			public const int SetRelativeBase = 9;
		}
	}
}
