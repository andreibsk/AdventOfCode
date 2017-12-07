using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017
{
	public class Day06 : Puzzle
	{
		private int[] _banks;

		public override DateTime Date => new DateTime(2017, 12, 6);
		public override string Title => "Memory Reallocation";

		public override string CalculateSolution()
		{
			var banks = (int[])_banks.Clone();
			var states = new List<int[]>();
			int m, blocks;

			while (!states.Exists(s => s.SequenceEqual(banks)))
			{
				states.Add((int[])banks.Clone());

				m = banks.MaxIndex();
				blocks = banks[m];
				banks[m] = 0;

				// Redistribute
				for (int i = m + 1; blocks > 0; i++)
				{
					banks[i % banks.Length]++;
					blocks--;
				}
			}

			Solution = states.Count.ToString();
			return Solution;
		}

		public override string CalculateSolutionPartTwo()
		{
			var banks = (int[])_banks.Clone();
			var states = new List<int[]>();
			int m, blocks, si;

			while ((si = states.FindIndex(s => s.SequenceEqual(banks))) == -1)
			{
				states.Add((int[])banks.Clone());

				m = banks.MaxIndex();
				blocks = banks[m];
				banks[m] = 0;

				// Redistribute
				for (int i = m + 1; blocks > 0; i++)
				{
					banks[i % banks.Length]++;
					blocks--;
				}
			}

			SolutionPartTwo = (states.Count - si).ToString();
			return SolutionPartTwo;
		}

		protected override void ParseInput(string[] input)
		{
			_banks = input[0].Split(' ', '\t').Select(int.Parse).ToArray();
		}
	}
}
