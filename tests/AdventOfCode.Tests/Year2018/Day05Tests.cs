using AdventOfCode.Year2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2018
{
	[TestClass]
	public class Day05Tests : PuzzleTests<Day05>
	{
		[TestMethod]
		[DataRow("dabAcCaCBAcCcaDA", "10")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

		[TestMethod]
		[DataRow("dabAcCaCBAcCcaDA", "4")]
		public void PartTwoExamples(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
