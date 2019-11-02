using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
	public class Day04Tests : PuzzleTests<Day04>
	{
		[TestMethod]
		[DataRow("aa bb cc dd ee", "1")]
		[DataRow("aa bb cc dd aa", "0")]
		[DataRow("aa bb cc dd aaa", "1")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

		[TestMethod]
		[DataRow("abcde fghij", "1")]
		[DataRow("abcde xyz ecdab", "0")]
		[DataRow("a ab abc abd abf abj", "1")]
		[DataRow("iiii oiii ooii oooi oooo", "1")]
		[DataRow("oiii ioii iioi iiio", "0")]
		public void PartTwoExamples(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
