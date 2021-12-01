namespace AdventOfCode.Common;

public class DynamicIndexable2D<TValue> : IDynamicIndexable2D<TValue>
{
	private readonly IDictionary<(int, int), TValue> _dictionary;
	private bool _hasValues;

	public DynamicIndexable2D() : this(new Dictionary<(int, int), TValue>(), s0: 0, s1: 0, l0: 0, l1: 0)
	{
	}

	public DynamicIndexable2D(IIndexable2D<TValue> source)
		: this(Indexable2DToDictionary(source), s0: 0, s1: 0, l0: source.Length0, l1: source.Length1)
	{
	}

	private DynamicIndexable2D(IDictionary<(int, int), TValue> dictionary, int s0, int s1, int l0, int l1)
	{
		_dictionary = dictionary;
		_hasValues = dictionary.Count > 0;
		Start0 = s0;
		Start1 = s1;
		Length0 = l0;
		Length1 = l1;
	}

	public int Length0 { get; private set; }

	public int Length1 { get; private set; }

	public int Start0 { get; private set; }

	public int Start1 { get; private set; }

	public TValue this[int x, int y]
	{
		get => _dictionary.TryGetValue((x, y), out TValue value) ? value : default;

		set
		{
			_dictionary[(x, y)] = value;

			if (!_hasValues)
			{
				Start0 = x;
				Start1 = y;
				Length0 = Length1 = 1;
				_hasValues = true;
				return;
			}

			if (x < Start0)
			{
				Length0 = Length0 + Start0 - x;
				Start0 = x;
			}
			else if (x >= Start0 + Length0)
			{
				Length0 = x - Start0 + 1;
			}

			if (y < Start1)
			{
				Length1 = Length1 + Start1 - y;
				Start1 = y;
			}
			else if (y >= Start1 + Length1)
			{
				Length1 = y - Start1 + 1;
			}
		}
	}

	private static IDictionary<(int, int), TValue> Indexable2DToDictionary(IIndexable2D<TValue> source)
	{
		var dictionary = new Dictionary<(int, int), TValue>(capacity: source.Length0 * source.Length1);

		for (int x = 0; x < source.Length0; x++)
			for (int y = 0; y < source.Length1; y++)
				dictionary[(x, y)] = source[x, y];

		return dictionary;
	}
}
