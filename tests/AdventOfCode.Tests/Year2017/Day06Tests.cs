using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017;

[TestClass]
public class Day06Tests : PuzzleTests<Day06>
{
	[TestMethod]
	[DataRow("0 2 7 0", "5")]
	public void PartOneExample(string input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow("0 2 7 0", "4")]
	public void PartTwoExample(string input, string expected) => CalculatePartTwo(input, expected);
}
