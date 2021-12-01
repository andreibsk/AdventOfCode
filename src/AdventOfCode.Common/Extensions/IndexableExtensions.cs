using AdventOfCode.Common.Internal;

namespace AdventOfCode.Common.Extensions;

public static class IndexableExtensions
{
	public static IIndexable<T> AsIndexable<T>(this T[] array)
	{
		return new IndexableArray<T>(array);
	}

	public static int IndexOf<T>(this IIndexable<T> array, T value)
	{
		EqualityComparer<T> comparer = EqualityComparer<T>.Default;

		for (int i = 0; i < array.Length; i++)
			if (comparer.Equals(array[i], value))
				return i;

		return -1;
	}

	public static void RotateValues<T>(this IIndexable<T> array, int times)
	{
		times %= array.Length;

		if (times == 0)
			return;
		if (times < 0)
			times = array.Length + times;

		var values = array
			.Concat(array)
			.Skip(array.Length - times)
			.Take(array.Length)
			.ToList();

		values.WriteToArray(array);
	}
}
