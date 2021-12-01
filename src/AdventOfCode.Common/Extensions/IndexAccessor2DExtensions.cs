namespace AdventOfCode.Common.Extensions;

public static class IndexAccessor2DExtensions
{
	public static IEnumerable<Position> EnumeratePositions<T>(this IIndexAccessor2D<T> source, int start0, int length0,
		int start1, int length1, Func<T, bool>? predicate = null, Position? after = null, Position? before = null,
		bool screenMode = false)
	{
		if (screenMode)
		{
			Position a = after ?? (start0, start0 - 1);
			Position b = before ?? (length0 + start0 - 1, length1 + start1);

			for (int y = a.Y; y <= b.Y; y++)
				for (int x = y == a.Y ? a.X + 1 : start0; x < (y == b.Y ? b.X : length0 + start0); x++)
					if (predicate?.Invoke(source[x, y]) ?? true)
						yield return (x, y);
		}
		else
		{
			Position a = after ?? (start0, start0 - 1);
			Position b = before ?? (length0 + start0 - 1, length1 + start1);

			for (int x = a.X; x <= b.X; x++)
				for (int y = x == a.X ? a.Y + 1 : start1; y < (x == b.X ? b.Y : length1 + start1); y++)
					if (predicate?.Invoke(source[x, y]) ?? true)
						yield return (x, y);
		}
	}
}
