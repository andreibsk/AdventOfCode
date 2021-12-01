using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Common.Internal.Enumerators;

internal class IndexableEnumerator<TValue> : IEnumerator<TValue>
{
	private readonly IIndexable<TValue> _values;
	private int _index;

	public IndexableEnumerator(IIndexable<TValue> values)
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

	public void Reset() => _index = -1;
}
