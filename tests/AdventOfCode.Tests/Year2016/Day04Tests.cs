using AdventOfCode.Year2016;
using Xunit;

namespace AdventOfCode.Tests.Year2016
{
	public class Day04Tests : PuzzleTests<Day04>
	{
		[Theory]
		[InlineData(new[] { "aaaaa-bbb-z-y-x-123[abxyz]", "a-b-c-d-e-f-g-h-987[abcde]", "not-a-real-room-404[oarel]",
			"totally-real-room-200[decoy]" }, "1514")]
		public void PartOneExample(string[] input, string expected) => CalculatePartOne(input, expected);

		[Theory]
		[InlineData(
			new[] { "ghkmaihex-hucxvm-lmhktzx-267[xxxxx]" }, "267")]
		public void PartTwoExample(string[] input, string expected) => CalculatePartTwo(input, expected);
	}
}
