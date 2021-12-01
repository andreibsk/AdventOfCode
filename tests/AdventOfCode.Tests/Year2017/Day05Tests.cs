using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017;

[TestClass]
public class Day05Tests : PuzzleTests<Day05>
{
	[TestMethod]
	[DataRow(new[] { "0", "3", "0", "1", "-3" }, "5")]
	public void PartOneExamples(string[] input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow(new[] { "0", "3", "0", "1", "-3" }, "10")]
	public void PartTwoExamples(string[] input, string expected) => CalculatePartTwo(input, expected);
}
