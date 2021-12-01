using System;

namespace AdventOfCode.Common.Internal;

internal class SubIndexable2D<TValue> : IIndexable2D<TValue>
{
	private readonly IIndexable2D<TValue> _source;
	private readonly int _x;
	private readonly int _y;

	public SubIndexable2D(IIndexable2D<TValue> source, int x, int y, int length0, int length1)
	{
		if (source.Length0 < x + length0 || source.Length1 < y + length1)
			throw new ArgumentOutOfRangeException();

		_source = source;
		_x = x;
		_y = y;
		Length0 = length0;
		Length1 = length1;
	}

	public int Length0 { get; }

	public int Length1 { get; }

	public TValue this[int x, int y]
	{
		get
		{
			if (x < 0 || x >= Length0 || y < 0 || y >= Length1)
				throw new IndexOutOfRangeException();

			return _source[_x + x, _y + y];
		}
		set
		{
			if (x < 0 || x >= Length0 || y < 0 || y >= Length1)
				throw new IndexOutOfRangeException();

			_source[_x + x, _y + y] = value;
		}
	}
}
