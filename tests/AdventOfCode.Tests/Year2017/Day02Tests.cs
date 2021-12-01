using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017;

[TestClass]
public class Day02Tests : PuzzleTests<Day02>
{
	[TestMethod]
	[DataRow(new[] { "5 1 9 5", "7 5 3", "2 4 6 8" }, "18")]
	public void PartOneExample(string[] input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow(new[] { "5 9 2 8", "9 4 7 3", "3 8 6 5" }, "9")]
	public void PartTwoExample(string[] input, string expected) => CalculatePartTwo(input, expected);
}
