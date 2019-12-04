using System;
using System.Collections.Generic;

namespace AdventOfCode.Common.Extensions
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<IEnumerable<T>> AsBatches<T>(this IEnumerable<T> source, int size)
		{
			using IEnumerator<T> e = source.GetEnumerator();

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

		public static void Deconstruct<T>(this IEnumerable<T> source, out T value1, out T value2)
		{
			using IEnumerator<T> e = source.GetEnumerator();

			e.MoveNext();
			value1 = e.Current;
			e.MoveNext();
			value2 = e.Current;
		}

		public static void Deconstruct<T>(this IEnumerable<T> source, out T value1, out T value2, out T value3)
		{
			using IEnumerator<T> e = source.GetEnumerator();

			e.MoveNext();
			value1 = e.Current;
			e.MoveNext();
			value2 = e.Current;
			e.MoveNext();
			value3 = e.Current;
		}

		public static void DeconstructValuesOrDefault<T>(this IEnumerable<T> source, out T? value1, out T? value2, out T? value3)
			where T : class
		{
			using IEnumerator<T> e = source.GetEnumerator();

			value1 = e.MoveNext() ? e.Current : default;
			value2 = e.MoveNext() ? e.Current : default;
			value3 = e.MoveNext() ? e.Current : default;
		}

		public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			var keys = new HashSet<TKey>();

			foreach (TSource element in source)
				if (keys.Add(keySelector(element)))
					yield return element;
		}

		public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source)
		{
			return Repeat(source, count: int.MaxValue);
		}

		public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source, int count)
		{
			if (count < 0)
				throw new ArgumentException(nameof(count));

			while (count-- > 0)
				foreach (T value in source)
					yield return value;
		}

		public static ValueTuple<T1, T2> ToValueTuple<T1, T2>(this IEnumerable<T1> source)
		{
			source.Deconstruct(out T1 value1, out T1 value2t1);
			if (!(value2t1 is T2 value2))
				throw new InvalidCastException();

			return (value1, value2);
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
