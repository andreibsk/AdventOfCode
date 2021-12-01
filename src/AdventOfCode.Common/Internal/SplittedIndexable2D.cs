namespace AdventOfCode.Common.Internal;

internal class SplittedIndexable2D<TValue> : IIndexable2D<IIndexable2D<TValue>>
{
	private readonly IIndexable2D<TValue>[,] _splitted;

	public SplittedIndexable2D(IIndexable2D<TValue> source, int size) : this(source, size, size)
	{
	}

	public SplittedIndexable2D(IIndexable2D<TValue> source, int size0, int size1)
	{
		if (source.Length0 % size0 != 0 || source.Length1 % size1 != 0)
			throw new InvalidOperationException();

		_splitted = new IIndexable2D<TValue>[source.Length0 / size0, source.Length1 / size1];

		for (int i = 0; i < source.Length0 / size0; i++)
			for (int j = 0; j < source.Length1 / size1; j++)
				_splitted[i, j] = new SubIndexable2D<TValue>(source, i * size0, j * size0, size0, size1);
	}

	public int Length0 => _splitted.GetLength(0);
	public int Length1 => _splitted.GetLength(1);

	public IIndexable2D<TValue> this[int x, int y]
	{
		get => _splitted[x, y];
		set => _splitted[x, y] = value;
	}
}
