using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day04Tests : PuzzleTests<Day04>
	{
		[Theory]
		[InlineData("aa bb cc dd ee", "1")]
		[InlineData("aa bb cc dd aa", "0")]
		[InlineData("aa bb cc dd aaa", "1")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData("abcde fghij", "1")]
		[InlineData("abcde xyz ecdab", "0")]
		[InlineData("a ab abc abd abf abj", "1")]
		[InlineData("iiii oiii ooii oooi oooo", "1")]
		[InlineData("oiii ioii iioi iiio", "0")]
		public void PartTwoExamples(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
