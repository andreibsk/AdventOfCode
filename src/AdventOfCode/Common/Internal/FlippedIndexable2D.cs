namespace AdventOfCode.Common.Internal
{
	internal class FlippedIndexable2D<TValue> : IIndexable2D<TValue>
	{
		private readonly bool _h;
		private readonly IIndexable2D<TValue> _source;

		public FlippedIndexable2D(IIndexable2D<TValue> source, bool horizontally)
		{
			_source = source;
			_h = horizontally;
		}

		public int Length0 => _source.Length0;

		public int Length1 => _source.Length1;

		public TValue this[int x, int y]
		{
			get => _source[_h ? x : Length0 - 1 - x, _h ? Length1 - 1 - y : y];
			set => _source[_h ? x : Length0 - 1 - x, _h ? Length1 - 1 - y : y] = value;
		}
	}
}
