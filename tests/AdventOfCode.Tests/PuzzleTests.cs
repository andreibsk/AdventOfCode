using Xunit;

namespace AdventOfCode.Tests
{
	public abstract class PuzzleTests<TPuzzle> where TPuzzle : Puzzle, new()
	{
		protected void CalculatePartOne(string input, string expected) => CalculatePartOne(new[] { input }, expected);

		protected void CalculatePartOne(string[] input, string expected)
		{
			var puzzle = new TPuzzle();
			puzzle.SetInput(input);

			string solution = puzzle.CalculateSolution();

			Assert.Equal(expected, solution);
		}

		protected void CalculatePartTwo(string input, string expected) => CalculatePartTwo(new[] { input }, expected);

		protected void CalculatePartTwo(string[] input, string expected)
		{
			var puzzle = new TPuzzle();
			puzzle.SetInput(input);

			string solution = puzzle.CalculateSolutionPartTwo();

			Assert.Equal(expected, solution);
		}
	}
}
