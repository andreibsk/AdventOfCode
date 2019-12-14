using System.Collections;
using System.Collections.Generic;
using AdventOfCode.Common.Internal.Enumerators;

namespace AdventOfCode.Common
{
	public interface IDynamicIndexable<TValue> : IEnumerable<TValue>
	{
		int Length { get; }
		int Start { get; }

		TValue this[int index] { get; set; }

		void Clear();

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => new DynamicIndexableEnumerator<TValue>(this);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
