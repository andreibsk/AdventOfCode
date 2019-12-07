using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Common
{
	public interface IIndexable<TValue> : IEnumerable<TValue>
	{
		int Length { get; }
		TValue this[int index] { get; set; }

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => new IndexableEnumerator(this);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private class IndexableEnumerator : IEnumerator<TValue>
		{
			private readonly IIndexable<TValue> _values;
			private int _index = -1;

			public IndexableEnumerator(IIndexable<TValue> values)
			{
				_values = values;
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
	}
}
