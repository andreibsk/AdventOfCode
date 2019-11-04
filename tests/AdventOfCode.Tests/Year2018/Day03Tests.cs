using AdventOfCode.Year2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2018
{
	[TestClass]
	public class Day03Tests : PuzzleTests<Day03>
	{
		[TestMethod]
		[DataRow(new[]
		{
			"#1 @ 1,3: 4x4",
			"#2 @ 3,1: 4x4",
			"#3 @ 5,5: 2x2",
		}, "4")]
		public void PartOneExamples(string[] input, string expected) => CalculatePartOne(input, expected);

		[TestMethod]
		[DataRow(new[]
		{
			"#1 @ 1,3: 4x4",
			"#2 @ 3,1: 4x4",
			"#3 @ 5,5: 2x2",
		}, "3")]
		public void PartTwoExamples(string[] input, string expected) => CalculatePartTwo(input, expected);
	}
}
