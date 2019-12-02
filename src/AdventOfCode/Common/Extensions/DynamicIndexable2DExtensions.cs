using System.Collections.Generic;
using AdventOfCode.Common.Internal;

namespace AdventOfCode.Common.Extensions
{
	public static class DynamicIndexable2DExtensions
	{
		public static IDynamicIndexable2D<T> ToDynamicIndexable<T>(this IEnumerable<IEnumerable<T>> source)
		{
			var dindexable = new DictionaryDynamicIndexable2D<T>();
			using IEnumerator<IEnumerable<T>> e0 = source.GetEnumerator();

			int i;
			for (i = 0; e0.MoveNext(); i++)
			{
				using IEnumerator<T> e1 = e0.Current.GetEnumerator();

				int j;
				for (j = 0; e1.MoveNext(); j++)
					dindexable[i, j] = e1.Current;
			}

			return dindexable;
		}

		public static IDynamicIndexable2D<T> ToDynamicIndexable<T>(this IIndexable2D<T> source)
		{
			return new DictionaryDynamicIndexable2D<T>(source);
		}
	}
}
