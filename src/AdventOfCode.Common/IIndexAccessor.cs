namespace AdventOfCode.Common;

public interface IIndexAccessor<TValue>
{
	TValue this[int index] { get; set; }
}
