using System;

namespace AdventOfCode.Common.Extensions;

public static class ValueExtensions
{
	public static int CombineHashCode(this int c1, int c2)
	{
		return ((c1 << 5) + c1) ^ c2;
	}

	public static int Gcd(this int a, int b)
	{
		return (int)Gcd(a, (long)b);
	}

	public static long Gcd(this long a, long b)
	{
		a = Math.Abs(a);
		b = Math.Abs(b);

		while (a != 0 && b != 0)
		{
			if (a > b)
				a %= b;
			else
				b %= a;
		}

		return a == 0 ? b : a;
	}

	public static long Lcm(this int a, int b)
	{
		return Lcm(a, (long)b);
	}

	public static long Lcm(this long a, long b)
	{
		return a / a.Gcd(b) * b;
	}

	public static int SetBitsCount(this int i)
	{
		i -= (i >> 1) & 0x55555555;
		i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
		return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
	}

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
