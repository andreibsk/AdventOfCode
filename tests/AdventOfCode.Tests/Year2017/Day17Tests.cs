using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
	public class Day17Tests : PuzzleTests<Day17>
	{
		[TestMethod]
		[DataRow("3", "638")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);
	}
}
