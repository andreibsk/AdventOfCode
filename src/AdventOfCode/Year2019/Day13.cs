using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2019
{
	public class Day13 : Puzzle
	{
		private readonly long[] _initialMemory;

		public Day13(string[] input) : base(input)
		{
			_initialMemory = input[0].Split(',').Select(long.Parse).ToArray();
		}

		public override DateTime Date => new DateTime(2019, 12, 13);
		public override string Title => "Care Package";

		public override string? CalculateSolution()
		{
			IDynamicIndexable2D<int> screen = new DynamicIndexable2D<int>();

			using IEnumerator<long> e = Day09.ExecuteProgram(_initialMemory.ToDynamicIndexable()).GetEnumerator();

			while (e.MoveNext())
			{
				int x = (int)e.Current;
				if (!e.MoveNext())
					break;
				int y = (int)e.Current;
				if (!e.MoveNext())
					break;
				int id = (int)e.Current;

				screen[x, y] = id;
			}

			return Solution = screen.Count(t => t == ScreenObject.Block).ToString();
		}

		public override string? CalculateSolutionPartTwo()
		{
			IDynamicIndexable<long> memory = _initialMemory.ToDynamicIndexable();
			IDynamicIndexable2D<int> screen = new DynamicIndexable2D<int>();

			memory[0] = 2;
			using IEnumerator<long> e = Day09.ExecuteProgram(memory, PaddleMovesEnumerable()).GetEnumerator();

			bool draw = false;
			long score = 0;
			int blockCount = 0;
			bool scoreDrawn = false;

			if (draw)
				Console.Clear();

			while (e.MoveNext())
			{
				int x = (int)e.Current;
				if (!e.MoveNext())
					break;
				int y = (int)e.Current;
				if (!e.MoveNext())
					break;
				int id = (int)e.Current;

				if (x == -1 && y == 0)
				{
					score = id;
					if (draw)
					{
						Console.SetCursorPosition(0, 0);
						Console.WriteLine($"Score: {score}");
						Console.SetCursorPosition(0, 0);
						scoreDrawn = true;
					}
				}
				else
				{
					if (id == ScreenObject.Block && screen[x, y] != ScreenObject.Block)
						blockCount++;
					else if (id != ScreenObject.Block && screen[x, y] == ScreenObject.Block)
						blockCount--;

					screen[x, y] = id;
					if (draw)
					{
						Console.SetCursorPosition(x, y + 1);
						Console.Write(screen[x, y] switch
						{
							1 => '+',
							2 => 'x',
							3 => '_',
							4 => 'o',
							_ => ' '
						});
						Console.SetCursorPosition(0, 0);
					}
				}

				if (draw && scoreDrawn)
					Thread.Sleep(10);
			}

			return SolutionPartTwo = score.ToString();

			IEnumerable<long> PaddleMovesEnumerable()
			{
				while (true)
				{
					(Position paddle, Position ball) = GetPositions();
					yield return paddle.X > ball.X ? -1 : paddle.X < ball.X ? 1 : 0;
				}
			}

			(Position paddle, Position ball) GetPositions()
			{
				Position? paddle = null;
				Position? ball = null;

				for (int x = 0; x + screen.Start0 < screen.Length0; x++)
				{
					for (int y = 0; y + screen.Start0 < screen.Length0; y++)
					{
						Position p = (x + screen.Start0, y + screen.Start1);
						if (screen[p] == ScreenObject.Paddle)
							paddle = p;
						if (screen[p] == ScreenObject.Ball)
							ball = p;

						if (paddle.HasValue && ball.HasValue)
							return (paddle.Value, ball.Value);
					}
				}

				throw new InvalidOperationException("Paddle or ball not found.");
			}
		}

		private static class ScreenObject
		{
			public const int Ball = 4;
			public const int Block = 2;
			public const int Paddle = 3;
			public const int Wall = 1;
		}
	}
}
