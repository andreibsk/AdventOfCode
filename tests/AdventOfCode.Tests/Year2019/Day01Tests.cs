using AdventOfCode.Year2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2019
{
	[TestClass]
	public class Day01Tests : PuzzleTests<Day01>
	{
		[TestMethod]
		[DataRow("12", "2")]
		[DataRow("14", "2")]
		[DataRow("1969", "654")]
		[DataRow("100756", "33583")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

		[TestMethod]
		[DataRow("12", "2")]
		[DataRow("14", "2")]
		[DataRow("1969", "966")]
		[DataRow("100756", "50346")]
		public void PartTwoExamples(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
