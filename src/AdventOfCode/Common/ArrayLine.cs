using System.Linq;

namespace AdventOfCode.Common
{
	public abstract class ArrayLine
	{
		protected readonly Direction _direction;
		protected readonly int _index1;

		protected ArrayLine(Direction direction, int index)
		{
			_direction = direction;
			_index1 = index;
		}

		public enum Direction
		{
			Column,
			Row
		}
	}

	public class ArrayLine<T> : ArrayLine, IIndexable<T>
	{
		private readonly T[,] _source;

		public ArrayLine(T[,] source, Direction direction, int index) : base(direction, index)
		{
			_source = source;
		}

		public int Length => _source.GetLength(_direction == Direction.Row ? 1 : 0);

		public T this[int index2]
		{
			get => _source[_direction == Direction.Row ? _index1 : index2, _direction == Direction.Row ? index2 : _index1];
			set => _source[_direction == Direction.Row ? _index1 : index2, _direction == Direction.Row ? index2 : _index1] = value;
		}

		public void Rotate(int n)
		{
			n %= Length;

			if (n == 0)
				return;
			if (n < 0)
				n = Length + n;

			var x = this.Concat(this).Skip(Length - n).Take(Length).ToArray();
			x.WriteToArray(this);
		}
	}
}
