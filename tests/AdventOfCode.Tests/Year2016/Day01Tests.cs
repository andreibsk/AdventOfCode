using AdventOfCode.Year2016;
using Xunit;

namespace AdventOfCode.Tests.Year2016
{
	public class Day01Tests : PuzzleTests<Day01>
	{
		[Theory]
		[InlineData("R2, L3", "5")]
		[InlineData("R2, R2, R2", "2")]
		[InlineData("R5, L5, R5, R3", "12")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData("R8, R4, R4, R8", "4")]
		public void PartTwoExamples(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
