using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017
{
	public class Day05 : Puzzle
	{
		private int[] _jumpOffsets;

		public override DateTime Date => new DateTime(2017, 12, 5);
		public override string Title => "A Maze of Twisty Trampolines, All Alike";

		public override string CalculateSolution()
		{
			var jumps = (int[])_jumpOffsets.Clone();
			int count = 0;

			for (int i = 0; i >= 0 && i < jumps.Length; i += jumps[i]++) count++;

			Solution = count.ToString();
			return Solution;
		}

		public override string CalculateSolutionPartTwo()
		{
			var jumps = (int[])_jumpOffsets.Clone();
			int count = 0;

			for (int i = 0; i >= 0 && i < jumps.Length;)
			{
				i += jumps[i] > 2 ? jumps[i]-- : jumps[i]++;
				count++;
			}

			SolutionPartTwo = count.ToString();
			return SolutionPartTwo;
		}

		protected override void ParseInput(string[] input)
		{
			_jumpOffsets = input.Select(int.Parse).ToArray();
		}
	}
}
