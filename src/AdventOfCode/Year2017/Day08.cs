using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017
{
	public class Day08 : Puzzle
	{
		private Instruction[] _instructions;

		public override DateTime Date => new DateTime(2017, 12, 8);
		public override string Title => "I Heard You Like Registers";

		public override string CalculateSolution()
		{
			var register = new Dictionary<string, int>();
			int Reader(string s) => register.GetValueOrDefault(s, 0);
			void Writer(string s, int v) => register[s] = v;

			foreach (Instruction instruction in _instructions)
				instruction.Execute(Reader, Writer);

			Solution = register.Values.Max().ToString();
			return Solution;
		}

		public override string CalculateSolutionPartTwo()
		{
			var register = new Dictionary<string, int>();
			int max = int.MinValue;
			int Reader(string s) => register.GetValueOrDefault(s, 0);

			void Writer(string s, int v)
			{
				if (v > max) max = v;
				register[s] = v;
			}

			foreach (Instruction instruction in _instructions)
				instruction.Execute(Reader, Writer);

			SolutionPartTwo = max.ToString();
			return SolutionPartTwo;
		}

		protected override void ParseInput(string[] input)
		{
			_instructions = input.Select(Instruction.Parse).ToArray();
		}

		private class Instruction
		{
			public Func<int, int, bool> ConditionOperator { get; set; }
			public string ConditionRegister { get; set; }
			public int ConditionValue { get; set; }
			public Func<int, int, int> Operation { get; set; }
			public string Register { get; set; }
			public int Value { get; set; }

			public static Instruction Parse(string instructionString)
			{
				// "b inc 5 if a > 1"
				string[] s = instructionString.Trim().Split(' ').ToArray();
				if (s == null || s.Length != 7) throw new FormatException();
				if (s[3] != "if") throw new FormatException("Instruction doesn't contain an if condition.");
				var instruction = new Instruction
				{
					Register = s[0],
					Value = int.Parse(s[2]),
					ConditionRegister = s[4],
					ConditionValue = int.Parse(s[6])
				};
				switch (s[1])
				{
					case "inc": instruction.Operation = (a, b) => a + b; break;
					case "dec": instruction.Operation = (a, b) => a - b; break;
					default: throw new FormatException($"Invalid opearation in condition: {s[1]}");
				}
				switch (s[5])
				{
					case ">": instruction.ConditionOperator = (a, b) => a > b; break;
					case ">=": instruction.ConditionOperator = (a, b) => a >= b; break;
					case "==": instruction.ConditionOperator = (a, b) => a == b; break;
					case "<": instruction.ConditionOperator = (a, b) => a < b; break;
					case "<=": instruction.ConditionOperator = (a, b) => a <= b; break;
					case "!=": instruction.ConditionOperator = (a, b) => a != b; break;
					default: throw new FormatException($"Invalid opearation in condition: {s[5]}");
				}
				return instruction;
			}

			public void Execute(Func<string, int> read, Action<string, int> write)
			{
				int v = read(ConditionRegister);
				if (!ConditionOperator(v, ConditionValue)) return;

				v = read(Register);
				v = Operation(v, Value);
				write(Register, v);
			}
		}
	}
}
