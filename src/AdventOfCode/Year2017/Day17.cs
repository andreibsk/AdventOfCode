using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2017
{
	public class Day17 : Puzzle
	{
		private readonly int _steps;

		public Day17(string[] input) : base(input)
		{
			_steps = int.Parse(input[0]);
		}

		public override DateTime Date => new DateTime(2017, 12, 17);
		public override string Title => "Spinlock";

		public override string? CalculateSolution()
		{
			var buffer = new LinkedList<int>();
			buffer.AddFirst(0);
			LinkedListNode<int> current = buffer.First!;

			for (int v = 1; v <= 2017; v++)
			{
				for (int i = _steps % buffer.Count; i > 0; i--)
					current = current.Next ?? current.List!.First!;

				current = buffer.AddAfter(current, v);
			}

			return Solution = (current.Next ?? current.List!.First!).Value.ToString();
		}

		public override string? CalculateSolutionPartTwo()
		{
			int bufferSize = 1;
			int valueAfterZero = 0;
			int currentIndex = 0;

			for (int v = 1; v <= 50_000_000; v++)
			{
				currentIndex = (currentIndex + _steps) % bufferSize;

				if (currentIndex == 0)
					valueAfterZero = v;

				currentIndex++;
				bufferSize++;
			}

			return SolutionPartTwo = valueAfterZero.ToString();
		}
	}
}
