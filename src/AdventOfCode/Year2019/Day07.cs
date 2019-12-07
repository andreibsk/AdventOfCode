using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2019
{
	public class Day07 : Puzzle
	{
		private const int AmpCount = 5;
		private readonly int[] _initialMemory;

		public Day07(string[] input) : base(input)
		{
			_initialMemory = input[0].Split(',').Select(int.Parse).ToArray();
		}

		public override DateTime Date => new DateTime(2019, 12, 07);
		public override string Title => "Amplification Circuit";

		public override string? CalculateSolution()
		{
			int maxSignal = int.MinValue;
			int[] localMem = new int[_initialMemory.Length];

			foreach (IList<int> phases in Enumerable.Range(0, AmpCount).Permutations())
			{
				Array.Copy(_initialMemory, localMem, _initialMemory.Length);
				int outputA = ExecuteProgram(localMem, phases[0], 0).Single();

				Array.Copy(_initialMemory, localMem, _initialMemory.Length);
				int outputB = ExecuteProgram(localMem, phases[1], outputA).Single();

				Array.Copy(_initialMemory, localMem, _initialMemory.Length);
				int outputC = ExecuteProgram(localMem, phases[2], outputB).Single();

				Array.Copy(_initialMemory, localMem, _initialMemory.Length);
				int outputD = ExecuteProgram(localMem, phases[3], outputC).Single();

				Array.Copy(_initialMemory, localMem, _initialMemory.Length);
				int outputE = ExecuteProgram(localMem, phases[4], outputD).Single();

				if (outputE > maxSignal)
					maxSignal = outputE;
			}

			return Solution = maxSignal.ToString();
		}

		public override string? CalculateSolutionPartTwo()
		{
			int maxSignal = int.MinValue;
			var amps = new (int[] Memory, Queue<int> Input, IEnumerator<int> Output)[AmpCount];

			for (int i = 0; i < AmpCount; i++)
				amps[i] = (new int[_initialMemory.Length], new Queue<int>(), Output: null!);

			foreach (IList<int> phases in Enumerable.Range(5, AmpCount).Permutations())
			{
				for (int i = 0; i < AmpCount; i++)
				{
					Array.Copy(_initialMemory, amps[i].Memory, _initialMemory.Length);
					amps[i].Input.Clear();
					amps[i].Input.Enqueue(phases[i]);
					amps[i].Output = ExecuteProgram(amps[i].Memory, amps[i].Input).GetEnumerator();
				}

				amps[0].Input.Enqueue(0);

				for (int i = 0; amps[i].Output.MoveNext() ; i = (i + 1) % AmpCount)
				{
					int output = amps[i].Output.Current;

					amps[(i + 1) % AmpCount].Input.Enqueue(output);

					// Check output of last amp.
					if (i == AmpCount - 1 && output > maxSignal)
						maxSignal = output;
				}
			}

			return SolutionPartTwo = maxSignal.ToString();
		}

		private static IEnumerable<int> ExecuteProgram(int[] memory, params int[] input) => Day05.ExecuteProgram(memory, input);
		private static IEnumerable<int> ExecuteProgram(int[] memory, Queue<int> input) => Day05.ExecuteProgram(memory, input);
	}
}
