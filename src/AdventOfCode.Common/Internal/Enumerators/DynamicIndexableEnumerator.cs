using System.Collections;

namespace AdventOfCode.Common.Internal.Enumerators;

internal class DynamicIndexableEnumerator<TValue> : IEnumerator<TValue>
{
	private readonly IDynamicIndexable<TValue> _values;
	private int _index;

	public DynamicIndexableEnumerator(IDynamicIndexable<TValue> values)
	{
		_values = values;
		Reset();
	}

	public TValue Current
	{
		get
		{
			try
			{
				return _values[_index];
			}
			catch (IndexOutOfRangeException)
			{
				throw new InvalidOperationException();
			}
		}
	}

	object? IEnumerator.Current => Current;

	public void Dispose() { }

	public bool MoveNext() => ++_index < _values.Length;

	public void Reset() => _index = _values.Start - 1;
}
