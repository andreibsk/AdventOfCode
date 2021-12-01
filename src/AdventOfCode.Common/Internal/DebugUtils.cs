using System.Text;

namespace AdventOfCode.Common.Internal;

internal static class DebugUtils
{
	public static string To2DString<T>(T[,] source)
	{
		int len0 = source.GetLength(0);
		int len1 = source.GetLength(1);
		int[] maxlen = new int[len0];
		var builder = new StringBuilder();

		for (int i = 0; i < len0; i++)
		{
			for (int j = 0; j < len1; j++)
			{
				if (i == 0)
					for (int k = 0; k < len0; k++)
						maxlen[j] = Math.Max(maxlen[j], source[k, j]?.ToString()?.Length ?? 0);

				builder.Append((source[i, j]?.ToString() ?? ".").PadLeft(maxlen[i]));
				if (j != len1 - 1)
					builder.Append(" ");
			}

			builder.AppendLine();
		}

		return builder.ToString();
	}
}
