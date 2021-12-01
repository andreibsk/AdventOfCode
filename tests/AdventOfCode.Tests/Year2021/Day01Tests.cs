using AdventOfCode.Year2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2021;

[TestClass]
public class Day01Tests : PuzzleTests<Day01>
{
	private static readonly string[] s_input = new[]
	{
		"199",
		"200",
		"208",
		"210",
		"200",
		"207",
		"240",
		"269",
		"260",
		"263"
	};

	[TestMethod]
	[DataRow("7")]
	public void PartOneExamples(string expected) => CalculatePartOne(s_input, expected);

	[TestMethod]
	[DataRow("5")]
	public void PartTwoExamples(string expected) => CalculatePartTwo(s_input, expected);
}
