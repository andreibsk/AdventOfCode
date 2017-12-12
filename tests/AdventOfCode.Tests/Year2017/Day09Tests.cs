using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day09Tests : PuzzleTests<Day09>
	{
		[Theory]
		[InlineData("{}", "1")]
		[InlineData("{{{}}}", "6")]
		[InlineData("{{},{}}", "5")]
		[InlineData("{{{},{},{{}}}}", "16")]
		[InlineData("{<a>,<a>,<a>,<a>}", "1")]
		[InlineData("{{<ab>},{<ab>},{<ab>},{<ab>}}", "9")]
		[InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", "9")]
		[InlineData("{{<a!>},{<a!>},{<a!>},{<ab>}}", "3")]
		public void PartOneExample(string input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData("<>", "0")]
		[InlineData("<random characters>", "17")]
		[InlineData("<<<<>", "3")]
		[InlineData("<{!>}>", "2")]
		[InlineData("<!!>", "0")]
		[InlineData("<!!!>>", "0")]
		[InlineData("<{o\"i!a,<{i<a>", "10")]
		public void PartTwoExample(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
