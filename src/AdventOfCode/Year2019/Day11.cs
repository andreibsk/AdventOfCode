using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2019
{
	public class Day11 : Puzzle
	{
		private readonly long[] _initialMemory;

		public Day11(string[] input) : base(input)
		{
			_initialMemory = input[0].Split(',').Select(long.Parse).ToArray();
		}

		public override DateTime Date => new DateTime(2019, 12, 11);
		public override string Title => "Space Police";

		public override string? CalculateSolution()
		{
			var computer = new IntcodeComputer(_initialMemory);
			var inputQueue = new Queue<long>(new[] { 0L });
			IDynamicIndexable2D<bool> panels = new DynamicIndexable2D<bool>();
			Position pos = Position.Zero;
			Direction direction = Direction.North;
			var paintedPanels = new HashSet<Position>();

			using IEnumerator<long> e = computer.Execute(inputQueue).GetEnumerator();

			while (e.MoveNext())
			{
				long color = e.Current;
				long turn = e.MoveNext() ? e.Current : throw new InvalidOperationException();

				panels[pos] = color == 1;
				paintedPanels.Add(pos);
				direction = turn == 1 ? direction.ToRight() : direction.ToLeft();
				pos += direction * 1;

				inputQueue.Enqueue(panels[pos] ? 1 : 0);
			}

			return Solution = paintedPanels.Count().ToString();
		}

		public override string? CalculateSolutionPartTwo()
		{
			var computer = new IntcodeComputer(_initialMemory);
			var inputQueue = new Queue<long>(new[] { 1L });
			IDynamicIndexable2D<bool> panels = new DynamicIndexable2D<bool>(new[,] { { true } }.AsIndexable());
			Position pos = Position.Zero;
			Direction direction = Direction.North;

			using IEnumerator<long> e = computer.Execute(inputQueue).GetEnumerator();

			while (e.MoveNext())
			{
				long color = e.Current;
				long turn = e.MoveNext() ? e.Current : throw new InvalidOperationException();

				panels[pos] = color == 1;
				direction = turn == 1 ? direction.ToRight() : direction.ToLeft();
				pos += direction * 1;

				inputQueue.Enqueue(panels[pos] ? 1 : 0);
			}

			return SolutionPartTwo = panels.ToString(b => b ? '#' : ' ');
		}
	}
}
