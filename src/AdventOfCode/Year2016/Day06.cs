using System;
using System.Linq;

namespace AdventOfCode.Year2016
{
	public class Day06 : Puzzle
	{
		private readonly string[] _messages;

		public Day06(string[] input) : base(input)
		{
			_messages = input;
		}

		public override DateTime Date => new DateTime(2016, 12, 6);
		public override string Title => "Signals and Noise";

		public override string? CalculateSolution()
		{
			return Solution = string.Concat(_messages
				.Select(s => s.ToCharArray())
				.SelectMany(cs => cs.Select((c, i) => (Index: i, Char: c)))
				.GroupBy(ic => ic.Index, (i, ic) => (Index: i, ic
					.Select(t => t.Char)
					.GroupBy(c => c, (c, cs) => (Char: c, Count: cs.Count()))
					.Aggregate((ccmax, cc) => ccmax.Count > cc.Count ? ccmax : cc)
					.Char))
				.OrderBy(ic => ic.Index)
				.Select(ic => ic.Char));
		}

		public override string? CalculateSolutionPartTwo()
		{
			return SolutionPartTwo = string.Concat(_messages
				.Select(s => s.ToCharArray())
				.SelectMany(cs => cs.Select((c, i) => (Index: i, Char: c)))
				.GroupBy(ic => ic.Index, (i, ic) => (Index: i, ic
					.Select(t => t.Char)
					.GroupBy(c => c, (c, cs) => (Char: c, Count: cs.Count()))
					.Aggregate((ccmin, cc) => ccmin.Count < cc.Count ? ccmin : cc)
					.Char))
				.OrderBy(ic => ic.Index)
				.Select(ic => ic.Char));
		}
	}
}
