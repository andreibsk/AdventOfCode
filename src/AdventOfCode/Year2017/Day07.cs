using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2017;

public class Day07 : Puzzle
{
	private static readonly Regex s_regex = new Regex(
		@"^(?<name>\w+) \((?<weight>\d+)\)( -> (?<disc>\w+(, \w+)+))?$",
		RegexOptions.Compiled);

	private readonly (string Name, int Weight, string[]? Disc)[] _programs;

	public Day07(string[] input) : base(input)
	{
		static (string, int, string[]?) ParseLine(string line)
		{
			Match match = s_regex.Match(line);
			if (!match.Success)
				throw new FormatException();

			string[]? disc = match.Groups["disc"].Success ? match.Groups["disc"].Value.Split(", ") : null;
			return (match.Groups["name"].Value, int.Parse(match.Groups["weight"].Value), disc);
		}

		_programs = input.Select(ParseLine).ToArray();
	}

	public override DateTime Date => new DateTime(2017, 12, 7);
	public override string Title => "Recursive Circus";

	public override string? CalculateSolution()
	{
		Program root = BuildTower();
		Solution = root.Name;
		return Solution;
	}

	public override string? CalculateSolutionPartTwo()
	{
		Program root = BuildTower();
		root.CalculateTotalWeight();

		// Program that is on a unbalanced disc and has it's disc balanced is the program we're
		// looking for. Follow the unballanced discs:
		Program prog = root;
		Program? up = null;
		while (prog.Disc?.IsBalanced != true)
		{
			up = prog.Disc?.GetUnbalancedProgram();
			if (up?.Disc?.IsBalanced ?? true)
				break;

			prog = up!;
		}

		int dweight = prog.Disc!.Programs.FirstOrDefault(p => p != up)!.TotalWeight!.Value - up!.TotalWeight!.Value;

		SolutionPartTwo = (up.Weight + dweight).ToString();
		return SolutionPartTwo;
	}

	private Program BuildTower()
	{
		// (orphan name -> orphan) or (orphan name -> parent)
		var orphans = new Dictionary<string, Program>();

		foreach ((string name, int weight, string[]? disc) in _programs)
		{
			var prog = new Program(name, weight);

			// Add to parent if listed, else add to list.
			if (orphans.Remove(name, out Program? parent))
				parent.Disc![name] = prog;
			else orphans.Add(name, prog);

			// Build the disc.
			if (disc != null && disc.Length > 0)
			{
				prog.Disc = new Disc(disc.Select(name =>
					{
						if (orphans.Remove(name, out Program? child))
							return new KeyValuePair<string, Program?>(name, child);
						orphans.Add(name, prog);
						return new KeyValuePair<string, Program?>(name, null);
					}));
			}
		}

		if (orphans.Count != 1) throw new Exception("Not valid tree");
		return orphans.First().Value;
	}

	private class Disc : Dictionary<string, Program?>
	{
		public Disc(IEnumerable<KeyValuePair<string, Program?>> subprograms) : base(subprograms) { }

		public bool? IsBalanced { get; private set; }
		public ValueCollection Programs => Values;
		public int? Weight { get; private set; }

		public int CalculateWeight()
		{
			IsBalanced = true;
			Weight = 0;

			if (Count >= 0)
			{
				Weight = Values.Sum(p => p!.CalculateTotalWeight());
				IsBalanced = Weight == Values.First()!.Weight * Count;
			}

			return Weight.Value;
		}

		public Program? GetUnbalancedProgram()
		{
			if (Count < 2)
				return null;
			if (!IsBalanced.HasValue)
				CalculateWeight();
			if (IsBalanced == true)
				return null;

			IGrouping<int?, Program?>[] weightGroups = Values.GroupBy(p => p!.TotalWeight).ToArray();
			IGrouping<int?, Program?> validWeightGroup = weightGroups.First(g => g.Count() > 1);
			return weightGroups.FirstOrDefault(g => g != validWeightGroup)?.FirstOrDefault();
		}
	}

	private class Program
	{
		public Program(string name, int weight)
		{
			Name = name;
			Weight = weight;
		}

		public Disc? Disc { get; set; }
		public string Name { get; set; }
		public int? TotalWeight { get; private set; }
		public int Weight { get; set; }

		public int CalculateTotalWeight()
		{
			TotalWeight = Weight + (Disc?.CalculateWeight() ?? 0);
			return TotalWeight.Value;
		}

		public override string ToString() => $"{Name} ({Weight} {TotalWeight ?? 0}) -> {Disc?.Count ?? 0}";
	}
}
