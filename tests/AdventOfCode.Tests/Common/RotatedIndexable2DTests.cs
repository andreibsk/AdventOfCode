using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;
using AdventOfCode.Common.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Common
{
	[TestClass]
	public class RotatedIndexable2DTests
	{
		private readonly IIndexable2D<int> _initial = new[,]
		{
			{ 0, 1, 2, 3 },
			{ 4, 5, 6, 7 }
		}.AsIndexable();

		[TestMethod]
		public void Rotate1()
		{
			IIndexable2D<int> rotated = new RotatedIndexable2D<int>(_initial, times: 1);

			Assert.AreEqual(_initial.Length1, rotated.Length0);
			Assert.AreEqual(_initial.Length0, rotated.Length1);
			Assert.AreEqual(_initial[1, 0], rotated[0, 0]);
			Assert.AreEqual(_initial[0, 2], rotated[2, 1]);
		}

		[TestMethod]
		public void Rotate2()
		{
			IIndexable2D<int> rotated = new RotatedIndexable2D<int>(_initial, times: 2);

			Assert.AreEqual(_initial.Length0, rotated.Length0);
			Assert.AreEqual(_initial.Length1, rotated.Length1);
			Assert.AreEqual(_initial[1, 3], rotated[0, 0]);
			Assert.AreEqual(_initial[0, 1], rotated[1, 2]);
		}

		[TestMethod]
		public void Rotate3()
		{
			IIndexable2D<int> rotated = new RotatedIndexable2D<int>(_initial, times: 3);

			Assert.AreEqual(_initial.Length1, rotated.Length0);
			Assert.AreEqual(_initial.Length0, rotated.Length1);
			Assert.AreEqual(_initial[0, 3], rotated[0, 0]);
			Assert.AreEqual(_initial[1, 1], rotated[2, 1]);
		}

		[TestMethod]
		public void Rotate4()
		{
			IIndexable2D<int> rotated = new RotatedIndexable2D<int>(_initial, times: 4);

			Assert.AreEqual(_initial.Length0, rotated.Length0);
			Assert.AreEqual(_initial.Length1, rotated.Length1);
			Assert.AreEqual(_initial[0, 0], rotated[0, 0]);
			Assert.AreEqual(_initial[1, 2], rotated[1, 2]);
		}
	}
}
