using AdventOfCode.Year2016;
using Xunit;

namespace AdventOfCode.Tests.Year2016
{
	public class Day03Tests : PuzzleTests<Day03>
	{
		[Theory]
		[InlineData(new[] { "5 10 25" }, "0")]
		public void PartOneExample(string[] input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData(
			new[] { "101 301 501", "102 302 502", "103 303 503", "201 401 601", "202 402 602", "203 403 603" },
			"6")]
		public void PartTwoExample(string[] input, string expected) => CalculatePartTwo(input, expected);
	}
}
