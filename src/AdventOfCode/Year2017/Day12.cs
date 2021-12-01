using System.Collections.Immutable;

namespace AdventOfCode.Year2017;

public class Day12 : Puzzle
{
	private readonly ImmutableDictionary<int, int[]> _pipes;

	public Day12(string[] input) : base(input)
	{
		_pipes = input.ToImmutableDictionary(
			line => int.Parse(line.Substring(0, line.IndexOf(' '))),
			line => line.Substring(line.IndexOf(" <-> ") + " <-> ".Length).Split(", ").Select(int.Parse).ToArray()
		);
	}

	public override DateTime Date => new DateTime(2017, 12, 12);
	public override string Title => "Digital Plumber";

	public override string? CalculateSolution()
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

	public override string? CalculateSolutionPartTwo()
	{
		var visitedGroups = new List<HashSet<int>>();
		var pipes = new Dictionary<int, int[]>(_pipes);

		while (pipes.Count > 0)
		{
			var group = new HashSet<int>();
			var visiting = new Queue<int>();
			visiting.Enqueue(pipes.Keys.First());

			while (visiting.Count > 0)
			{
				int prog = visiting.Dequeue();
				if (group.Add(prog) && pipes.Remove(prog, out int[]? progPipes))
				{
					foreach (int dest in progPipes)
						visiting.Enqueue(dest);
				}
			}

			visitedGroups.Add(group);
		}

		SolutionPartTwo = visitedGroups.Count.ToString();
		return SolutionPartTwo;
	}
}
