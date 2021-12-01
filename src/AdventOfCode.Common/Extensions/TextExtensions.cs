using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Common.Extensions;

public static class TextExtensions
{
	public static string[] ReadToEmptyLine(this TextReader reader)
	{
		var lines = new List<string>();
		string? line;
		while ((line = reader.ReadLine()) != null)
			if (line.Length != 0)
				lines.Add(line);
			else
				break;
		return lines.ToArray();
	}
}
