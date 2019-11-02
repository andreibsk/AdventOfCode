using System;
using System.Collections.Generic;

namespace AdventOfCode
{
	public abstract class Puzzle
	{
		protected Puzzle(string[] input)
		{
			Input = input;
		}

		public abstract DateTime Date { get; }
		public IReadOnlyList<string> Input { get; }
		public string? Solution { get; protected set; }
		public string? SolutionPartTwo { get; protected set; }
		public abstract string Title { get; }

		public abstract string? CalculateSolution();

		public abstract string? CalculateSolutionPartTwo();

		public static Type? GetType(DateTime date)
		{
			var type = Type.GetType($"{nameof(AdventOfCode)}.Year{date.Year:00}.Day{date.Day:00}");
			return type?.IsSubclassOf(typeof(Puzzle)) == true ? type : null;
		}

		public static TPuzzle Construct<TPuzzle>(string input) where TPuzzle : Puzzle => Construct<TPuzzle>(new[] { input });

		public static TPuzzle Construct<TPuzzle>(string[] input) where TPuzzle : Puzzle
		{
			return (TPuzzle)Construct(typeof(TPuzzle), input);
		}

		public static Puzzle Construct(Type type, string[] input)
		{
			if (!type.IsSubclassOf(typeof(Puzzle)))
				throw new ArgumentException();

			return (Puzzle)type.GetConstructor(new[] { typeof(string[]) })!.Invoke(new[] { input });
		}
	}
}
