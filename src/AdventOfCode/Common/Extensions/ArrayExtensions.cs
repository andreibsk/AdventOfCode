using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

		public static ArrayLine<T> GetColumn<T>(this T[,] array, int index)
		{
			return new ArrayLine<T>(array, ArrayLine.Direction.Column, index);
		}

		public static ArrayLine<T> GetRow<T>(this T[,] array, int index)
		{
			return new ArrayLine<T>(array, ArrayLine.Direction.Row, index);
		}

		public static T GetValue<T>(this T[,] array, Position p)
		{
			return array[p.X, p.Y];
		}

		public static bool HasInRange<T>(this T[,] array, Position p)
		{
			return p.X >= 0 && p.Y >= 0 && p.X < array.GetLength(0) && p.Y < array.GetLength(1);
		}

		public static int IndexOf<T>(this IIndexable<T> array, T value)
		{
			EqualityComparer<T> comparer = EqualityComparer<T>.Default;

			for (int i = 0; i < array.Length; i++)
				if (comparer.Equals(array[i], value))
					return i;

			return -1;
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

		public static void Rotate<T>(this IIndexable<T> array, int n)
		{
			n %= array.Length;

			if (n == 0)
				return;
			if (n < 0)
				n = array.Length + n;

			var values = array
				.Concat(array)
				.Skip(array.Length - n)
				.Take(array.Length).ToList();

			values.WriteToArray(array);
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
