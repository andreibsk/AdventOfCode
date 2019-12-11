using System;
using System.Collections.Generic;
using AdventOfCode.Common.Internal;

namespace AdventOfCode.Common.Extensions
{
	public static class Indexable2DExtensions
	{
		public static IEnumerable<T> AsEnumerable<T>(this IIndexable2D<T> source)
		{
			for (int x = 0; x < source.Length0; x++)
				for (int y = 0; y < source.Length1; y++)
					yield return source[x, y];
		}

		public static IIndexable2D<T> AsIndexable<T>(this T[,] array)
		{
			return new Indexable2DArray<T>(array);
		}

		public static IIndexable2D<T> AsMergedIndexable<T>(this IIndexable2D<IIndexable2D<T>> source)
		{
			return new MergedIndexable2D<T>(source);
		}

		public static IIndexable2D<T> AsMergedIndexable<T>(this IIndexable<IIndexable<IIndexable2D<T>>> source)
		{
			return new MergedIndexable2D<T>(source);
		}

		public static IEnumerable<Position> EnumeratePositions<T>(this IIndexable2D<T> source)
		{
			return EnumeratePositionsInternal(source);
		}

		public static IEnumerable<Position> EnumeratePositions<T>(this IIndexable2D<T> source, Func<T, bool> predicate)
		{
			return EnumeratePositionsInternal(source, predicate);
		}

		public static IEnumerable<Position> EnumeratePositions<T>(this IIndexable2D<T> source, Position? after = null,
			Position? before = null)
		{
			return EnumeratePositionsInternal(source, after: after, before: before);
		}

		public static IEnumerable<Position> EnumeratePositions<T>(this IIndexable2D<T> source, Func<T, bool> predicate,
			Position? after = null, Position? before = null)
		{
			return EnumeratePositionsInternal(source, predicate, after, before);
		}

		public static IIndexable2D<T> Flip<T>(this IIndexable2D<T> source)
		{
			return Flip(source, horizontally: true);
		}

		public static IIndexable2D<T> Flip<T>(this IIndexable2D<T> source, bool horizontally)
		{
			return new FlippedIndexable2D<T>(source, horizontally);
		}

		public static IIndexable2D<T> Rotate<T>(this IIndexable2D<T> source)
		{
			return Rotate(source, times: 1);
		}

		public static IIndexable2D<T> Rotate<T>(this IIndexable2D<T> source, int times)
		{
			if (times % 4 == 0)
				return source;
			return new RotatedIndexable2D<T>(source, times);
		}

		public static IIndexable2D<IIndexable2D<T>> Split<T>(this IIndexable2D<T> source, int size)
		{
			return new SplittedIndexable2D<T>(source, size);
		}

		public static IIndexable2D<IIndexable2D<T>> Split<T>(this IIndexable2D<T> source, int size0, int size1)
		{
			return new SplittedIndexable2D<T>(source, size0, size1);
		}

		public static T[,] To2DArray<T>(this IIndexable2D<T> source)
		{
			var array = new T[source.Length0, source.Length1];

			for (int x = source.Length0 - 1; x >= 0; x--)
				for (int y = source.Length1 - 1; y >= 0; y--)
					array[x, y] = source[x, y];

			return array;
		}

		public static IIndexable2D<T> ToIndexable<T>(this IEnumerable<IEnumerable<T>> source)
		{
			return new Indexable2DArray<T>(source.To2DArray());
		}

		public static IIndexable2D<T> ToIndexable<T>(this IIndexable2D<T> source)
		{
			return new Indexable2DArray<T>(source.To2DArray());
		}

		private static IEnumerable<Position> EnumeratePositionsInternal<T>(this IIndexable2D<T> source, Func<T, bool>? predicate = null,
			Position? after = null, Position? before = null)
		{
			Position a = after ?? (0, -1);
			Position b = before ?? (source.Length0 - 1, source.Length1);

			for (int x = a.X; x <= b.X; x++)
				for (int y = x == a.X ? a.Y + 1 : 0; y < (x == b.X ? b.Y : source.Length1); y++)
					if (predicate?.Invoke(source[x, y]) ?? true)
						yield return (x, y);
		}
	}
}
