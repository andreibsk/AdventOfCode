using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
	public class Day15Tests : PuzzleTests<Day15>
	{
		[TestMethod]
		[DataRow(new[] { "65", "8921" }, "588")]
		public void PartOneExamples(string[] input, string expected) => CalculatePartOne(input, expected);

		[TestMethod]
		[DataRow(new[] { "65", "8921" }, "309")]
		public void PartTwoExamples(string[] input, string expected) => CalculatePartTwo(input, expected);
	}
}
