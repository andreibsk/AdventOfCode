using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day01Tests : PuzzleTests<Day01>
	{
		[Theory]
		[InlineData("1122", "3")]
		[InlineData("1111", "4")]
		[InlineData("1234", "0")]
		[InlineData("91212129", "9")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData("1212", "6")]
		[InlineData("1221", "0")]
		[InlineData("123425", "4")]
		[InlineData("123123", "12")]
		[InlineData("12131415", "4")]
		public void PartTwoExamples(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
