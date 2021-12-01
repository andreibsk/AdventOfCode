namespace AdventOfCode.Year2018;

public class Day00 : Puzzle
{
	private readonly string[] _input;

	public Day00(string[] input) : base(input)
	{
		_input = input;
	}

	public override DateTime Date => new DateTime(2018, 12, 00);
	public override string Title => "";

	public override string? CalculateSolution()
	{
		return Solution = "";
	}

	public override string? CalculateSolutionPartTwo()
	{
		return SolutionPartTwo = "";
	}
}
