using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day05Tests : PuzzleTests<Day05>
	{
		[Theory]
		[InlineData(new[] { "0", "3", "0", "1", "-3" }, "5")]
		public void PartOneExamples(string[] input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData(new[] { "0", "3", "0", "1", "-3" }, "10")]
		public void PartTwoExamples(string[] input, string expected) => CalculatePartTwo(input, expected);
	}
}
