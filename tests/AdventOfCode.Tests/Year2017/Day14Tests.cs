using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017;

[TestClass]
public class Day14Tests : PuzzleTests<Day14>
{
	[TestMethod]
	[DataRow("flqrgnkx", "8108")]
	public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow("flqrgnkx", "1242")]
	public void PartTwoExamples(string input, string expected) => CalculatePartTwo(input, expected);
}
