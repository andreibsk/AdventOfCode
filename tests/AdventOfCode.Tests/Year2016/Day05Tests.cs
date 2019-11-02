using AdventOfCode.Year2016;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2016
{
	[TestClass]
	public class Day05Tests : PuzzleTests<Day05>
	{
		[TestMethod]
		[DataRow("abc", "18f47a30")]
		public void PartOneExample(string input, string expected) => CalculatePartOne(input, expected);

		[TestMethod]
		[DataRow("abc", "05ace8e3")]
		public void PartTwoExample(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
