using AdventOfCode.Year2016;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2016
{
	[TestClass]
	public class Day04Tests : PuzzleTests<Day04>
	{
		[TestMethod]
		[DataRow(new[] { "aaaaa-bbb-z-y-x-123[abxyz]", "a-b-c-d-e-f-g-h-987[abcde]", "not-a-real-room-404[oarel]",
			"totally-real-room-200[decoy]" }, "1514")]
		public void PartOneExample(string[] input, string expected) => CalculatePartOne(input, expected);

		[TestMethod]
		[DataRow(
			new[] { "ghkmaihex-hucxvm-lmhktzx-267[xxxxx]" }, "267")]
		public void PartTwoExample(string[] input, string expected) => CalculatePartTwo(input, expected);
	}
}
