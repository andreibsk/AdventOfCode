using AdventOfCode.Year2016;
using Xunit;

namespace AdventOfCode.Tests.Year2016
{
	public class Day02Tests : PuzzleTests<Day02>
	{
		[Theory]
		[InlineData(new[] { "ULL", "RRDDD", "LURDL", "UUUUD" }, "1985")]
		public void PartOneExample(string[] input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData(new[] { "ULL", "RRDDD", "LURDL", "UUUUD" }, "5DB3")]
		public void PartTwoExample(string[] input, string expected) => CalculatePartTwo(input, expected);
	}
}
