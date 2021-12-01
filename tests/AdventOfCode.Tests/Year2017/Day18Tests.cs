using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017;

[TestClass]
public class Day18Tests : PuzzleTests<Day18>
{
	[TestMethod]
	[DataRow(new[]
	{
			"set a 1",
			"add a 2",
			"mul a a",
			"mod a 5",
			"snd a",
			"set a 0",
			"rcv a",
			"jgz a -1",
			"set a 1",
			"jgz a -2",
		}, "4")]
	public void PartOneExamples(string[] input, string expected) => CalculatePartOne(input, expected);

	[TestMethod]
	[DataRow(new[]
	{
			"snd 1",
			"snd 2",
			"snd p",
			"rcv a",
			"rcv b",
			"rcv c",
			"rcv d"
		}, "3")]
	public void PartTwoExamples(string[] input, string expected) => CalculatePartTwo(input, expected);
}
