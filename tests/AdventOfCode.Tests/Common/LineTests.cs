using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Common
{
	[TestClass]
	public class LineTests
	{
		private readonly int[,] _data = new int[,]
		{
			{ 1, 2, 3, 4, 5, 6 },
			{ 7, 8, 9, 10, 11, 12 },
			{ 13, 14, 15, 16, 17, 18 },
		};

		[TestMethod]
		public void ReadColumn()
		{
			var line = new ArrayLine<int>(_data, ArrayLine.Direction.Column, index: 1);

			Assert.AreEqual(3, line.Length);
			Assert.AreEqual(2, line[0]);
			Assert.AreEqual(14, line[2]);
		}

		[TestMethod]
		public void ReadRow()
		{
			var line = new ArrayLine<int>(_data, ArrayLine.Direction.Row, index: 1);

			Assert.AreEqual(6, line.Length);
			Assert.AreEqual(7, line[0]);
			Assert.AreEqual(12, line[5]);
		}

		[TestMethod]
		public void RotateColumn()
		{
			var line = new ArrayLine<int>(_data, ArrayLine.Direction.Column, index: 1);

			line.Rotate(1);

			Assert.AreEqual(14, line[0]);
			Assert.AreEqual(8, line[2]);
		}

		[TestMethod]
		public void RotateManyColumn()
		{
			var line = new ArrayLine<int>(_data, ArrayLine.Direction.Column, index: 1);

			line.Rotate(2);

			Assert.AreEqual(8, line[0]);
			Assert.AreEqual(2, line[2]);
		}

		[TestMethod]
		public void RotateManyRow()
		{
			var line = new ArrayLine<int>(_data, ArrayLine.Direction.Row, index: 1);

			line.Rotate(5);

			Assert.AreEqual(8, line[0]);
			Assert.AreEqual(7, line[5]);
		}

		[TestMethod]
		public void RotateRow()
		{
			var line = new ArrayLine<int>(_data, ArrayLine.Direction.Row, index: 1);

			line.Rotate(1);

			Assert.AreEqual(12, line[0]);
			Assert.AreEqual(11, line[5]);
		}
	}
}
