namespace AdventOfCode.Common.Internal;

internal class IndexableArray<TValue> : IIndexable<TValue>
{
	private readonly TValue[] _array;

	public IndexableArray(TValue[] array)
	{
		_array = array;
	}

	public int Length => _array.Length;

	public TValue this[int index]
	{
		get => _array[index];
		set => _array[index] = value;
	}
}
