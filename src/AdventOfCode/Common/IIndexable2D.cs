namespace AdventOfCode.Common
{
	public interface IIndexable2D<TValue>
	{
		int Length0 { get; }
		int Length1 { get; }

		TValue this[int x, int y] { get; set; }
	}
}
