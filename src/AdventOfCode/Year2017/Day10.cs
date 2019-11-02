using System;
using System.Linq;

namespace AdventOfCode.Year2017
{
	public class Day10 : Puzzle
	{
		private readonly int[] _lengths;
		private readonly int _listLength = 256; // Used for testing.

		public Day10(string[] input) : base(input)
		{
			_lengths = input[0].Split(',').Select(int.Parse).ToArray();

			if (input.Length > 1 && input[1].Length != 0)
				_listLength = int.Parse(input[1]);
		}

		public override DateTime Date => new DateTime(2017, 12, 10);
		public override string Title => "Knot Hash";

		public override string? CalculateSolution()
		{
			int[] list = Enumerable.Range(0, _listLength).ToArray();
			int skip = 0;
			int pos = 0;

			foreach (int length in _lengths)
			{
				Reverse(list, pos, length);
				pos = (pos + length + skip) % list.Length;
				skip++;
			}

			Solution = (list[0] * list[1]).ToString();
			return Solution;
		}

		public override string? CalculateSolutionPartTwo()
		{
			int[] lengths = string.Join(',', _lengths.Select(l => l.ToString())).Select(c => (int)c)
				.Concat(new[] { 17, 31, 73, 47, 23 }).ToArray();
			int[] list = Enumerable.Range(0, _listLength).ToArray();
			int skip = 0;
			int pos = 0;

			for (int i = 0; i < 64; i++)
				foreach (int length in lengths)
				{
					Reverse(list, pos, length);
					pos = (pos + length + skip) % list.Length;
					skip++;
				}

			SolutionPartTwo = string.Concat(
				list.AsBatches(16).Select(batch => batch.Aggregate((a, b) => a ^ b).ToString("x2")));
			return SolutionPartTwo;
		}

		private void Reverse(int[] a, int start, int length)
		{
			int t, l, r;
			for (int i = 0; i < length / 2; i++)
			{
				l = (start + i) % a.Length;
				r = (start + length - 1 - i) % a.Length;
				t = a[l];
				a[l] = a[r];
				a[r] = t;
			}
		}
	}
}
