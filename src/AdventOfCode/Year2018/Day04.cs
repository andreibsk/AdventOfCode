using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2018;

public class Day04 : Puzzle
{
	private readonly GuardLog[] _logs;

	public Day04(string[] input) : base(input)
	{
		_logs = input.Select(GuardLog.Parse).OrderBy(l => l.Time).ToArray();
	}

	public override DateTime Date => new DateTime(2018, 12, 04);
	public override string Title => "Repose Record";

	public override string? CalculateSolution()
	{
		IDictionary<int, int[]> timetable = BuildTimetable();

		int guardId = timetable
			.OrderByDescending(kvp => kvp.Value.Sum())
			.First().Key;

		int minute = timetable[guardId].IndexOfMaxValue();

		return Solution = (guardId * minute).ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		IDictionary<int, int[]> timetable = BuildTimetable();

		return SolutionPartTwo = timetable
			.Select(kvp => (Kvp: kvp, MaxIndex: kvp.Value.IndexOfMaxValue()))
			.OrderByDescending(t => t.Kvp.Value[t.MaxIndex])
			.Select(t => t.Kvp.Key * t.MaxIndex)
			.First()
			.ToString();
	}

	private IDictionary<int, int[]> BuildTimetable()
	{
		IDictionary<int, int[]> timetable = new Dictionary<int, int[]>();

		int? id = null;
		int? startTime = null;
		foreach (GuardLog log in _logs)
		{
			if (log.Action == GuardLog.GuardAction.BeginsShift)
			{
				id = log.Id!.Value;
				startTime = null;
			}
			else if (log.Action == GuardLog.GuardAction.FallsAsleep)
			{
				startTime = log.Time.Minute;
			}
			else if (log.Action == GuardLog.GuardAction.WakesUp)
			{
				if (!timetable.TryGetValue(id!.Value, out int[]? times))
				{
					timetable[id!.Value] = times = new int[60];
				}

				for (int i = startTime!.Value; i < log.Time.Minute; i++)
					times[i]++;
			}
		}

		return timetable;
	}

	private class GuardLog
	{
		private static readonly Regex s_regex = new Regex(
			@"^\[(?<year>\d{4})-(?<month>\d\d)-(?<day>\d\d) (?<hour>\d\d):(?<minute>\d\d)\] (Guard #(?<id>\d+) )?(?<action>begins shift|falls asleep|wakes up)$",
			RegexOptions.Compiled);

		private GuardLog(DateTime time, int? id, GuardAction action)
		{
			Time = time;
			Id = id;
			Action = action;
		}

		public enum GuardAction
		{
			BeginsShift,
			FallsAsleep,
			WakesUp
		}

		public GuardAction Action { get; }
		public int? Id { get; set; }
		public DateTime Time { get; }

		public static GuardLog Parse(string str)
		{
			Match match = s_regex.Match(str);
			if (!match.Success)
				throw new FormatException();

			return new GuardLog(
				new DateTime(
					int.Parse(match.Groups["year"].Value),
					int.Parse(match.Groups["month"].Value),
					int.Parse(match.Groups["day"].Value),
					int.Parse(match.Groups["hour"].Value),
					int.Parse(match.Groups["minute"].Value),
					second: 0),
				match.Groups["id"].Success ? int.Parse(match.Groups["id"].Value) : (int?)null,
				match.Groups["action"].Value switch
				{
					"begins shift" => GuardAction.BeginsShift,
					"falls asleep" => GuardAction.FallsAsleep,
					"wakes up" => GuardAction.WakesUp,
					_ => throw new FormatException()
				});
		}
	}
}
