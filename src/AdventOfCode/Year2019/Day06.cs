using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2019
{
	public class Day06 : Puzzle
	{
		private readonly Dictionary<string, string[]> _orbits;

		public Day06(string[] input) : base(input)
		{
			_orbits = input
				.Select(s => s.Split(')').ToValueTuple<string, string>())
				.GroupBy(t => t.Item1)
				.ToDictionary(g => g.Key, g => g.Select(t => t.Item2).ToArray());
		}

		public override DateTime Date => new DateTime(2019, 12, 06);
		public override string Title => "Universal Orbit Map";

		public override string? CalculateSolution()
		{
			return Solution = CountOrbits("COM").OrbitCount.ToString();

			(int OrbitCount, int ObjectCount) CountOrbits(string obj)
			{
				int orbc = 0;
				int objc = 1;

				if (_orbits.TryGetValue(obj, out string[]? objects))
					foreach ((int orbitCount, int objectCount) in objects.Select(CountOrbits))
					{
						orbc += orbitCount + objectCount;
						objc += objectCount;
					}

				return (orbc, objc);
			}
		}

		public override string? CalculateSolutionPartTwo()
		{
			return SolutionPartTwo = MinimumTransferCount("COM")!.Value.Count.ToString();

			(int Count, bool Connected)? MinimumTransferCount(string obj)
			{
				if (obj == "YOU" || obj == "SAN")
					return (-1, false);

				if (_orbits.TryGetValue(obj, out string[]? objects))
				{
					((int Count, bool Connected)? mtc1, (int Count, bool Connected)? mtc2) =
						objects.Select(MinimumTransferCount).Where(t => t.HasValue);

					if (mtc1.HasValue)
					{
						if (mtc1.Value.Connected)
							return mtc1;

						if (mtc2.HasValue)
							return (mtc1.Value.Count + mtc2.Value.Count + 2, Connected: true);

						return (mtc1.Value.Count + 1, Connected: false);
					}
				}

				return null;
			}
		}
	}
}
