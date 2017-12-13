using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day11Tests : PuzzleTests<Day11>
	{
		[Theory]
		[InlineData("ne,ne,ne", "3")]
		[InlineData("ne,ne,sw,sw", "0")]
		[InlineData("ne,ne,s,s", "2")]
		[InlineData("se,sw,se,sw,sw", "3")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);
	}
}
