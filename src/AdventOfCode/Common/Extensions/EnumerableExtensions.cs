using System;
using System.Collections.Generic;

namespace AdventOfCode.Common.Extensions
{
	public static class EnumerableExtensions
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

		public static int WriteToArray<T>(this IEnumerable<T> source, IIndexable<T> array)
		{
			return WriteToArray(source, array, index: 0);
		}

		public static int WriteToArray<T>(this IEnumerable<T> source, IIndexable<T> destination, int index)
		{
			int i = index;
			foreach (T value in source)
				destination[i++] = value;

			return i - index;
		}
	}
}