namespace AdventOfCode.Year2019;

public class Day09 : Puzzle
{
	private readonly long[] _initialMemory;

	public Day09(string[] input) : base(input)
	{
		_initialMemory = input[0].Split(',').Select(long.Parse).ToArray();
	}

	public override DateTime Date => new DateTime(2019, 12, 09);

	public override string Title => "Sensor Boost";

	public override string? CalculateSolution()
	{
		return Solution = string.Join(',', new IntcodeComputer(_initialMemory).Execute(input: 1L));
	}

	public override string? CalculateSolutionPartTwo()
	{
		return Solution = string.Join(',', new IntcodeComputer(_initialMemory).Execute(input: 2L));
	}
}
