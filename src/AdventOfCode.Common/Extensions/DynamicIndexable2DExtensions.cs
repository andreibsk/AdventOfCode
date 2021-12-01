using System.Text;

namespace AdventOfCode.Common.Extensions;

public static class DynamicIndexable2DExtensions
{
	public static IEnumerable<Position> EnumeratePositions<T>(this IDynamicIndexable2D<T> source)
	{
		return source.EnumeratePositions(source.Start0, source.Length0, source.Start1, source.Length1);
	}

	public static IEnumerable<Position> EnumeratePositions<T>(this IDynamicIndexable2D<T> source, bool screenMode = false)
	{
		return source.EnumeratePositions(source.Start0, source.Length0, source.Start1, source.Length1, screenMode: screenMode);
	}

	public static IEnumerable<Position> EnumeratePositions<T>(this IDynamicIndexable2D<T> source, Func<T, bool> predicate,
		bool screenMode = false)
	{
		return source.EnumeratePositions(source.Start0, source.Length0, source.Start1, source.Length1, predicate,
			screenMode: screenMode);
	}

	public static IEnumerable<Position> EnumeratePositions<T>(this IDynamicIndexable2D<T> source, Position? after = null,
		Position? before = null, bool screenMode = false)
	{
		return source.EnumeratePositions(source.Start0, source.Length0, source.Start1, source.Length1, after: after, before: before,
			screenMode: screenMode);
	}

	public static IEnumerable<Position> EnumeratePositions<T>(this IDynamicIndexable2D<T> source, Func<T, bool> predicate,
		Position? after = null, Position? before = null, bool screenMode = false)
	{
		return source.EnumeratePositions(source.Start0, source.Length0, source.Start1, source.Length1, predicate, after, before,
			screenMode: screenMode);
	}

	public static IDynamicIndexable2D<T> ToDynamicIndexable<T>(this IEnumerable<IEnumerable<T>> source)
	{
		var dindexable = new DynamicIndexable2D<T>();
		using IEnumerator<IEnumerable<T>> e0 = source.GetEnumerator();

		int i;
		for (i = 0; e0.MoveNext(); i++)
		{
			using IEnumerator<T> e1 = e0.Current.GetEnumerator();

			int j;
			for (j = 0; e1.MoveNext(); j++)
				dindexable[i, j] = e1.Current;
		}

		return dindexable;
	}

	public static IDynamicIndexable2D<T> ToDynamicIndexable<T>(this IIndexable2D<T> source)
	{
		return new DynamicIndexable2D<T>(source);
	}

	public static string ToString<T>(this IDynamicIndexable2D<T> source, Func<T, char> charSelector, bool screenMode = false)
	{
		var builder = new StringBuilder(source.Length0 * (source.Length1 + Environment.NewLine.Length));
		int? row = null;

		foreach (Position pos in source.EnumeratePositions(screenMode))
		{
			if (row.HasValue && (screenMode ? pos.Y : pos.X) != row.Value)
				builder.Append(Environment.NewLine);
			row = screenMode ? pos.Y : pos.X;
			builder.Append(charSelector(source[pos]));
		}

		return builder.ToString();
	}
}
