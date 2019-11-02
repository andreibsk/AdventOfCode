using System;
using System.Linq;

namespace AdventOfCode.Year2017
{
	public class Day02 : Puzzle
	{
		private readonly int[][] _sheet;

		public Day02(string[] input) : base(input)
		{
			_sheet = new int[input.Length][];
			for (int i = 0; i < input.Length; i++)
				_sheet[i] = input[i]
					.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();
		}

		public override DateTime Date => new DateTime(2017, 12, 2);
		public override string Title => "Corruption Checksum";

		public override string? CalculateSolution()
		{
			if (_sheet == null) throw new InvalidOperationException("Input not parsed.");

			int sum = 0;
			foreach (int[] row in _sheet)
			{
				if (row == null || row.Length == 0) continue;
				int min = row[0];
				int max = row[0];
				foreach (int cell in row)
				{
					if (cell < min) min = cell;
					else if (cell > max) max = cell;
				}
				sum += max - min;
			}

			Solution = sum.ToString();
			return Solution;
		}

		public override string? CalculateSolutionPartTwo()
		{
			if (_sheet == null) throw new InvalidOperationException("Input not parsed.");

			int sum = 0;
			foreach (int[] row in _sheet)
			{
				if (row == null) continue;
				int? div = null;
				for (int i = 0; i < row.Length; i++)
				{
					for (int j = i + 1; j < row.Length; j++)
					{
						if (row[i] % row[j] == 0)
						{
							div = row[i] / row[j];
							break;
						}
						else if (row[j] % row[i] == 0)
						{
							div = row[j] / row[i];
							break;
						}
					}
					if (div.HasValue)
					{
						sum += div.Value;
						break;
					}
				}
			}

			SolutionPartTwo = sum.ToString();
			return SolutionPartTwo;
		}
	}
}
