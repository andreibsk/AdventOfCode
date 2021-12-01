using AdventOfCode.Year2016;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2016;

[TestClass]
public class Day07Tests : PuzzleTests<Day07>
{
	[TestMethod]
	[DataRow(new[] { "abba[mnop]qrst" }, "1")]
	[DataRow(new[] { "abcd[bddb]xyyx" }, "0")]
	[DataRow(new[] { "aaaa[qwer]tyui" }, "0")]
	[DataRow(new[] { "ioxxoj[asdfgh]zxcvbn" }, "1")]
	public void PartOneExample(string[] input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow(new[] { "aba[bab]xyz" }, "1")]
	[DataRow(new[] { "xyx[xyx]xyx" }, "0")]
	[DataRow(new[] { "aaa[kek]eke" }, "1")]
	[DataRow(new[] { "zazbz[bzb]cdb" }, "1")]
	public void PartTwoExample(string[] input, string expected) => CalculatePartTwo(input, expected);
}
