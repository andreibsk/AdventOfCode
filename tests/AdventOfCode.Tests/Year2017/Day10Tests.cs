using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day10Tests : PuzzleTests<Day10>
	{
		[Theory]
		[InlineData(new[] { "3,4,1,5", "5" }, "12")]
		public void PartOneExample(string[] input, string expected) => CalculatePartOne(input, expected);
	}
}
