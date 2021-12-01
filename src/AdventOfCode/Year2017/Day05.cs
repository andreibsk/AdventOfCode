namespace AdventOfCode.Year2017;

public class Day05 : Puzzle
{
	private readonly int[] _jumpOffsets;

	public Day05(string[] input) : base(input)
	{
		_jumpOffsets = input.Select(int.Parse).ToArray();
	}

	public override DateTime Date => new DateTime(2017, 12, 5);
	public override string Title => "A Maze of Twisty Trampolines, All Alike";

	public override string? CalculateSolution()
	{
		int[] jumps = (int[])_jumpOffsets.Clone();
		int count = 0;

		for (int i = 0; i >= 0 && i < jumps.Length; i += jumps[i]++) count++;

		Solution = count.ToString();
		return Solution;
	}

	public override string? CalculateSolutionPartTwo()
	{
		int[] jumps = (int[])_jumpOffsets.Clone();
		int count = 0;

		for (int i = 0; i >= 0 && i < jumps.Length;)
		{
			i += jumps[i] > 2 ? jumps[i]-- : jumps[i]++;
			count++;
		}

		SolutionPartTwo = count.ToString();
		return SolutionPartTwo;
	}
}
