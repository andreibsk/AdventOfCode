using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017
{
	[TestClass]
	public class Day11Tests : PuzzleTests<Day11>
	{
		[TestMethod]
		[DataRow("ne,ne,ne", "3")]
		[DataRow("ne,ne,sw,sw", "0")]
		[DataRow("ne,ne,s,s", "2")]
		[DataRow("se,sw,se,sw,sw", "3")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);
	}
}
