namespace AdventOfCode.Common.Internal
{
	internal class Indexable2DArray<TValue> : IIndexable2D<TValue>
	{
		private readonly TValue[,] _array;

		public Indexable2DArray(TValue[,] array)
		{
			_array = array;
		}

		public int Length0 => _array.GetLength(0);
		public int Length1 => _array.GetLength(1);

		public TValue this[int x, int y]
		{
			get => _array[x, y];
			set => _array[x, y] = value;
		}
	}
}
