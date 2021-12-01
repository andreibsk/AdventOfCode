using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017;

[TestClass]
public class Day01Tests : PuzzleTests<Day01>
{
	[TestMethod]
	[DataRow("1122", "3")]
	[DataRow("1111", "4")]
	[DataRow("1234", "0")]
	[DataRow("91212129", "9")]
	public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow("1212", "6")]
	[DataRow("1221", "0")]
	[DataRow("123425", "4")]
	[DataRow("123123", "12")]
	[DataRow("12131415", "4")]
	public void PartTwoExamples(string input, string expected) => CalculatePartTwo(input, expected);
}
