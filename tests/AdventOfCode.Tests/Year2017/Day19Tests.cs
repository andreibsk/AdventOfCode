using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017;

[TestClass]
public class Day19Tests : PuzzleTests<Day19>
{
	private static readonly string[] s_input = new[]
	{
			"     |          ",
			"     |  +--+    ",
			"     A  |  C    ",
			" F---|----E|--+ ",
			"     |  |  |  D ",
			"     +B-+  +--+ "
		};

	[TestMethod]
	[DataRow("ABCDEF")]
	public void PartOneExamples(string expected) => CalculatePartOne(s_input, expected);

	[TestMethod]
	[DataRow("38")]
	public void PartTwoExamples(string expected) => CalculatePartTwo(s_input, expected);
}
