using Microsoft.VisualStudio.TestTools.UnitTesting;

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

			Assert.AreEqual(expected, solution);
		}

		protected void CalculatePartTwo(string input, string expected) => CalculatePartTwo(new[] { input }, expected);

		protected void CalculatePartTwo(string[] input, string expected)
		{
			var puzzle = new TPuzzle();
			puzzle.SetInput(input);

			string solution = puzzle.CalculateSolutionPartTwo();

			Assert.AreEqual(expected, solution);
		}
	}
}
