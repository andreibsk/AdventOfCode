namespace AdventOfCode.Year2017;

public class Day22 : Puzzle
{
	private static readonly int s_nodeStateCount = Enum.GetValues(typeof(NodeState)).Length;
	private readonly NodeState[,] _initialNodeStates;

	static Day22()
	{
		Direction.SetMode(Direction.Mode.Array);
	}

	public Day22(string[] input) : base(input)
	{
		_initialNodeStates = input
			.Select(s => s.Select(c => c == '#' ? NodeState.Infected : NodeState.Clean))
			.To2DArray();
	}

	private enum NodeState : byte
	{
		Clean = 0,
		Weakened,
		Infected,
		Flagged
	}

	public override DateTime Date => new DateTime(2017, 12, 22);
	public override string Title => "Sporifica Virus";

	public override string? CalculateSolution()
	{
		IDynamicIndexable2D<NodeState> nodes = _initialNodeStates.AsIndexable().ToDynamicIndexable();
		Position position = (nodes.Length0 / 2, nodes.Length1 / 2);
		Direction direction = Direction.North;
		int count = 0;

		for (int i = 0; i < 10_000; i++)
		{
			direction = nodes.GetValueOrDefault(position.X, position.Y) switch
			{
				NodeState.Clean => direction.ToLeft(),
				NodeState.Infected => direction.ToRight(),
				_ => throw new InvalidOperationException()
			};

			nodes[position.X, position.Y] = (NodeState)(((int)nodes.GetValueOrDefault(position.X, position.Y) + 2) % s_nodeStateCount);

			if (nodes[position.X, position.Y] == NodeState.Infected)
				count++;

			position += direction;
		}

		return Solution = count.ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		IDynamicIndexable2D<NodeState> nodes = _initialNodeStates.AsIndexable().ToDynamicIndexable();
		Position position = (nodes.Length0 / 2, nodes.Length1 / 2);
		Direction direction = Direction.North;
		int count = 0;

		for (int i = 0; i < 10_000_000; i++)
		{
			direction = nodes.GetValueOrDefault(position.X, position.Y) switch
			{
				NodeState.Clean => direction.ToLeft(),
				NodeState.Weakened => direction,
				NodeState.Infected => direction.ToRight(),
				NodeState.Flagged => direction.ToReverse(),
				_ => throw new InvalidOperationException()
			};

			nodes[position.X, position.Y] = (NodeState)(((int)nodes.GetValueOrDefault(position.X, position.Y) + 1) % s_nodeStateCount);

			if (nodes[position.X, position.Y] == NodeState.Infected)
				count++;

			position += direction;
		}

		return SolutionPartTwo = count.ToString();
	}
}
