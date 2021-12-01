using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017;

[TestClass]
public class Day10Tests : PuzzleTests<Day10>
{
	[TestMethod]
	[DataRow(new[] { "3,4,1,5", "5" }, "12")]
	public void PartOneExample(string[] input, string expected) => CalculatePartOne(input, expected);
}
