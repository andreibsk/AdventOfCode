using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Common.Internal.Enumerators
{
	internal class DynamicIndexable2DEnumerator<TValue> : IEnumerator<TValue>
	{
		private readonly IDynamicIndexable2D<TValue> _values;
		private int _x;
		private int _y;

		public DynamicIndexable2DEnumerator(IDynamicIndexable2D<TValue> values)
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
					return _values[_x, _y];
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}

		object? IEnumerator.Current => Current;

		public void Dispose() { }

		public bool MoveNext()
		{
			_y++;
			if (_values.Start0 + _y > _values.Length1)
			{
				_y = 0;
				_x++;
			}
			return _values.Start0 + _x < _values.Length0;
		}

		public void Reset() => _x = _y = -1;
	}
}
