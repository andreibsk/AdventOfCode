namespace AdventOfCode.Common.Extensions
{
	public static class DynamicIndexableExtensions
	{
		public static IDynamicIndexable<T> ToDynamicIndexable<T>(this T[] source)
		{
			return ToDynamicIndexable(source.AsIndexable());
		}

		public static IDynamicIndexable<T> ToDynamicIndexable<T>(this IIndexable<T> source)
		{
			return new DynamicIndexable<T>(source);
		}
	}
}
