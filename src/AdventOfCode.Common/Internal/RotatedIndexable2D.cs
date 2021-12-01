namespace AdventOfCode.Common.Internal;

internal class RotatedIndexable2D<TValue> : IIndexable2D<TValue>
{
	private readonly IIndexable2D<TValue> _source;
	private readonly int _times;

	public RotatedIndexable2D(IIndexable2D<TValue> source, int times)
	{
		_source = source;
		_times = (times % 4 + 4) % 4;
	}

	public int Length0 => _times % 2 == 0 ? _source.Length0 : _source.Length1;

	public int Length1 => _times % 2 == 0 ? _source.Length1 : _source.Length0;

	public TValue this[int x, int y]
	{
		get
		{
			Rotate(ref x, ref y);
			return _source[x, y];
		}
		set
		{
			Rotate(ref x, ref y);
			_source[x, y] = value;
		}
	}

	private void Rotate(ref int x, ref int y)
	{
		switch (_times)
		{
			case 1:
				int t = x;
				x = Length1 - 1 - y;
				y = t;
				break;

			case 2:
				x = Length0 - 1 - x;
				y = Length1 - 1 - y;
				break;

			case 3:
				t = x;
				x = y;
				y = Length0 - 1 - t;
				break;
		}
	}
}
