using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Common
{
	public static class Extensions
	{
		public static IEnumerable<IEnumerable<T>> AsBatches<T>(this IList<T> list, int size)
		{
			return Enumerable.Range(0, (list.Count - 1) / size + 1).Select(i => BatchAt(i * size));

			IEnumerable<T> BatchAt(int index)
			{
				for (int i = index; i < index + size && i < list.Count; i++)
					yield return list[i];
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

		public static int ToDigit(this char c)
		{
			if (!char.IsDigit(c))
				throw new ArgumentOutOfRangeException(nameof(c));
			return c - '0';
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
