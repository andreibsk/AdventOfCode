using AdventOfCode.Year2016;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2016
{
	[TestClass]
	public class Day01Tests : PuzzleTests<Day01>
	{
		[TestMethod]
		[DataRow("R2, L3", "5")]
		[DataRow("R2, R2, R2", "2")]
		[DataRow("R5, L5, R5, R3", "12")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

		[TestMethod]
		[DataRow("R8, R4, R4, R8", "4")]
		public void PartTwoExamples(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
