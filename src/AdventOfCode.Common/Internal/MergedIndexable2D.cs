using System;

namespace AdventOfCode.Common.Internal;

internal class MergedIndexable2D<TValue> : IIndexable2D<TValue>
{
	private readonly IIndexable2D<IIndexable2D<TValue>> _blocks;

	public MergedIndexable2D(IIndexable<IIndexable<IIndexable2D<TValue>>> source)
		: this(new IndexableOfIndexableAsIndexable2D<IIndexable2D<TValue>>(source))
	{
	}

	public MergedIndexable2D(IIndexable2D<IIndexable2D<TValue>> source)
	{
		Length0 = 0;
		Length1 = 0;

		for (int i = 0; i < source.Length0; i++)
		{
			int rowHeight = 0;
			int currentRowLength = 0;

			for (int j = 0; j < source.Length1; j++)
			{
				IIndexable2D<TValue> block = source[i, j];

				if (rowHeight == 0)
					rowHeight = block.Length0;

				currentRowLength += block.Length1;

				if (block.Length0 != rowHeight)
					throw new FormatException("Variable block height in block row.");
			}

			Length0 += rowHeight;

			if (Length1 == 0)
				Length1 = currentRowLength;

			if (currentRowLength != Length1)
				throw new FormatException("Variable block length.");
		}

		_blocks = source;
	}

	public int Length0 { get; }

	public int Length1 { get; }

	public TValue this[int x, int y]
	{
		get
		{
			GetComposedIndex(x, y, out int ox, out int ix, out int oy, out int iy);
			return _blocks[ox, oy][ix, iy];
		}
		set
		{
			GetComposedIndex(x, y, out int ox, out int ix, out int oy, out int iy);
			_blocks[ox, oy][ix, iy] = value;
		}
	}

	private void GetComposedIndex(int x, int y, out int outerX, out int innerX, out int outerY, out int innerY)
	{
		int sum;

		outerX = 0;
		for (sum = _blocks[outerX, 0].Length0; x >= sum; sum += _blocks[outerX, 0].Length0)
			outerX++;
		innerX = x - (sum - _blocks[outerX, 0].Length0);

		outerY = 0;
		for (sum = _blocks[outerX, outerY].Length1; y >= sum; sum += _blocks[outerX, outerY].Length1)
			outerY++;
		innerY = y - (sum - _blocks[outerX, outerY].Length1);
	}
}
