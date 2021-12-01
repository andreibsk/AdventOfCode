using AdventOfCode.Year2016;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2016;

[TestClass]
public class Day02Tests : PuzzleTests<Day02>
{
	[TestMethod]
	[DataRow(new[] { "ULL", "RRDDD", "LURDL", "UUUUD" }, "1985")]
	public void PartOneExample(string[] input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow(new[] { "ULL", "RRDDD", "LURDL", "UUUUD" }, "5DB3")]
	public void PartTwoExample(string[] input, string expected) => CalculatePartTwo(input, expected);
}
