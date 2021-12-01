using AdventOfCode.Year2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2018;

[TestClass]
public class Day02Tests : PuzzleTests<Day02>
{
	[TestMethod]
	[DataRow(new[]
	{
			"abcdef",
			"bababc",
			"abbcde",
			"abcccd",
			"aabcdd",
			"abcdee",
			"ababab",
		}, "12")]
	public void PartOneExamples(string[] input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow(new[]
	{
			"abcde",
			"fghij",
			"klmno",
			"pqrst",
			"fguij",
			"axcye",
			"wvxyz"
		}, "fgij")]
	public void PartTwoExamples(string[] input, string expected) => CalculatePartTwo(input, expected);
}
