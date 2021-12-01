namespace AdventOfCode.Common;

public interface IIndexAccessor2D<TValue>
{
	TValue this[int x, int y] { get; set; }

	TValue this[Position p]
	{
		get => this[p.X, p.Y];
		set => this[p.X, p.Y] = value;
	}
}
