using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
	public class Day08Tests : PuzzleTests<Day08>
	{
		private static readonly string[] s_input = new[]
		{
			"b inc 5 if a > 1",
			"a inc 1 if b < 5",
			"c dec -10 if a >= 1",
			"c inc -20 if c == 10"
		};

		[TestMethod]
		[DataRow("1")]
		public void PartOneExample(string expected) => CalculatePartOne(s_input, expected);

		[TestMethod]
		[DataRow("10")]
		public void PartTwoExample(string expected) => CalculatePartTwo(s_input, expected);
	}
}
