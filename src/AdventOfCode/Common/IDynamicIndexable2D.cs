namespace AdventOfCode.Common
{
	public interface IDynamicIndexable2D<TValue>
	{
		int Length0 { get; }
		int Length1 { get; }

		int Start0 { get; }
		int Start1 { get; }

		TValue this[int x, int y] { get; set; }
	}
}
