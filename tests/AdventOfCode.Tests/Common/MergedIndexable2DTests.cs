using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;
using AdventOfCode.Common.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Common
{
	[TestClass]
	public class MergedIndexable2DTests
	{
		/*
		 *  1  2 |  3  4  5
		 *  6  7 |  8  9 10
		 * ----------------
		 * 11 12 13 | 14 15
		 * 16 17 18 | 19 20
		 */

		private readonly MergedIndexable2D<int> _merged = new MergedIndexable2D<int>(new IIndexable2D<int>[,]
		{
			{
				new[,]
				{
					{ 1, 2 },
					{ 6, 7 }
				}.AsIndexable(),
				new[,]
				{
					{ 3, 4, 5 },
					{ 8, 9, 10 }
				}.AsIndexable(),
			},
			{
				new[,]
				{
					{ 11, 12, 13 },
					{ 16, 17, 18 }
				}.AsIndexable(),
				new[,]
				{
					{ 14, 15 },
					{ 19, 20 }
				}.AsIndexable(),
			}
		}.AsIndexable());

		[TestMethod]
		public void GetQ1()
		{
			Assert.AreEqual(7, _merged[1, 1]);
		}

		[TestMethod]
		public void GetQ2()
		{
			Assert.AreEqual(10, _merged[1, 4]);
		}

		[TestMethod]
		public void GetQ3()
		{
			Assert.AreEqual(20, _merged[3, 4]);
		}

		[TestMethod]
		public void GetQ4()
		{
			Assert.AreEqual(13, _merged[2, 2]);
		}

		[TestMethod]
		public void Length0()
		{
			Assert.AreEqual(4, _merged.Length0);
		}

		[TestMethod]
		public void Length1()
		{
			Assert.AreEqual(5, _merged.Length1);
		}
	}
}
