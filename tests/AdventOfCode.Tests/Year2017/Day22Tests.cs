using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
	public class Day22Tests : PuzzleTests<Day22>
	{
		private static readonly string[] s_input = new[]
		{
			"..#",
			"#..",
			"..."
		};

		[TestMethod]
		[DataRow("5587")]
		public void PartOneExamples(string expected) => CalculatePartOne(s_input, expected);

		[TestMethod]
		[DataRow("2511944")]
		public void PartTwoExamples(string expected) => CalculatePartTwo(s_input, expected);
	}
}
