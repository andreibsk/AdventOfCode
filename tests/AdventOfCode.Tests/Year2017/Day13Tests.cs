using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
	public class Day13Tests : PuzzleTests<Day13>
	{
		private static readonly string[] s_input = new[]
		{
			"0: 3",
			"1: 2",
			"4: 4",
			"6: 4"
		};

		[TestMethod]
		[DataRow("24")]
		public void PartOneExample(string expected) => CalculatePartOne(s_input, expected);

		[TestMethod]
		[DataRow("10")]
		public void PartTwoExample(string expected) => CalculatePartTwo(s_input, expected);
	}
}
