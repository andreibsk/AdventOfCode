using AdventOfCode.Year2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2018;

[TestClass]
public class Day01Tests : PuzzleTests<Day01>
{
	[TestMethod]
	[DataRow(new[] { "+1", "+1", "+1" }, "3")]
	[DataRow(new[] { "+1", "+1", "-2" }, "0")]
	[DataRow(new[] { "-1", "-2", "-3" }, "-6")]
	public void PartOneExamples(string[] input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow(new[] { "+1", "-1" }, "0")]
	[DataRow(new[] { "+3", "+3", "+4", "-2", "-4", }, "10")]
	[DataRow(new[] { "-6", "+3", "+8", "+5", "-6", }, "5")]
	[DataRow(new[] { "+7", "+7", "-2", "-7", "-4", }, "14")]
	public void PartTwoExamples(string[] input, string expected) => CalculatePartTwo(input, expected);
}
