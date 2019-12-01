using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AdventOfCode.Common.Internal;

namespace AdventOfCode.Common.Extensions
{
	public static class ArrayExtensions
	{
		public static IEnumerable<IEnumerable<T>> AsRowEnumerable<T>(this T[,] array)
		{
			int len = array.GetLength(0);

			for (int index = 0; index < len; index++)
				yield return array.GetRow(index);
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

		public static T ElementAtOrDefault<T>(this T[,] array, Position p)
		{
			return array.ElementAtOrDefault(p.Y, p.X);
		}

		public static T ElementAtOrDefault<T>(this IList<T> collection, int index)
		{
			return index < collection.Count && index >= 0 ? collection[index] : default;
		}

		public static IIndexable<T> GetColumn<T>(this T[,] array, int index)
		{
			return new ArrayLine<T>(array, Internal.ArrayLine.Direction.Column, index);
		}

		public static IIndexable<T> GetRow<T>(this T[,] array, int index)
		{
			return new ArrayLine<T>(array, Internal.ArrayLine.Direction.Row, index);
		}

		public static T GetValue<T>(this T[,] array, Position p)
		{
			return array[p.X, p.Y];
		}

		public static bool HasInRange<T>(this T[,] array, Position p)
		{
			return p.X >= 0 && p.Y >= 0 && p.X < array.GetLength(0) && p.Y < array.GetLength(1);
		}

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

		public static T[,] To2DArray<T>(this IEnumerable<IEnumerable<T>> source)
		{
			return To2DArray(source, source.Count(), source.FirstOrDefault()?.Count() ?? 0);
		}

		public static T[,] To2DArray<T>(this ICollection<ICollection<T>> source)
		{
			return To2DArray(source, source.Count, source.FirstOrDefault()?.Count ?? 0);
		}

		public static T[,] To2DArray<T>(this IEnumerable<IEnumerable<T>> source, int len)
		{
			return source.To2DArray(len, len);
		}

		public static T[,] To2DArray<T>(this IEnumerable<IEnumerable<T>> source, int len0, int len1)
		{
			using IEnumerator<IEnumerable<T>> e0 = source.GetEnumerator();
			var array = new T[len0, len1];

			int i;
			for (i = 0; i < len0 && e0.MoveNext(); i++)
			{
				if (e0.Current == null)
					throw new FormatException("Rows do not match");

				using IEnumerator<T> e1 = e0.Current.GetEnumerator();

				int j;
				for (j = 0; j < len1 && e1.MoveNext(); j++)
				{
					array[i, j] = e1.Current;
				}

				if (j != len1 || e1.MoveNext())
					throw new FormatException("Columns do not match.");
			}

			if (i != len0 || e0.MoveNext())
				throw new FormatException("Rows do not match.");

			return array;
		}

		public static bool TryGetValue<T>(this T[,] array, Position p, [MaybeNullWhen(false)] out T value)
		{
			if (array.HasInRange(p))
			{
				value = array[p.X, p.Y];
				return true;
			}
			else
			{
				value = default!;
				return false;
			}
		}
	}
}
