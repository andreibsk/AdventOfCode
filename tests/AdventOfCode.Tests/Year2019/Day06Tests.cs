using AdventOfCode.Year2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2019;

[TestClass]
public class Day06Tests : PuzzleTests<Day06>
{
	private static readonly string[] s_input = new[]
	{
		"COM)B",
		"B)C",
		"C)D",
		"D)E",
		"E)F",
		"B)G",
		"G)H",
		"D)I",
		"E)J",
		"J)K",
		"K)L"
	};

	[TestMethod]
	[DataRow("42")]
	public void PartOneExamples(string expected) => CalculatePartOne(s_input, expected);

	[TestMethod]
	[DataRow("4")]
	public void PartTwoExamples(string expected) => CalculatePartTwo(s_input.Append("K)YOU").Append("I)SAN").ToArray(), expected);
}
