using System.Text.RegularExpressions;

namespace AdventOfCode.Year2018;

public class Day03 : Puzzle
{
	private readonly Claim[] _claims;

	public Day03(string[] input) : base(input)
	{
		_claims = input.Select(Claim.Parse).ToArray();
	}

	public override DateTime Date => new DateTime(2018, 12, 03);
	public override string Title => "No Matter How You Slice It";

	public override string? CalculateSolution()
	{
		bool?[,] conflict = new bool?[1000, 1000];

		foreach (Claim claim in _claims)
			for (int i = claim.Top; i < claim.Top + claim.Height; i++)
				for (int j = claim.Left; j < claim.Left + claim.Width; j++)
					conflict[i, j] = conflict[i, j] == true
						? true
						: conflict[i, j] == false ? true : false;

		return Solution = conflict.Cast<bool?>().Count(c => c == true).ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		var conflicts = new Claim?[1000, 1000];

		foreach (Claim claim in _claims)
			for (int i = claim.Top; i < claim.Top + claim.Height; i++)
				for (int j = claim.Left; j < claim.Left + claim.Width; j++)
				{
					if (conflicts[i, j] == null)
						conflicts[i, j] = claim;
					else
						claim.InConflict = conflicts[i, j]!.InConflict = true;
				}

		return SolutionPartTwo = _claims.SingleOrDefault(c => !c.InConflict)?.Id.ToString();
	}

	private class Claim
	{
		private static readonly Regex s_regex = new Regex(
			@"^#(?<id>\d+) @ (?<left>\d+),(?<top>\d+): (?<width>\d+)x(?<height>\d+)$",
			RegexOptions.Compiled);

		private Claim(int id, int left, int top, int width, int height)
		{
			Id = id;
			Left = left;
			Top = top;
			Width = width;
			Height = height;
		}

		public int Height { get; }
		public int Id { get; }
		public bool InConflict { get; set; } = false;
		public int Left { get; }
		public int Top { get; }
		public int Width { get; }

		public static Claim Parse(string str)
		{
			Match match = s_regex.Match(str);
			if (!match.Success)
				throw new FormatException();

			return new Claim(
				int.Parse(match.Groups["id"].Value),
				int.Parse(match.Groups["left"].Value),
				int.Parse(match.Groups["top"].Value),
				int.Parse(match.Groups["width"].Value),
				int.Parse(match.Groups["height"].Value));
		}
	}
}
