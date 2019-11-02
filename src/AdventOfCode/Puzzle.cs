using System;
using System.Collections.Generic;

namespace AdventOfCode
{
	public abstract class Puzzle
	{
		public abstract DateTime Date { get; }
		public IReadOnlyList<string> Input { get; private set; }
		public string Solution { get; protected set; } = null;
		public string SolutionPartTwo { get; protected set; } = null;
		public virtual string Title { get; } = null;

		public abstract string CalculateSolution();

		public abstract string CalculateSolutionPartTwo();

		public void SetInput(string input) => SetInput(new[] { input });

		public void SetInput(string[] input)
		{
			Input = input ?? throw new ArgumentNullException(nameof(input));
			try
			{
				ParseInput(input);
			}
			catch (Exception e)
			{
				throw new FormatException("Input format not valid for this puzzle.", e);
			}
		}

		protected abstract void ParseInput(string[] input);
	}
}
