using System;
using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2017;

public class Day19 : Puzzle
{
	private readonly char[,] _diagram;
	private int? _steps = null;

	public Day19(string[] input) : base(input)
	{
		_diagram = input.To2DArray(input.Length, input[0].Length);
	}

	public override DateTime Date => new DateTime(2017, 12, 19);
	public override string Title => "A Series of Tubes";

	public override string? CalculateSolution()
	{
		Direction.SetMode(Direction.Mode.Array);
		Direction direction = Direction.South;
		Position pos = (0, _diagram.GetRow(0).IndexOf('|'));
		string letters = string.Empty;
		_steps = 0;

		while (_diagram.TryGetValue(pos, out char c) && c != ' ')
		{
			if (c == '+')
			{
				direction = NewDirectionOrDefault();
				if (direction == default)
					break;
			}
			else if (char.IsLetter(c))
				letters += c;
			else if (c != '|' && c != '-')
				break;

			pos += direction;
			_steps++;
		}

		return Solution = letters;

		Direction NewDirectionOrDefault()
		{
			Direction d = direction.ToRight();
			if (_diagram.TryGetValue(pos + d, out char c) && c != ' ')
				return d;

			d = direction.ToLeft();
			if (_diagram.TryGetValue(pos + d, out c) && c != ' ')
				return d;

			return default;
		}
	}

	public override string? CalculateSolutionPartTwo()
	{
		if (!_steps.HasValue)
			CalculateSolution();

		return SolutionPartTwo = _steps.ToString();
	}
}
