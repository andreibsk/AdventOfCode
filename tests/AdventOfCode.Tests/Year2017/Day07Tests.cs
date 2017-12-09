using AdventOfCode.Year2017;
using Xunit;

namespace AdventOfCode.Tests.Year2017
{
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

		[Theory]
		[InlineData("tknk")]
		public void PartOneExample(string expected) => CalculatePartOne(s_input, expected);

		[Theory]
		[InlineData("60")]
		public void PartTwoExample(string expected) => CalculatePartTwo(s_input, expected);
	}
}
