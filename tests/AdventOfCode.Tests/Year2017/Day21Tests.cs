using AdventOfCode.Year2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2017;

[TestClass]
public class Day21Tests : PuzzleTests<Day21>
{
	private static readonly string[] s_input = new[]
	{
			"../.# => ##./#../...",
			".#./..#/### => #..#/..../..../#..#"
		};

	[TestMethod]
	[DataRow("12", "2")]
	public void PartOneExamples(string expected, string config) => CalculatePartOne(s_input, expected, config);
}
