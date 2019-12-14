using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2019
{
	public class Day14 : Puzzle
	{
		private readonly Dictionary<string, Reaction> _reactions;
		private Dictionary<string, long>? _available;

		public Day14(string[] input) : base(input)
		{
			_reactions = input
				.Select(Reaction.Parse)
				.ToDictionary(r => r.Product.Name);
		}

		public override DateTime Date => new DateTime(2019, 12, 14);

		public override string Title => "Space Stoichiometry";

		public override string? CalculateSolution()
		{
			_available = new Dictionary<string, long> { { "ORE", long.MaxValue } };
			Consume("FUEL", 1);

			return Solution = (long.MaxValue - _available["ORE"]).ToString();
		}

		public override string? CalculateSolutionPartTwo()
		{
			long capacity = 1_000_000_000_000;
			_available = new Dictionary<string, long> { { "ORE", capacity } };
			Produce("FUEL", 1);

			long oreConsumed = capacity - _available["ORE"];
			while (Produce("FUEL", Math.Max(1, _available["ORE"] / oreConsumed))) ;

			return SolutionPartTwo = _available["FUEL"].ToString();
		}

		private bool Consume(string chemical, long quantity)
		{
			if (quantity <= 0)
				throw new ArgumentOutOfRangeException();

			if (!_available!.ContainsKey(chemical))
				_available[chemical] = 0;

			if (_available[chemical] < quantity && !Produce(chemical, quantity - _available[chemical]))
				return false;

			_available[chemical] -= quantity;
			return true;
		}

		private bool Produce(string chemical, long quanity)
		{
			if (chemical == "ORE")
				return false;

			Reaction reaction = _reactions[chemical];
			long reactionCount = (long)Math.Ceiling((double)quanity / reaction.Product.Quantity);

			foreach (ReactionComponent reactant in reaction.Reactants)
				if (!Consume(reactant.Name, reactionCount * reactant.Quantity))
					return false;

			_available![chemical] = _available.GetValueOrDefault(chemical) + reactionCount * reaction.Product.Quantity;
			return true;
		}

		private struct ReactionComponent
		{
			public string Name;
			public int Quantity;

			public ReactionComponent(string chemical, int quantity)
			{
				Name = chemical;
				Quantity = quantity;
			}
		}

		private class Reaction
		{
			public Reaction(ReactionComponent[] reactants, ReactionComponent product)
			{
				Reactants = reactants;
				Product = product;
			}

			public ReactionComponent Product { get; set; }
			public ReactionComponent[] Reactants { get; set; }

			public static Reaction Parse(string s)
			{
				string[] ss = s.Split(new[] { ", ", " => " }, StringSplitOptions.None);
				return new Reaction(
					ss.Take(ss.Length - 1).Select(ParseReactionComponent).ToArray(),
					ParseReactionComponent(ss[^1]));

				static ReactionComponent ParseReactionComponent(string s)
				{
					int i = s.IndexOf(' ');
					return new ReactionComponent(chemical: s[(i + 1)..], quantity: int.Parse(s.AsSpan(0, i)));
				}
			}
		}
	}
}
