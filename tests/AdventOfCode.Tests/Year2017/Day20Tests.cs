using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017;

[TestClass]
public class Day20Tests : PuzzleTests<Day20>
{
	[TestMethod]
	[DataRow(new[]
	{
			"p=<3,0,0>, v=<2,0,0>, a=<-1,0,0>",
			"p=<4,0,0>, v=<0,0,0>, a=<-2,0,0>"
		}, "0")]
	public void PartOneExamples(string[] input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow(new[]
	{
			"p=<-6,0,0>, v=<3,0,0>, a=<0,0,0>",
			"p=<-4,0,0>, v=<2,0,0>, a=<0,0,0>",
			"p=<-2,0,0>, v=<1,0,0>, a=<0,0,0>",
			"p=<3,0,0>, v=<-1,0,0>, a=<0,0,0>",
		}, "1")]
	public void PartTwoExamples(string[] input, string expected) => CalculatePartTwo(input, expected);
}
