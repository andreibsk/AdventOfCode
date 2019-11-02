using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
	public class Day09Tests : PuzzleTests<Day09>
	{
		[TestMethod]
		[DataRow("{}", "1")]
		[DataRow("{{{}}}", "6")]
		[DataRow("{{},{}}", "5")]
		[DataRow("{{{},{},{{}}}}", "16")]
		[DataRow("{<a>,<a>,<a>,<a>}", "1")]
		[DataRow("{{<ab>},{<ab>},{<ab>},{<ab>}}", "9")]
		[DataRow("{{<!!>},{<!!>},{<!!>},{<!!>}}", "9")]
		[DataRow("{{<a!>},{<a!>},{<a!>},{<ab>}}", "3")]
		public void PartOneExample(string input, string expected) => CalculatePartOne(input, expected);

		[TestMethod]
		[DataRow("<>", "0")]
		[DataRow("<random characters>", "17")]
		[DataRow("<<<<>", "3")]
		[DataRow("<{!>}>", "2")]
		[DataRow("<!!>", "0")]
		[DataRow("<!!!>>", "0")]
		[DataRow("<{o\"i!a,<{i<a>", "10")]
		public void PartTwoExample(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
