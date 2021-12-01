namespace AdventOfCode.Year2017;

public class Day04 : Puzzle
{
	private readonly string[][] _passphrases;

	public Day04(string[] input) : base(input)
	{
		_passphrases = input.Select(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToArray();
	}

	public override DateTime Date => new DateTime(2017, 12, 4);
	public override string Title => "High-Entropy Passphrases";

	public override string? CalculateSolution()
	{
		int validCount = 0;
		var words = new HashSet<string>();

		foreach (string[] pass in _passphrases)
		{
			foreach (string word in pass) if (!words.Add(word)) break;
			if (pass.Length == words.Count) validCount++;
			words.Clear();
		}

		Solution = validCount.ToString();
		return Solution;
	}

	public override string? CalculateSolutionPartTwo()
	{
		int validCount = 0;
		var words = new HashSet<string>();

		foreach (string[] pass in _passphrases)
		{
			foreach (string word in pass)
				if (!words.Add(string.Concat(word.OrderBy(c => c)))) break;
			if (pass.Length == words.Count) validCount++;
			words.Clear();
		}

		SolutionPartTwo = validCount.ToString();
		return SolutionPartTwo;
	}
}
