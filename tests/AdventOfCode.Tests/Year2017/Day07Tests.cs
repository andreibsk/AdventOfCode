using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
	public class Day07Tests : PuzzleTests<Day07>
	{
		private static readonly string[] s_input = new[]
		{
			"pbga (66)",
			"xhth (57)",
			"ebii (61)",
			"havc (66)",
			"ktlj (57)",
			"fwft (72) -> ktlj, cntj, xhth",
			"qoyq (66)",
			"padx (45) -> pbga, havc, qoyq",
			"tknk (41) -> ugml, padx, fwft",
			"jptl (61)",
			"ugml (68) -> gyxo, ebii, jptl",
			"gyxo (61)",
			"cntj (57)"
		};

		[TestMethod]
		[DataRow("tknk")]
		public void PartOneExample(string expected) => CalculatePartOne(s_input, expected);

		[TestMethod]
		[DataRow("60")]
		public void PartTwoExample(string expected) => CalculatePartTwo(s_input, expected);
	}
}
