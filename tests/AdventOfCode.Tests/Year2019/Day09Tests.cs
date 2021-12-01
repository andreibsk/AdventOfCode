using AdventOfCode.Year2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2019;

[TestClass]
public class Day09Tests : PuzzleTests<Day09>
{
	[TestMethod]
	[DataRow("109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99", "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99")]
	[DataRow("104,1125899906842624,99", "1125899906842624")]
	public void PartOneExamples(string input, string expected) => CalculatePartOne(input, expected);
}
