using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2016
{
	public class Day05 : Puzzle
	{
		public override DateTime Date => new DateTime(2016, 12, 5);
		public override string Title => "How About a Nice Game of Chess?";

		private readonly string _doorId;

		public Day05(string[] input) : base(input)
		{
			_doorId = input[0];
		}

		public override string? CalculateSolution()
		{
			using var md5 = MD5.Create();

			Solution = GenerateChars(md5, 6)
				.Select(t => t.Char)
				.Take(8)
				.Aggregate(string.Empty, (s, c) => s + c);

			return Solution;
		}

		public override string? CalculateSolutionPartTwo()
		{
			using var md5 = MD5.Create();
			char?[] pass = new char?[8];

			foreach ((int i, char c) in GenerateChars(md5, 7))
			{
				if (i >= pass.Length)
					continue;

				pass[i] ??= c;

				if (pass.All(c => c.HasValue))
					break;
			}

			SolutionPartTwo = pass.Aggregate(string.Empty, (s, c) => s + c);
			return SolutionPartTwo;
		}

		private IEnumerable<(int Index, char Char)> GenerateChars(MD5 md5, int charPosition)
		{
			int hexMask = charPosition % 2 == 0 ? 0x0F : 0xF0;
			int bindex = (charPosition - 1) / 2;

			return Enumerable
				.Range(0, int.MaxValue)
				.Select(i => _doorId + i)
				.Select(s => Encoding.UTF8.GetBytes(s))
				.Select(b => md5.ComputeHash(b))
				.Where(b => b[0] == 0 && b[1] == 0 && (b[2] & 0xF0) == 0)
				.Select(b => (b[2] & 0x0F, (b[bindex] & hexMask).ToString("x1")[0]));
		}
	}
}
