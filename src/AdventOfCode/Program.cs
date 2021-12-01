using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public static class Program
{
	public static int Main(string[] args)
	{
		string datestr;
		if (args.Length == 0)
		{
			Console.WriteLine("Select puzzle to run. [[yy]yy.][dd]");
			Console.Write("Puzzle date: ");

			datestr = Console.ReadLine();
		}
		else
			datestr = args[0];

		DateTime? date = string.IsNullOrWhiteSpace(datestr) ? DateTime.Today : ParsePuzzleDate(datestr);
		if (date == null)
			return ExitError("Invalid year/date format.");

		// Detect the puzzle.
		Type? puzzleType = Puzzle.GetType(date.Value);
		if (puzzleType == null)
			return ExitError($"There's no puzzle for the specified date: {date.Value.ToLongDateString()}");
		Console.WriteLine("Detected: " + puzzleType.FullName);

		// Try reading input file.
		string[] input;
		string inputFilePath = puzzleType.FullName!
			.Replace(nameof(AdventOfCode), "Inputs")
			.Replace('.', Path.DirectorySeparatorChar)
			+ ".txt";
		if (File.Exists(inputFilePath))
		{
			Console.WriteLine("Reading input from file: " + inputFilePath);
			input = File.ReadAllLines(inputFilePath);
			if (input == null || input.Length == 0 || input.Length == 1 && string.IsNullOrEmpty(input[0]))
				return ExitError("File has invalid input.");
			Console.WriteLine();
		}
		else
		{
			// Read input from console.
			SetConsoleInputBuffer(4096);
			Console.WriteLine();
			Console.WriteLine("Puzzle input [Leave empty to read from file]:");
			input = Console.In.ReadToEmptyLine();
		}

		// Create the puzzle.
		Puzzle puzzle;
		try
		{
			puzzle = Puzzle.Construct(puzzleType, input);
		}
		catch (FormatException e)
		{
			return ExitError(e.Message);
		}
		Console.WriteLine($"--- Advent of Code {puzzle.Date.Year} ---");
		Console.WriteLine("--- Day " + puzzle.Date.Day + (puzzle.Title == null ? "" : $": {puzzle.Title}") + " ---");
		Console.WriteLine();

		// Part one.
		var watch = new Stopwatch();
		watch.Start();
		string? solution = puzzle.CalculateSolution();
		watch.Stop();
		Console.WriteLine($"Duration: {watch.Elapsed.ToString()}");

		if (solution == null)
			return ExitError("Failed to calculate solution to part one.");
		Console.WriteLine("Puzzle solution:");
		Console.WriteLine(solution);
		Console.WriteLine();

		// Part two.
		watch.Restart();
		solution = puzzle.CalculateSolutionPartTwo();
		watch.Stop();
		Console.WriteLine($"Duration: {watch.Elapsed.ToString()}");

		if (solution == null)
			return ExitError("Failed to calculate solution to part two.");
		Console.WriteLine("Part two solution:");
		Console.WriteLine(solution);
		Console.WriteLine();

		return 0;
	}

	private static int ExitError(string message)
	{
		Console.WriteLine(message);
		return -1;
	}

	private static DateTime? ParsePuzzleDate(string datestr)
	{
		Match match = Regex.Match(datestr, @"^((?<year>(\d\d){1,2})\.)?(?<day>\d?\d)$");
		if (!match.Success) return null;

		int year;
		if (match.Groups["year"].Success)
		{
			year = int.Parse(match.Groups["year"].Value);
			if (match.Groups["year"].Value.Length == 2)
				year += 2000;
		}
		else
			year = DateTime.Now.Year - (DateTime.Now.Month == 12 ? 0 : 1);

		int day = int.Parse(match.Groups["day"].Value);

		return new DateTime(year, 12, day);
	}

	private static void SetConsoleInputBuffer(int size)
	{
		Console.SetIn(new StreamReader(Console.OpenStandardInput(size), Console.InputEncoding, false, size));
	}
}
