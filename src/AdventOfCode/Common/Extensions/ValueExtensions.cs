using System;

namespace AdventOfCode.Common.Extensions
{
	public static class ValueExtensions
	{
		public static int ToDigit(this char c)
		{
			if (!char.IsDigit(c))
				throw new ArgumentOutOfRangeException(nameof(c));
			return c - '0';
		}

		public static bool[] ToHexBits(this char hexChar)
		{
			return char.ToUpper(hexChar) switch
			{
				'0' => new[] { false, false, false, false },
				'1' => new[] { false, false, false, true },
				'2' => new[] { false, false, true, false },
				'3' => new[] { false, false, true, true },
				'4' => new[] { false, true, false, false },
				'5' => new[] { false, true, false, true },
				'6' => new[] { false, true, true, false },
				'7' => new[] { false, true, true, true },
				'8' => new[] { true, false, false, false },
				'9' => new[] { true, false, false, true },
				'A' => new[] { true, false, true, false },
				'B' => new[] { true, false, true, true },
				'C' => new[] { true, true, false, false },
				'D' => new[] { true, true, false, true },
				'E' => new[] { true, true, true, false },
				'F' => new[] { true, true, true, true },
				_ => throw new FormatException()
			};
		}

		public static long? ToLongOrDefault(this string? s)
		{
			return long.TryParse(s, out long value) ? value : default(long?);
		}
	}
}
