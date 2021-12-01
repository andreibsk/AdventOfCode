using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Common;

[TestClass]
public class DynamicIndexable2DTests
{
	private readonly IDynamicIndexable2D<bool> _d = new DynamicIndexable2D<bool>();

	[TestMethod]
	[DataRow(new int[] { }, 0, 0, 0, 0)]
	[DataRow(new[] { 0, 0 }, 0, 0, 1, 1)]
	[DataRow(new[] { -1, 0 }, -1, 0, 1, 1)]
	[DataRow(new[] { 0, -1 }, 0, -1, 1, 1)]
	[DataRow(new[] { 1, 0 }, 1, 0, 1, 1)]
	[DataRow(new[] { 0, 1 }, 0, 1, 1, 1)]
	[DataRow(new[] { 2, 2 }, 2, 2, 1, 1)]
	[DataRow(new[] { 1, 1, 2, 3 }, 1, 1, 2, 3)]
	[DataRow(new[] { 1, 1, 3, 2 }, 1, 1, 3, 2)]
	[DataRow(new[] { 1, 1, -2, -3 }, -2, -3, 4, 5)]
	[DataRow(new[] { 1, 1, -3, -2 }, -3, -2, 5, 4)]
	public void SizeAndLength(int[] coords, int expectedStart0, int expectedStart1, int expectedLength0, int expectedLength1)
	{
		foreach ((int x, int y) in coords.AsBatches(size: 2).Select(p => p.ToValueTuple<int, int>()))
			_d[x, y] = true;

		Assert.AreEqual(expectedStart0, _d.Start0);
		Assert.AreEqual(expectedStart1, _d.Start1);
		Assert.AreEqual(expectedLength0, _d.Length0);
		Assert.AreEqual(expectedLength1, _d.Length1);
	}
}
