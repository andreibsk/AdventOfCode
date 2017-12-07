using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day06Tests : PuzzleTests<Day06>
	{
		[Theory]
		[InlineData("0 2 7 0", "5")]
		public void PartOneExample(string input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData("0 2 7 0", "4")]
		public void PartTwoExample(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
