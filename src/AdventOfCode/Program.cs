using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			string datestr = null;
			if (args.Length > 0)
			{
				datestr = args[0];
			}
			else
			{
				Console.WriteLine("Select puzzle to run. [[yy]yy.][dd]");
				Console.Write("Puzzle date: ");

				datestr = Console.ReadLine();
			}
			DateTime? date = ParsePuzzleDate(datestr);
			if (!date.HasValue) ExitWithMessage("Invalid year/date format.");

			// Create the puzzle.
			Type puzzleType = GetPuzzleTypeForDate(date.Value.Year, date.Value.Day);
			if (puzzleType == null)
				ExitWithMessage($"There's no puzzle for the specified date: {date.Value.ToLongDateString()}");
			Puzzle puzzle;
			try { puzzle = (Puzzle)Activator.CreateInstance(puzzleType); }
			catch (FormatException e) { ExitWithMessage(e.Message); return; }
			Console.WriteLine($"--- Advent of Code {puzzle.Date.Year} ---");
			Console.WriteLine("--- Day " + puzzle.Date.Day + (puzzle.Title == null ? "" : $": {puzzle.Title}") +
				" ---");

			// Read input.
			SetConsoleInputBuffer(4096);
			Console.WriteLine("Puzzle input:");
			string[] input = Console.In.ReadToEmptyLine();
			if (input == null || input.Length == 0) ExitWithMessage("No input provided.");
			puzzle.SetInput(input);

			// Part one.
			var watch = new Stopwatch();
			watch.Start();
			string solution = puzzle.CalculateSolution();
			watch.Stop();
			Console.WriteLine($"Duration: {watch.Elapsed.ToString()}");

			if (string.IsNullOrEmpty(solution)) ExitWithMessage("Failed to calculate solution to part one.");
			Console.WriteLine("Puzzle solution:");
			Console.WriteLine(solution);

			// Part two.
			watch.Restart();
			solution = puzzle.CalculateSolutionPartTwo();
			watch.Stop();
			Console.WriteLine($"Duration: {watch.Elapsed.ToString()}");

			if (string.IsNullOrEmpty(solution)) ExitWithMessage("Failed to calculate solution to part two.");
			Console.WriteLine("Part two solution:");
			Console.WriteLine(solution);

			Console.ReadKey(intercept: true);
		}

		private static void ExitWithMessage(string message)
		{
			Console.WriteLine(message);
			Console.ReadKey(intercept: true);
			Environment.Exit(-1);
		}

		private static Type GetPuzzleTypeForDate(int year, int day)
		{
			try { return Type.GetType($"{nameof(AdventOfCode)}.Year{year}.Day{day:00}"); }
			catch { return null; }
		}

		private static DateTime? ParsePuzzleDate(string datestr)
		{
			Match match = Regex.Match(datestr, @"^((?<year>(\d\d){1,2})\.)?(?<day>\d?\d)$");
			if (!match.Success) return null;

			int year;
			if (match.Groups["year"].Success)
			{
				year = int.Parse(match.Groups["year"].Value);
				if (match.Groups["year"].Value.Length == 2) year += 2000;
			}
			else year = DateTime.Now.Year - (DateTime.Now.Month == 12 ? 0 : 1);

			int day = int.Parse(match.Groups["day"].Value);

			return new DateTime(year, 12, day);
		}

		private static void SetConsoleInputBuffer(int size)
		{
			Console.SetIn(new StreamReader(Console.OpenStandardInput(size), Console.InputEncoding, false, size));
		}
	}
}
