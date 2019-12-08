using System.Collections.Generic;

namespace AdventOfCode.Common
{
	public class DynamicIndexable<TValue> : IDynamicIndexable<TValue>
	{
		private readonly IDictionary<int, TValue> _dictionary;

		public DynamicIndexable() : this(new Dictionary<int, TValue>(), start: 0, length: 0)
		{
		}

		public DynamicIndexable(IIndexable<TValue> source) : this(IndexableToDictionary(source), start: 0, length: source.Length)
		{
		}

		private DynamicIndexable(IDictionary<int, TValue> dictionary, int start, int length)
		{
			_dictionary = dictionary;
			Start = start;
			Length = length;
		}

		public int Length { get; private set; }

		public int Start { get; private set; }

		public TValue this[int index]
		{
			get => _dictionary.TryGetValue(index, out TValue value) ? value : default;

			set
			{
				_dictionary[index] = value;

				if (index < Start)
				{
					Length = Length + Start - index;
					Start = index;
				}
				else if (index >= Start + Length)
				{
					Length = index - Start;
				}
			}
		}

		private static IDictionary<int, TValue> IndexableToDictionary(IIndexable<TValue> source)
		{
			var dictionary = new Dictionary<int, TValue>(capacity: source.Length);

			for (int i = 0; i < source.Length; i++)
				dictionary[i] = source[i];

			return dictionary;
		}
	}
}
