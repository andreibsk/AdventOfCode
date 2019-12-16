using AdventOfCode.Year2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2019
{
	[TestClass]
	public class Day16Tests : PuzzleTests<Day16>
	{
		[TestMethod]
		[DataRow("80871224585914546619083218645595", "24176176")]
		[DataRow("19617804207202209144916044189917", "73745418")]
		[DataRow("69317163492948606335995924319873", "52432133")]
		public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);

		[TestMethod]
		[DataRow("03081770884921959731165446850517", "53553731")]
		[DataRow("02935109699940807407585447034323", "78725270")]
		[DataRow("03036732577212944063491565474664", "84462026")]
		public void PartTwoExamples(string input, string expected) => CalculatePartTwo(input, expected);
	}
}
