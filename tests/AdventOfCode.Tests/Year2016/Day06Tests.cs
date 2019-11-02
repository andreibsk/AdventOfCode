using AdventOfCode.Year2016;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2016
{
	[TestClass]
	public class Day06Tests : PuzzleTests<Day06>
	{
		private static readonly string[] s_input = new[]
		{
			"eedadn",
			"drvtee",
			"eandsr",
			"raavrd",
			"atevrs",
			"tsrnev",
			"sdttsa",
			"rasrtv",
			"nssdts",
			"ntnada",
			"svetve",
			"tesnvt",
			"vntsnd",
			"vrdear",
			"dvrsen",
			"enarar"
		};

		[TestMethod]
		[DataRow("easter")]
		public void PartOneExample(string expected) => CalculatePartOne(s_input, expected);

		[TestMethod]
		[DataRow("advent")]
		public void PartTwoExample(string expected) => CalculatePartTwo(s_input, expected);
	}
}
