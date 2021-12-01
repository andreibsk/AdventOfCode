using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017;

[TestClass]
public class Day16Tests : PuzzleTests<Day16>
{
	[TestMethod]
	[DataRow("s1,x3/4,pe/b", "paedcbfghijklmno")]
	public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);
}
