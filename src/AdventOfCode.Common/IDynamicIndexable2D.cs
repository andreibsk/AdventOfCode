using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AdventOfCode.Common.Internal.Enumerators;

namespace AdventOfCode.Common
{
	public interface IDynamicIndexable2D<TValue> : IEnumerable<TValue>
	{
		int Length0 { get; }
		int Length1 { get; }

		int Start0 { get; }
		int Start1 { get; }

		TValue this[int x, int y] { get; set; }

		TValue this[Position p]
		{
			get => this[p.X, p.Y];
			set => this[p.X, p.Y] = value;
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => new DynamicIndexable2DEnumerator<TValue>(this);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public string ToString(Func<TValue, char> charSelector)
		{
			var builder = new StringBuilder(Length0 * (Length1 + Environment.NewLine.Length));
			for (int x = 0; x + Start0 < Length0; x++)
			{
				for (int y = 0; y + Start0 < Length0; y++)
					builder.Append(charSelector(this[y, x]));
				builder.Append(Environment.NewLine);
			}

			return builder.ToString();
		}
	}
}
