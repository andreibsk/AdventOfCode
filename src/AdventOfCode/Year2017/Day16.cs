using System;
using System.Linq;

namespace AdventOfCode.Year2017;

public class Day16 : Puzzle
{
	private readonly string[] _moves;

	public Day16(string[] input) : base(input)
	{
		_moves = input[0].Split(',').ToArray();
	}

	public override DateTime Date => new DateTime(2017, 12, 16);
	public override string Title => "Permutation Promenade";

	public override string? CalculateSolution()
	{
		char[] programs = Enumerable.Range('a', 16).Select(i => (char)i).ToArray();
		Dance(programs, _moves);

		return Solution = string.Concat(programs);
	}

	public override string? CalculateSolutionPartTwo()
	{
		char[] unchanged = Enumerable.Range('a', 16).Select(i => (char)i).ToArray();
		char[] programs = Enumerable.Range('a', 16).Select(i => (char)i).ToArray();
		int iterations = 1_000_000_000;

		for (int i = 0; i < iterations; i++)
		{
			Dance(programs, _moves);

			if (programs.SequenceEqual(unchanged))
			{
				iterations = iterations % (i + 1) + 1;
				i = 0;
			}
		}

		return SolutionPartTwo = string.Concat(programs);
	}

	private static void Dance(char[] programs, string[] moves)
	{
		foreach (string move in moves)
		{
			switch (move[0])
			{
				case 's':
					Spin(int.Parse(move[1..]));
					break;

				case 'x':
					int i = move.IndexOf('/', 1);
					Exchange(int.Parse(move[1..i]), int.Parse(move[(i + 1)..]));
					break;

				case 'p':
					Partner(move[1], move[3]);
					break;

				default:
					throw new FormatException();
			}
		}

		return;

		void Spin(int x)
		{
			char[] lastx = programs[^x..];
			Array.Copy(programs, 0, programs, x, length: programs.Length - x);
			Array.Copy(lastx, programs, x);
		}
		void Exchange(int a, int b)
		{
			char t = programs[a];
			programs[a] = programs[b];
			programs[b] = t;
		}
		void Partner(char a, char b)
		{
			Exchange(Array.IndexOf(programs, a), Array.IndexOf(programs, b));
		}
	}
}
