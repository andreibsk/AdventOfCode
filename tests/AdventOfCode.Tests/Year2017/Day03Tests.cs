using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
	public class Day03Tests : PuzzleTests<Day03>
	{
		[TestMethod]
		[DataRow("1", "0")]
		[DataRow("12", "3")]
		[DataRow("23", "2")]
		[DataRow("1024", "31")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

		[TestMethod]
		[DataRow("1", "2")]
		[DataRow("2", "4")]
		[DataRow("6", "10")]
		[DataRow("10", "11")]
		[DataRow("805", "806")]
		public void PartTwoTest(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
