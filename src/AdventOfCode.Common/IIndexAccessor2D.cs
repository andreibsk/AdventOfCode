using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Common;

public interface IIndexAccessor2D<TValue>
{
	TValue this[int x, int y] { get; set; }

	TValue this[Position p]
	{
		get => this[p.X, p.Y];
		set => this[p.X, p.Y] = value;
	}

	bool TryGetValue(Position p, [MaybeNullWhen(false)] out TValue value)
	{
		return TryGetValue(p.X, p.Y, out value);
	}

	bool TryGetValue(int x, int y, [MaybeNullWhen(false)] out TValue value);

	[return: MaybeNull]
	TValue GetValueOrDefault(int x, int y)
	{
		return TryGetValue(x, y, out TValue? value) ? value : default;
	}
}
