namespace AdventOfCode.Year2019;

public class Day07 : Puzzle
{
	private const int AmpCount = 5;
	private readonly long[] _initialMemory;

	public Day07(string[] input) : base(input)
	{
		_initialMemory = input[0].Split(',').Select(long.Parse).ToArray();
	}

	public override DateTime Date => new DateTime(2019, 12, 07);
	public override string Title => "Amplification Circuit";

	public override string? CalculateSolution()
	{
		long maxSignal = long.MinValue;

		foreach (IList<int> phases in Enumerable.Range(0, AmpCount).Permutations())
		{
			long outputA = new IntcodeComputer(_initialMemory).Execute(phases[0], 0).Single();
			long outputB = new IntcodeComputer(_initialMemory).Execute(phases[1], outputA).Single();
			long outputC = new IntcodeComputer(_initialMemory).Execute(phases[2], outputB).Single();
			long outputD = new IntcodeComputer(_initialMemory).Execute(phases[3], outputC).Single();
			long outputE = new IntcodeComputer(_initialMemory).Execute(phases[4], outputD).Single();

			if (outputE > maxSignal)
				maxSignal = outputE;
		}

		return Solution = maxSignal.ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		long maxSignal = long.MinValue;
		var amps = new (IntcodeComputer Computer, Queue<long> Input, IEnumerator<long> Output)[AmpCount];

		for (int i = 0; i < AmpCount; i++)
			amps[i] = (new IntcodeComputer(), new Queue<long>(), Output: null!);

		foreach (IList<int> phases in Enumerable.Range(5, AmpCount).Permutations())
		{
			for (int i = 0; i < AmpCount; i++)
			{
				amps[i].Computer.LoadProgram(_initialMemory);
				amps[i].Input.Clear();
				amps[i].Input.Enqueue(phases[i]);
				amps[i].Output = amps[i].Computer.Execute(amps[i].Input).GetEnumerator();
			}

			amps[0].Input.Enqueue(0);

			for (int i = 0; amps[i].Output.MoveNext(); i = (i + 1) % AmpCount)
			{
				long output = amps[i].Output.Current;

				amps[(i + 1) % AmpCount].Input.Enqueue(output);

				// Check output of last amp.
				if (i == AmpCount - 1 && output > maxSignal)
					maxSignal = output;
			}
		}

		return SolutionPartTwo = maxSignal.ToString();
	}
}
