using AdventOfCode.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Common
{
	[TestClass]
	public class DynamicIndexableTests
	{
		private readonly IDynamicIndexable<bool> _d = new DynamicIndexable<bool>();

		[TestMethod]
		[DataRow(new int[] { }, 0, 0)]
		[DataRow(new[] { 0 }, 0, 1)]
		[DataRow(new[] { -1 }, -1, 1)]
		[DataRow(new[] { 1 }, 1, 1)]
		[DataRow(new[] { 2 }, 2, 1)]
		[DataRow(new[] { 1, 2 }, 1, 2)]
		[DataRow(new[] { 1, 3 }, 1, 3)]
		[DataRow(new[] { 1, -2 }, -2, 4)]
		public void SizeAndLength(int[] coords, int expectedStart, int expectedLength)
		{
			foreach (int i in coords)
				_d[i] = true;

			Assert.AreEqual(expectedStart, _d.Start);
			Assert.AreEqual(expectedLength, _d.Length);
		}
	}
}
