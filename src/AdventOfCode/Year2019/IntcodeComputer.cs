using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2019
{
	internal class IntcodeComputer
	{
		public IntcodeComputer()
		{
			Memory = new DynamicIndexable<long>();
		}

		public IntcodeComputer(long[] program)
		{
			Memory = program.ToDynamicIndexable();
		}

		public IDynamicIndexable<long> Memory { get; private set; }

		public IEnumerable<long> Execute(params long[] input)
		{
			return Execute(input.AsEnumerable());
		}

		public IEnumerable<long> Execute(Queue<long> input, bool dequeue = true)
		{
			return dequeue ? Execute(DequeueEnumerable()) : Execute(input.AsEnumerable());

			IEnumerable<long> DequeueEnumerable()
			{
				while (input.TryDequeue(out long val))
					yield return val;
			}
		}

		public IEnumerable<long> Execute(IEnumerable<long> input)
		{
			if (Memory == null)
				throw new InvalidOperationException("Program not loaded.");

			using IEnumerator<long> e = input.GetEnumerator();

			int relativeBase = 0;
			int opcode;
			for (int ip = 0; (opcode = (int)(Memory[ip] % 100)) != Opcode.Exit; ip++)
			{
				long Arg(int i) => Memory[Addr(i)];
				int Addr(int i) => ((int)Memory[ip] / (int)Math.Pow(10, i + 1) % 10) switch
				{
					0 => (int)Memory[ip + i],
					1 => ip + i,
					2 => relativeBase + (int)Memory[ip + i],
					_ => throw new ArgumentException()
				};

				switch (opcode)
				{
					case Opcode.Add:
						Memory[Addr(3)] = Arg(1) + Arg(2);
						ip += 3;
						break;

					case Opcode.Multiply:
						Memory[Addr(3)] = Arg(1) * Arg(2);
						ip += 3;
						break;

					case Opcode.Input:
						Memory[Addr(1)] = e.MoveNext() ? e.Current : throw new InvalidOperationException();
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
						Memory[Addr(3)] = Arg(1) < Arg(2) ? 1 : 0;
						ip += 3;
						break;

					case Opcode.Equals:
						Memory[Addr(3)] = Arg(1) == Arg(2) ? 1 : 0;
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

		public void LoadProgram(long[] program)
		{
			Memory.Clear();

			for (int i = 0; i < program.Length; i++)
				Memory[i] = program[i];
		}

		public static class Opcode
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
