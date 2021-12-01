using AdventOfCode.Year2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2016;

[TestClass]
public class Day00Tests : PuzzleTests<Day00>
{
	private static readonly string[] s_input = new[]
	{
			""
		};

	[TestMethod]
	[DataRow("", "")]
	public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow("")]
	public void PartOneExamples(string expected) => CalculatePartOne(s_input, expected);

	[TestMethod]
	[DataRow(new[]
	{
			""
		}, "")]
	public void PartOneExamples(string[] input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow(new[]
	{
			""
		}, "")]
	public void PartTwoExamples(string[] input, string expected) => CalculatePartTwo(input, expected);

	[TestMethod]
	[DataRow("")]
	public void PartTwoExamples(string expected) => CalculatePartTwo(s_input, expected);

	[TestMethod]
	[DataRow("", "")]
	public void PartTwoExamples(string input, string expected) => CalculatePartTwo(input, expected);
}
