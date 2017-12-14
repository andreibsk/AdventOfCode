using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day13Tests : PuzzleTests<Day13>
	{
		private static readonly string[] s_input = new[]
		{
			"0: 3",
			"1: 2",
			"4: 4",
			"6: 4"
		};

		[Theory]
		[InlineData("24")]
		public void PartOneExample(string expected) => CalculatePartOne(s_input, expected);

		[Theory]
		[InlineData("10")]
		public void PartTwoExample(string expected) => CalculatePartTwo(s_input, expected);
	}
}
