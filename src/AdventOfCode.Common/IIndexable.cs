using System.Collections;
using System.Collections.Generic;
using AdventOfCode.Common.Internal.Enumerators;

namespace AdventOfCode.Common
{
	public interface IIndexable<TValue> : IEnumerable<TValue>
	{
		int Length { get; }
		TValue this[int index] { get; set; }

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => new IndexableEnumerator<TValue>(this);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
