using System;
using System.Linq;
using AdventOfCode.Year2016;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2016;

[TestClass]
public class Day08Tests : PuzzleTests<Day08>
{
	private static readonly string[] s_input = new[]
	{
			"rect 3x2",
			"rotate column x=1 by 1",
			"rotate row y=0 by 4",
			"rotate column x=1 by 1"
		};

	private static readonly string s_output = string.Join(Environment.NewLine, new[]
	{
			"....#.#" + string.Concat(Enumerable.Repeat('.', 43)),
			"#.#...." + string.Concat(Enumerable.Repeat('.', 43)),
			".#....." + string.Concat(Enumerable.Repeat('.', 43)),
			".#....." + string.Concat(Enumerable.Repeat('.', 43)),
			string.Concat(Enumerable.Repeat('.', 50)),
			string.Concat(Enumerable.Repeat('.', 50))
		});

	[TestMethod]
	[DataRow("6")]
	public void PartOneExample(string expected) => CalculatePartOne(s_input, expected);

	[TestMethod]
	public void PartTwoExample() => CalculatePartTwo(s_input, s_output);
}
