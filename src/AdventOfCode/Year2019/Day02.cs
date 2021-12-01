namespace AdventOfCode.Year2019;

public class Day02 : Puzzle
{
	private readonly long[] _initialMemory;

	public Day02(string[] input) : base(input)
	{
		_initialMemory = input[0].Split(',').Select(long.Parse).ToArray();
	}

	public override DateTime Date => new DateTime(2019, 12, 02);

	public override string Title => "1202 Program Alarm";

	public override string? CalculateSolution()
	{
		var computer = new IntcodeComputer(_initialMemory);
		computer.Memory[1] = 12;
		computer.Memory[2] = 2;

		computer.Execute().Count();
		return Solution = computer.Memory[0].ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		var computer = new IntcodeComputer();

		for (int noun = 0; noun <= 99; noun++)
		{
			for (int verb = 0; verb <= 99; verb++)
			{
				computer.LoadProgram(_initialMemory);
				computer.Memory[1] = noun;
				computer.Memory[2] = verb;

				computer.Execute().Count();
				if (computer.Memory[0] == 19690720)
					return SolutionPartTwo = (100 * noun + verb).ToString();
			}
		}

		return SolutionPartTwo = "";
	}
}
