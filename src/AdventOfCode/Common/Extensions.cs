using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Common
{
	public static class Extensions
	{
		public static IEnumerable<IEnumerable<T>> AsBatches<T>(this IEnumerable<T> source, int size)
		{
			IEnumerator<T> e = source.GetEnumerator();

			while (e.MoveNext())
				yield return NextBatch();

			IEnumerable<T> NextBatch()
			{
				int i = size;
				do
				{
					yield return e.Current;
				}
				while (--i > 0 && e.MoveNext());
			}
		}

		public static IEnumerable<IEnumerable<T>> AsRowEnumerable<T>(this T[,] array)
		{
			int len = array.GetLength(0);

			for (int i = 0; i < len; i++)
				yield return new ArrayLine<T>(array, ArrayLine.Direction.Row, index: i);
		}

		public static T ElementAtOrDefault<T>(this IList<T> collection, int index)
		{
			return index < collection.Count && index >= 0 ? collection[index] : default;
		}

		public static T ElementAtOrDefault<T>(this T[] array, int index)
		{
			return index < array.Length && index >= 0 ? array[index] : default;
		}

		public static T ElementAtOrDefault<T>(this T[,] array, int i, int j)
		{
			if (i >= 0 && j >= 0 && i < array.GetLength(0) && j < array.GetLength(1))
				return array[i, j];
			else
				return default!;
		}

		public static T ElementAtOrDefault<T>(this T[,] array, Position p) => array.ElementAtOrDefault(p.Y, p.X);

		public static int IndexOfMaxValue<T>(this IList<T> list) where T : IComparable<T>
		{
			if (list.Count == 0)
				return -1;

			int m = 0;

			for (int i = 1; i < list.Count; i++)
				if (list[i].CompareTo(list[m]) > 0)
					m = i;

			return m;
		}

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

		public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source) => Repeat(source, count: int.MaxValue);

		public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source, int count)
		{
			if (count < 0)
				throw new ArgumentException(nameof(count));

			while (count-- > 0)
				foreach (T value in source)
					yield return value;
		}

		public static T[,] To2DArray<T>(this IEnumerable<IEnumerable<T>> source, int len0, int len1)
		{
			var array = new T[len0, len1];

			IEnumerator<IEnumerable<T>> e0 = source.GetEnumerator();
			for (int i = 0; i < len0; i++)
			{
				if (!e0.MoveNext())
					throw new FormatException();

				IEnumerator<T> e1 = e0.Current.GetEnumerator();
				for (int j = 0; j < len1; j++)
				{
					if (!e1.MoveNext())
						throw new FormatException();

					array[i, j] = e1.Current;
				}
			}

			return array;
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

		public static int WriteToArray<T>(this IEnumerable<T> source, IIndexable<T> array) => WriteToArray(source, array, index: 0);

		public static int WriteToArray<T>(this IEnumerable<T> source, IIndexable<T> destination, int index)
		{
			int i = index;
			foreach (T value in source)
				destination[i++] = value;

			return i - index;
		}
	}
}
