using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day02Tests : PuzzleTests<Day02>
	{
		[Theory]
		[InlineData(new[] { "5 1 9 5", "7 5 3", "2 4 6 8"}, "18")]
		public void PartOneExample(string[] input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData(new[] { "5 9 2 8", "9 4 7 3", "3 8 6 5" }, "9")]
		public void PartTwoExample(string[] input, string expected) => CalculatePartTwo(input, expected);
	}
}
