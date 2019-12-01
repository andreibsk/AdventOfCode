using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ExceptionServices;

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

		public static TPuzzle Construct<TPuzzle>(string input) where TPuzzle : Puzzle => Construct<TPuzzle>(new[] { input });

		public static TPuzzle Construct<TPuzzle>(string[] input) where TPuzzle : Puzzle => Construct<TPuzzle>(input, config: null);

		public static TPuzzle Construct<TPuzzle>(string[] input, string? config) where TPuzzle : Puzzle
		{
			return (TPuzzle)Construct(typeof(TPuzzle), input, config);
		}

		public static Puzzle Construct(Type type, string[] input) => Construct(type, input, config: null);

		public static Puzzle Construct(Type type, string[] input, string? config)
		{
			if (!type.IsSubclassOf(typeof(Puzzle)))
				throw new ArgumentException();

			try
			{
				return config == null
					? (Puzzle)type.GetConstructor(new[] { typeof(string[]) })!.Invoke(new[] { input })
					: (Puzzle)type.GetConstructor(new[] { typeof(string[]), typeof(string) })!.Invoke(new object[] { input, config });
			}
			catch (TargetInvocationException e)
			{
				ExceptionDispatchInfo.Capture(e.GetBaseException()).Throw();
				throw new InvalidOperationException("Unexpected exception catched.");
			}
		}

		public static Type? GetType(DateTime date)
		{
			var type = Type.GetType($"{nameof(AdventOfCode)}.Year{date.Year:00}.Day{date.Day:00}");
			return type?.IsSubclassOf(typeof(Puzzle)) == true ? type : null;
		}

		public abstract string? CalculateSolution();

		public abstract string? CalculateSolutionPartTwo();
	}
}
