using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2016;

public class Day07 : Puzzle
{
	private readonly string[] _ips;

	public Day07(string[] input) : base(input)
	{
		_ips = input;
	}

	public override DateTime Date => new DateTime(2016, 12, 7);
	public override string Title => "Internet Protocol Version 7";

	public override string? CalculateSolution()
	{
		int count = 0;

		foreach (string ip in _ips)
		{
			bool tls = false;
			bool inside = false;

			for (int i = 0; i < ip.Length - 3; i++)
			{
				if (ip[i] == '[')
				{
					inside = true;
					continue;
				}

				if (ip[i + 3] == ']')
				{
					i += 3;
					inside = false;
					continue;
				}

				// abba detection
				if (ip[i] == ip[i + 3] && ip[i] != ip[i + 1] && ip[i + 1] != '[' && ip[i + 1] == ip[i + 2])
				{
					if (inside)
					{
						tls = false;
						break;
					}
					else
						tls = true;
				}
			}

			if (tls)
				count++;
		}

		return Solution = count.ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		int count = 0;

		foreach (string ip in _ips)
		{
			ISet<string> abas = new HashSet<string>();
			ISet<string> babs = new HashSet<string>();
			bool ssl = false;
			bool inside = false;

			for (int i = 0; i < ip.Length - 2; i++)
			{
				if (ip[i] == '[')
				{
					inside = true;
					continue;
				}

				if (ip[i + 2] == ']')
				{
					i += 2;
					inside = false;
					continue;
				}

				// aba/bab detection
				if (ip[i] == ip[i + 2] && ip[i] != ip[i + 1])
				{
					if (inside)
					{
						if (babs.Contains(ip[i..(i + 3)]))
						{
							ssl = true;
							break;
						}
						abas.Add(string.Concat(new[] { ip[i + 1], ip[i], ip[i + 1] }));
					}
					else
					{
						if (abas.Contains(ip[i..(i + 3)]))
						{
							ssl = true;
							break;
						}
						babs.Add(string.Concat(new[] { ip[i + 1], ip[i], ip[i + 1] }));
					}
				}
			}

			if (ssl)
				count++;
		}

		return SolutionPartTwo = count.ToString();
	}
}
