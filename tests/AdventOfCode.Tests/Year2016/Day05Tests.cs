using AdventOfCode.Year2016;
using Xunit;

namespace AdventOfCode.Tests.Year2016
{
	public class Day05Tests : PuzzleTests<Day05>
	{
		[Theory]
		[InlineData("abc", "18f47a30")]
		public void PartOneExample(string input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData("abc", "05ace8e3")]
		public void PartTwoExample(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
