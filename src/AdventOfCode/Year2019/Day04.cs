using System;
using System.Linq;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2019;

public class Day04 : Puzzle
{
	private readonly int _end;
	private readonly int _start;

	public Day04(string[] input) : base(input)
	{
		_start = int.Parse(input[0].Split('-')[0]);
		_end = int.Parse(input[0].Split('-')[1]);
	}

	public override DateTime Date => new DateTime(2019, 12, 04);
	public override string Title => "Secure Container";

	public override string CalculateSolution()
	{
		int count = 0;
		for (int n = _start; n <= _end; n++)
		{
			string s = n.ToString();
			if (s[0] > s[1] || s[1] > s[2] || s[2] > s[3] || s[3] > s[4] || s[4] > s[5])
				continue;

			if (s[0] != s[1] && s[1] != s[2] && s[2] != s[3] && s[3] != s[4] && s[4] != s[5])
				continue;

			count++;
		}
		return Solution = count.ToString();
	}

	public override string CalculateSolutionPartTwo()
	{
		int count = 0;
		for (int n = _start; n <= _end; n++)
		{
			string s = n.ToString();

			if (s[0] > s[1] || s[1] > s[2] || s[2] > s[3] || s[3] > s[4] || s[4] > s[5])
				continue;
			if (!HasDouble(s))
				continue;

			count++;
		}
		return SolutionPartTwo = count.ToString();

		static bool HasDouble(string s)
		{
			for (int i = 1; i < s.Length; i++)
				if (s.ElementAtOrDefault(i - 2) != s[i - 1] && s[i - 1] == s[i] && s.ElementAtOrDefault(i + 1) != s[i])
					return true;
			return false;
		}
	}
}
