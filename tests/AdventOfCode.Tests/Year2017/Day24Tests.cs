using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
	public class Day24Tests : PuzzleTests<Day24>
	{
		private static readonly string[] s_input = new[]
		{
			"0/2",
			"2/2",
			"2/3",
			"3/4",
			"3/5",
			"0/1",
			"10/1",
			"9/10"
		};

		[TestMethod]
		[DataRow("31")]
		public void PartOneExamples(string expected) => CalculatePartOne(s_input, expected);

		[TestMethod]
		[DataRow("19")]
		public void PartTwoExamples(string expected) => CalculatePartTwo(s_input, expected);
	}
}
