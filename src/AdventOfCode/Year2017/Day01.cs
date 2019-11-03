using System;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Year2017
{
	public class Day01 : Puzzle
	{
		private readonly int[] _digits;

		public Day01(string[] input) : base(input)
		{
			if (input.Length != 1 || input[0].Length < 1) throw new FormatException(nameof(input));
			_digits = input[0].ToCharArray().Select(Extensions.ToDigit).ToArray();
		}

		public override DateTime Date => new DateTime(2017, 12, 1);
		public override string Title => "Inverse Captcha";

		public override string? CalculateSolution()
		{
			int sum = 0;
			int prev = _digits[^1];
			int cur;
			for (int i = 0; i < _digits.Length; i++)
			{
				cur = _digits[i];
				if (prev == cur) sum += cur;
				prev = cur;
			}

			Solution = sum.ToString();
			return Solution;
		}

		public override string? CalculateSolutionPartTwo()
		{
			int sum = 0;
			for (int i = 0; i < _digits.Length; i++)
				if (_digits[i] == _digits[(_digits.Length / 2 + i) % _digits.Length])
					sum += _digits[i];

			SolutionPartTwo = sum.ToString();
			return SolutionPartTwo;
		}
	}
}
