using System;
using System.Linq;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2019;

public class Day16 : Puzzle
{
	private static readonly int[] s_basePattern = new[] { 0, 1, 0, -1 };
	private readonly int[] _initialSequence;

	public Day16(string[] input) : base(input)
	{
		_initialSequence = input[0].Select(c => c.ToDigit()).ToArray();
	}

	public override DateTime Date => new DateTime(2019, 12, 16);
	public override string Title => "Flawed Frequency Transmission";

	public override string? CalculateSolution()
	{
		int phaseCount = 100;
		int[] signal0 = _initialSequence.ToArray();
		int[] signal1 = new int[signal0.Length];

		for (int i = 0; i < phaseCount; i++)
			CalculateOutputSignal(i % 2 == 0 ? signal0 : signal1, i % 2 == 0 ? signal1 : signal0);

		return Solution = new string((phaseCount % 2 == 0 ? signal0 : signal1)
			.Take(8)
			.Select(i => (char)(i + '0'))
			.ToArray());
	}

	public override string? CalculateSolutionPartTwo()
	{
		int phaseCount = 100;
		int messageOffset = _initialSequence.Take(7).Aggregate((n, i) => n = n * 10 + i);
		int[] signal = _initialSequence.Repeat(10000).Skip(messageOffset).ToArray();

		for (int p = 0; p < phaseCount; p++)
		{
			signal[^1] %= 10;
			for (int i = signal.Length - 2; i >= 0; i--)
				signal[i] = (signal[i + 1] + signal[i]) % 10;
		}

		return SolutionPartTwo = new string(signal.Take(8).Select(i => (char)(i + '0')).ToArray());
	}

	private static int[] PatternValues(int index, int count)
	{
		return s_basePattern
			.SelectMany(v => Enumerable.Repeat(v, index + 1))
			.Repeat()
			.Skip(1)
			.Take(count)
			.ToArray();
	}

	private void CalculateOutputSignal(int[] input, int[] output)
	{
		for (int outputIndex = 0; outputIndex < output.Length; outputIndex++)
		{
			output[outputIndex] = Math.Abs(PatternValues(outputIndex, input.Length)
				.Select((pv, i) => pv * input[i] % 10)
				.Sum())
				% 10;
		}
	}
}
