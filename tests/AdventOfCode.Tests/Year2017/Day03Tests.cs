using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day03Tests : PuzzleTests<Day03>
	{
		[Theory]
		[InlineData("1", "0")]
		[InlineData("12", "3")]
		[InlineData("23", "2")]
		[InlineData("1024", "31")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData("1", "2")]
		[InlineData("2", "4")]
		[InlineData("6", "10")]
		[InlineData("10", "11")]
		[InlineData("805", "806")]
		public void PartTwoTest(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
