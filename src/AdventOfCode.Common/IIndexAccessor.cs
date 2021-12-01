using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Common;

public interface IIndexAccessor<TValue>
{
	TValue this[int index] { get; set; }

	bool TryGetValue(int index, [MaybeNullWhen(false)] out TValue value);

	[return: MaybeNull]
	TValue GetValueOrDefault(int index)
	{
		return TryGetValue(index, out TValue? value) ? value : default;
	}
}
