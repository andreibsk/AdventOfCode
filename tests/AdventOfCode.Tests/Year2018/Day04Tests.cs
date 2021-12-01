using AdventOfCode.Year2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Year2018;

[TestClass]
public class Day04Tests : PuzzleTests<Day04>
{
	private static readonly string[] s_inputs = new[]
	{
			"[1518-11-01 00:00] Guard #10 begins shift",
			"[1518-11-01 00:05] falls asleep",
			"[1518-11-01 00:25] wakes up",
			"[1518-11-01 00:30] falls asleep",
			"[1518-11-01 00:55] wakes up",
			"[1518-11-01 23:58] Guard #99 begins shift",
			"[1518-11-02 00:40] falls asleep",
			"[1518-11-02 00:50] wakes up",
			"[1518-11-03 00:05] Guard #10 begins shift",
			"[1518-11-03 00:24] falls asleep",
			"[1518-11-03 00:29] wakes up",
			"[1518-11-04 00:02] Guard #99 begins shift",
			"[1518-11-04 00:36] falls asleep",
			"[1518-11-04 00:46] wakes up",
			"[1518-11-05 00:03] Guard #99 begins shift",
			"[1518-11-05 00:45] falls asleep",
			"[1518-11-05 00:55] wakes up"
		};

	[TestMethod]
	[DataRow("240")]
	public void PartOneExamples(string expected) => CalculatePartOne(s_inputs, expected);

	[TestMethod]
	[DataRow("4455")]
	public void PartTwoExamples(string expected) => CalculatePartTwo(s_inputs, expected);
}
