namespace AdventOfCode.Year2017;

public class Day25 : Puzzle
{
	private readonly IDictionary<char, (Instr Instr0, Instr Instr1)> _blueprint;
	private readonly char _initialState;
	private readonly int _totalSteps;

	public Day25(string[] input) : base(input)
	{
		_initialState = input[0][15];
		_totalSteps = int.Parse(input[1].Split(' ')[5]);
		_blueprint = new Dictionary<char, (Instr, Instr)>();

		for (int i = 3; i < input.Length; i += 10)
		{
			char state = input[i][9];
			Instr i0, i1;

			i0.Value = input[i + 2].EndsWith("1.");
			i1.Value = input[i + 6].EndsWith("1.");

			i0.Move = input[i + 3].EndsWith("right.") ? 1 : -1;
			i1.Move = input[i + 7].EndsWith("right.") ? 1 : -1;

			i0.NewState = input[i + 4][^2];
			i1.NewState = input[i + 8][^2];

			_blueprint[state] = (i0, i1);
		}
	}

	public override DateTime Date => new DateTime(2017, 12, 25);
	public override string Title => "The Halting Problem";

	public override string? CalculateSolution()
	{
		char state = _initialState;
		int pos = 0;
		IDynamicIndexable<bool> tape = new DynamicIndexable<bool>();

		for (int i = 0; i < _totalSteps; i++)
		{
			Instr instr = tape[pos] ? _blueprint[state].Instr1 : _blueprint[state].Instr0;
			tape[pos] = instr.Value;
			pos += instr.Move;
			state = instr.NewState;
		}

		return Solution = tape.Count(b => b).ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		return SolutionPartTwo = "";
	}

	private struct Instr
	{
		public int Move;
		public char NewState;
		public bool Value;
	}
}
