using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
	public class Day12Tests : PuzzleTests<Day12>
	{
		private static readonly string[] s_input = new[]
		{
			"0 <-> 2",
			"1 <-> 1",
			"2 <-> 0, 3, 4",
			"3 <-> 2, 4",
			"4 <-> 2, 3, 6",
			"5 <-> 6",
			"6 <-> 4, 5"
		};

		[Theory]
		[InlineData("6")]
		public void PartOneExample(string expected) => CalculatePartOne(s_input, expected);

		[Theory]
		[InlineData("2")]
		public void PartTwoExample(string expected) => CalculatePartTwo(s_input, expected);
	}
}
