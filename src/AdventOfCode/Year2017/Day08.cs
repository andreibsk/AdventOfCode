using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017;

public class Day08 : Puzzle
{
	private readonly Instruction[] _instructions;

	public Day08(string[] input) : base(input)
	{
		_instructions = input.Select(Instruction.Parse).ToArray();
	}

	public override DateTime Date => new DateTime(2017, 12, 8);
	public override string Title => "I Heard You Like Registers";

	public override string? CalculateSolution()
	{
		var register = new Dictionary<string, int>();
		int Reader(string s) => register.GetValueOrDefault(s, 0);
		void Writer(string s, int v) => register[s] = v;

		foreach (Instruction instruction in _instructions)
			instruction.Execute(Reader, Writer);

		Solution = register.Values.Max().ToString();
		return Solution;
	}

	public override string? CalculateSolutionPartTwo()
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

	private class Instruction
	{
		public Instruction(string register, int value, string conditionRegister, int conditionValue, Func<int, int, int> operation,
			Func<int, int, bool> conditionOperator)
		{
			Register = register;
			Value = value;
			ConditionRegister = conditionRegister;
			ConditionValue = conditionValue;
			Operation = operation;
			ConditionOperator = conditionOperator;
		}

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
			if (s == null || s.Length != 7)
				throw new FormatException();
			if (s[3] != "if")
				throw new FormatException("Instruction doesn't contain an if condition.");

			return new Instruction
			(
				s[0],
				int.Parse(s[2]),
				s[4],
				int.Parse(s[6]),
				(s[1]) switch
				{
					"inc" => (a, b) => a + b,
					"dec" => (a, b) => a - b,
					_ => throw new FormatException($"Invalid opearation in condition: {s[1]}"),
				},
				(s[5]) switch
				{
					">" => (a, b) => a > b,
					">=" => (a, b) => a >= b,
					"==" => (a, b) => a == b,
					"<" => (a, b) => a < b,
					"<=" => (a, b) => a <= b,
					"!=" => (a, b) => a != b,
					_ => throw new FormatException($"Invalid opearation in condition: {s[5]}"),
				}
			);
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
