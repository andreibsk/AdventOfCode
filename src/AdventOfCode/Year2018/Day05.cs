using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2018
{
	public class Day05 : Puzzle
	{
		private readonly LinkedList<char> _polymer;

		public Day05(string[] input) : base(input)
		{
			_polymer = new LinkedList<char>(input[0]);
		}

		public override DateTime Date => new DateTime(2018, 12, 05);
		public override string Title => "Alchemical Reduction";

		public override string? CalculateSolution()
		{
			ApplyReactions(_polymer);
			return Solution = _polymer.Count.ToString();
		}

		public override string? CalculateSolutionPartTwo()
		{
			var unitTypes = _polymer.Select(u => char.ToUpper(u)).ToHashSet();

			int min = int.MaxValue;
			foreach (char unitType in unitTypes)
			{
				var reducedPolymer = new LinkedList<char>(_polymer.Where(u => char.ToUpper(u) != unitType));
				ApplyReactions(reducedPolymer);
				min = reducedPolymer.Count < min ? reducedPolymer.Count : min;
			}

			return SolutionPartTwo = min.ToString();
		}

		private static LinkedList<char> ApplyReactions(LinkedList<char> polymer)
		{
			static bool Reacts(char a, char b) => char.ToUpperInvariant(a) == char.ToUpperInvariant(b) && char.IsUpper(a) ^ char.IsUpper(b);

			for (LinkedListNode<char>? unit = polymer.First!; unit != null; unit = unit.Next)
			{
				if (unit.Previous != null && Reacts(unit.Value, unit.Previous.Value))
				{
					polymer.Remove(unit.Previous);
					if (unit.Previous != null)
					{
						unit = unit.Previous;
						polymer.Remove(unit.Next!);
					}
					else if (unit.Next != null)
					{
						unit = unit.Next;
						polymer.Remove(unit.Previous!);
					}
				}
			}

			return polymer;
		}
	}
}
