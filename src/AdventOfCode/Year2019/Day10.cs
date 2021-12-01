namespace AdventOfCode.Year2019;

public class Day10 : Puzzle
{
	private readonly IIndexable2D<bool> _map;

	public Day10(string[] input) : base(input)
	{
		_map = input
			.Select(s => s.Select(c => c == '#'))
			.ToIndexable();
	}

	public override DateTime Date => new DateTime(2019, 12, 10);
	public override string Title => "Monitoring Station";

	public override string? CalculateSolution()
	{
		return Solution = SearchBestLocation().VisibleAsteroids.ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		Direction.SetMode(Direction.Mode.Array);
		Position station = SearchBestLocation().Position;

		var vaporizationOrder = new SortedDictionary<Direction, Queue<Position>>(
			_map
			.EnumeratePositions(v => v)
			.Where(p => p != station)
			.GroupBy(p => new Direction(p.X - station.X, p.Y - station.Y).ToRight())
			.ToDictionary(g => g.Key, g => new Queue<Position>(g.OrderBy(p => p.DistanceTo(station)))));

		int count = 0;
		foreach (Queue<Position> vaporizationQueue in vaporizationOrder.Values.Repeat())
		{
			if (!vaporizationQueue.TryDequeue(out Position last))
				continue;

			count++;
			if (count == 200)
			{
				return SolutionPartTwo = (last.X + last.Y * 100).ToString();
			}
		}

		return SolutionPartTwo = "";
	}

	private (Position Position, int VisibleAsteroids) SearchBestLocation()
	{
		var asteroidVisibility = _map.EnumeratePositions(v => v).ToDictionary(p => p, _ => new List<Position>());

		foreach (Position pos in _map.EnumeratePositions(v => v))
		{
			foreach (Position p in _map.EnumeratePositions(v => v, after: pos))
			{
				if (Visible(pos, p))
				{
					asteroidVisibility[pos].Add(p);
					asteroidVisibility[p].Add(pos);
				}
			}
		}

		return asteroidVisibility
			.Select(kvp => (Position: kvp.Key, kvp.Value.Count))
			.OrderByDescending(t => t.Count)
			.First();

		bool Visible(Position a, Position b)
		{
			if (a == b)
				return false;

			int dx = b.X - a.X;
			int dy = b.Y - a.Y;
			int gcd = dx.Gcd(dy);
			var step = new Vector2(dx / gcd, dy / gcd);

			for (Position p = a + step; p != b; p += step)
				if (_map[p])
					return false;

			return true;
		}
	}
}
