using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode.Year2017
{
	public class Day12 : Puzzle
	{
		private ImmutableDictionary<int, int[]> _pipes;

		public override DateTime Date => new DateTime(2017, 12, 12);
		public override string Title => "Digital Plumber";

		public override string CalculateSolution()
		{
			var visited = new HashSet<int>();
			var visiting = new Queue<int>();
			visiting.Enqueue(0);

			while (visiting.Count != 0)
			{
				int p = visiting.Dequeue();
				if (visited.Add(p))
					foreach (int dest in _pipes[p])
						visiting.Enqueue(dest);
			}

			Solution = visited.Count.ToString();
			return Solution;
		}

		public override string CalculateSolutionPartTwo()
		{
			return SolutionPartTwo;
		}

		protected override void ParseInput(string[] input)
		{
			_pipes = input.ToImmutableDictionary(
				line => int.Parse(line.Substring(0, line.IndexOf(' '))),
				line => line.Substring(line.IndexOf(" <-> ") + " <-> ".Length).Split(", ").Select(int.Parse).ToArray()
			);
		}
	}
}
