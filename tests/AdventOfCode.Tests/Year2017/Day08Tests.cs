using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day08Tests : PuzzleTests<Day08>
	{
		private static readonly string[] s_input = new[]
		{
			"b inc 5 if a > 1",
			"a inc 1 if b < 5",
			"c dec -10 if a >= 1",
			"c inc -20 if c == 10"
		};

		[Theory]
		[InlineData("1")]
		public void PartOneExample(string expected) => CalculatePartOne(s_input, expected);

		[Theory]
		[InlineData("10")]
		public void PartTwoExample(string expected) => CalculatePartTwo(s_input, expected);
	}
}
