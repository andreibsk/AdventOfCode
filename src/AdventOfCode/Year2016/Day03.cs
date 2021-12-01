namespace AdventOfCode.Year2016;

public class Day03 : Puzzle
{
	private readonly int[][] _triangles;

	public Day03(string[] input) : base(input)
	{
		_triangles = input.Select(s =>
		{
			int[] t = s
				.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();
			if (t.Length != 3) throw new FormatException("Expected three integers");
			return t;
		}).ToArray();
	}

	public override DateTime Date => new DateTime(2016, 12, 3);
	public override string Title => "Squares With Three Sides";

	public override string? CalculateSolution()
	{
		Solution = _triangles.Where(IsTriangleValid).Count().ToString();
		return Solution;
	}

	public override string? CalculateSolutionPartTwo()
	{
		SolutionPartTwo = Enumerable.Empty<int>()
			.Concat(_triangles.Select(row => row[0]))
			.Concat(_triangles.Select(row => row[1]))
			.Concat(_triangles.Select(row => row[2]))
			.Select((elem, index) => (elem, index / 3))
			.GroupBy(tuple => tuple.Item2)
			.Select(gr => gr.Select(tuple => tuple.elem).ToArray())
			.Where(IsTriangleValid)
			.Count().ToString();
		return SolutionPartTwo;
	}

	private static bool IsTriangleValid(int[] triangle)
	{
		if (triangle.Length != 3) throw new ArgumentOutOfRangeException(nameof(triangle));
		return triangle[0] + triangle[1] > triangle[2]
			&& triangle[0] + triangle[2] > triangle[1]
			&& triangle[1] + triangle[2] > triangle[0];
	}
}
