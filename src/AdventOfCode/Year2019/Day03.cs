namespace AdventOfCode.Year2019;

public class Day03 : Puzzle
{
	private readonly (Direction direction, int distance)[] _firstPath;
	private readonly (Direction direction, int distance)[] _secondPath;

	public Day03(string[] input) : base(input)
	{
		_firstPath = input[0].Split(',').Select(s => (Direction.Parse(s[0]), int.Parse(s[1..]))).ToArray();
		_secondPath = input[1].Split(',').Select(s => (Direction.Parse(s[0]), int.Parse(s[1..]))).ToArray();
	}

	public override DateTime Date => new DateTime(2019, 12, 03);
	public override string Title => "Crossed Wires";

	public override string? CalculateSolution()
	{
		return Solution = CalculateClosestDistance(part2: false).ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		return SolutionPartTwo = CalculateClosestDistance(part2: true).ToString();
	}

	private int CalculateClosestDistance(bool part2)
	{
		Position pos = (0, 0);
		IDynamicIndexable2D<int?> firstPath = new DynamicIndexable2D<int?>();
		int closestDistance = int.MaxValue;
		int totalDistance = 0;

		foreach ((Direction direction, int distance) in _firstPath)
		{
			Position newpos = pos + direction * distance;
			do
			{
				pos += direction;
				totalDistance++;
				firstPath[pos.X, pos.Y] ??= totalDistance;
			}
			while (pos != newpos);
		}

		totalDistance = 0;
		pos = (0, 0);
		foreach ((Direction direction, int distance) in _secondPath)
		{
			Position newpos = pos + direction * distance;
			do
			{
				pos += direction;
				totalDistance++;

				if (firstPath[pos.X, pos.Y].HasValue)
					closestDistance = Math.Min(
						closestDistance,
						part2 ? totalDistance + firstPath[pos.X, pos.Y]!.Value : pos.BlockDistanceTo(Position.Zero));
			}
			while (pos != newpos);
		}

		return closestDistance;
	}
}
