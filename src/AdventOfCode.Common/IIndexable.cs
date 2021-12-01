using System.Collections;
using System.Collections.Generic;
using AdventOfCode.Common.Internal.Enumerators;

namespace AdventOfCode.Common;

public interface IIndexable<TValue> : IIndexAccessor<TValue>, IEnumerable<TValue>
{
	int Length { get; }

	IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => new IndexableEnumerator<TValue>(this);

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
