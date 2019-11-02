using System;

namespace AdventOfCode.Year2017
{
	public class Day09 : Puzzle
	{
		private readonly string _stream;

		public Day09(string[] input) : base(input)
		{
			_stream = input[0];
		}

		public override DateTime Date => new DateTime(2017, 12, 9);
		public override string Title => "Stream Processing";

		public override string? CalculateSolution()
		{
			int level = 0;
			int score = 0;
			bool garbage = false;
			for (int i = 0; i < _stream.Length; i++)
				switch (_stream[i])
				{
					case '!': i++; break;
					case '<': garbage = true; break;
					case '>': garbage = false; break;
					case '{': if (!garbage) score += ++level; break;
					case '}': if (!garbage) level--; break;
				}

			Solution = score.ToString();
			return Solution;
		}

		public override string? CalculateSolutionPartTwo()
		{
			int gcount = 0;
			bool garbage = false;
			for (int i = 0; i < _stream.Length; i++)
				switch (_stream[i])
				{
					case '!': i++; break;
					case '>': garbage = false; break;
					case '<':
						if (garbage) gcount++;
						garbage = true;
						break;

					default:
						if (garbage) gcount++;
						break;
				}

			SolutionPartTwo = gcount.ToString();
			return SolutionPartTwo;
		}
	}
}
