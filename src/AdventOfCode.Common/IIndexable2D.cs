namespace AdventOfCode.Common
{
	public interface IIndexable2D<TValue> : IIndexAccessor2D<TValue>
	{
		int Length0 { get; }
		int Length1 { get; }
	}
}
