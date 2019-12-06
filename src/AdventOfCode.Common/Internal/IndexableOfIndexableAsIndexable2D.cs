using System;

namespace AdventOfCode.Common.Internal
{
	internal class IndexableOfIndexableAsIndexable2D<TValue> : IIndexable2D<TValue>
	{
		private readonly IIndexable<IIndexable<TValue>> _source;

		public IndexableOfIndexableAsIndexable2D(IIndexable<IIndexable<TValue>> source)
		{
			Length0 = source.Length;
			Length1 = 0;

			if (source.Length > 0)
				Length1 = source[0].Length;

			foreach (IIndexable<TValue> row in source)
				if (row.Length != Length1)
					throw new FormatException("Variable row length.");

			_source = source;
		}

		public int Length0 { get; }

		public int Length1 { get; }

		public TValue this[int x, int y]
		{
			get => _source[x][y];
			set => _source[x][y] = value;
		}
	}
}
