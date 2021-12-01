using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Common.Internal;

internal abstract class ArrayLine
{
	protected readonly Direction _direction;
	protected readonly int _index1;

	protected ArrayLine(Direction direction, int index)
	{
		_direction = direction;
		_index1 = index;
	}

	public enum Direction
	{
		Column,
		Row
	}
}

internal class ArrayLine<T> : ArrayLine, IIndexable<T>
{
	private readonly T[,] _source;

	public ArrayLine(T[,] source, Direction direction, int index) : base(direction, index)
	{
		_source = source;
	}

	public int Length => _source.GetLength(_direction == Direction.Row ? 1 : 0);

	public T this[int index2]
	{
		get => _source[_direction == Direction.Row ? _index1 : index2, _direction == Direction.Row ? index2 : _index1];
		set => _source[_direction == Direction.Row ? _index1 : index2, _direction == Direction.Row ? index2 : _index1] = value;
	}

	public bool TryGetValue(int index2, [MaybeNullWhen(false)] out T value)
	{
		return _source.TryGetValue(_direction == Direction.Row ? (_index1, index2) : (index2, _index1), out value);
	}
}
