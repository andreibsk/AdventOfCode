using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
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

		[TestMethod]
		[DataRow("6")]
		public void PartOneExample(string expected) => CalculatePartOne(s_input, expected);

		[TestMethod]
		[DataRow("2")]
		public void PartTwoExample(string expected) => CalculatePartTwo(s_input, expected);
	}
}
