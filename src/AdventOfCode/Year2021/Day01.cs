namespace AdventOfCode.Year2021;

public class Day01 : Puzzle
{
	private readonly int[] _measurements;

	public Day01(string[] input) : base(input)
	{
		_measurements = input.Select(int.Parse).ToArray();
	}

	public override DateTime Date => new DateTime(2021, 12, 01);
	public override string Title => "Sonar Sweep";

	public override string? CalculateSolution()
	{
		return Solution = _measurements
			.Zip(_measurements.Skip(1))
			.Count(p => p.First < p.Second)
			.ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		return SolutionPartTwo = Enumerable
			.Range(0, _measurements.Length - 3)
			.Count(i => _measurements[i..(i + 3)].Sum() < _measurements[(i + 1)..(i + 4)].Sum())
			.ToString();
	}
}
