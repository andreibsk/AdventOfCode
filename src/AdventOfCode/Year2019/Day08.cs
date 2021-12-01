using System;
using System.Linq;
using System.Text;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2019;

public class Day08 : Puzzle
{
	private const int Height = 6;
	private const int Width = 25;

	private readonly int[][] _imageData;

	public Day08(string[] input) : base(input)
	{
		_imageData = input[0]
			.Select(c => c - '0')
			.AsBatches(Height * Width)
			.Select(b => b.ToArray())
			.ToArray();
	}

	public override DateTime Date => new DateTime(2019, 12, 08);
	public override string Title => "Space Image Format";

	public override string? CalculateSolution()
	{
		(int, int) digitCount = _imageData
			.OrderBy(l => l.Count(i => i == 0))
			.First()
			.Aggregate((0, 0), (t, i) => (t.Item1 + (i == 1 ? 1 : 0), t.Item2 + (i == 2 ? 1 : 0)));

		return Solution = (digitCount.Item1 * digitCount.Item2).ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		return SolutionPartTwo = _imageData
			.Aggregate(Enumerable.Repeat(2, Width * Height).ToArray(),
				(image, layer) =>
				{
					for (int i = 0; i < image.Length; i++)
						if (image[i] == 2)
							image[i] = layer[i];
					return image;
				})
			.AsBatches(Width)
			.Select(row => row.Select(i => i == 1 ? '#' : ' ').ToArray())
			.Aggregate(new StringBuilder(), (b, r) => b.Append(r).AppendLine())
			.ToString();
	}
}
