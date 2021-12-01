using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AdventOfCode.Common.Internal.Enumerators;

namespace AdventOfCode.Common;

public interface IDynamicIndexable2D<TValue> : IIndexAccessor2D<TValue>, IEnumerable<TValue>
{
	int Length0 { get; }
	int Length1 { get; }

	int Start0 { get; }
	int Start1 { get; }

	IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => new DynamicIndexable2DEnumerator<TValue>(this);

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
