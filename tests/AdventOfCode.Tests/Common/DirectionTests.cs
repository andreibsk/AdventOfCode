using AdventOfCode.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Common
{
	[TestClass]
	public class DirectionTests
	{
		[TestMethod]
		public void ToLeft()
		{
			Assert.AreEqual(Direction.West, Direction.North.ToLeft());
			Assert.AreEqual(Direction.North, Direction.East.ToLeft());
			Assert.AreEqual(Direction.East, Direction.South.ToLeft());
			Assert.AreEqual(Direction.South, Direction.West.ToLeft());

			Assert.AreEqual(Direction.NorthWest, Direction.NorthEast.ToLeft());
			Assert.AreEqual(Direction.NorthEast, Direction.SouthEast.ToLeft());
			Assert.AreEqual(Direction.SouthEast, Direction.SouthWest.ToLeft());
			Assert.AreEqual(Direction.SouthWest, Direction.NorthWest.ToLeft());
		}

		[TestMethod]
		public void ToRight()
		{
			Assert.AreEqual(Direction.East, Direction.North.ToRight());
			Assert.AreEqual(Direction.South, Direction.East.ToRight());
			Assert.AreEqual(Direction.West, Direction.South.ToRight());
			Assert.AreEqual(Direction.North, Direction.West.ToRight());

			Assert.AreEqual(Direction.SouthEast, Direction.NorthEast.ToRight());
			Assert.AreEqual(Direction.SouthWest, Direction.SouthEast.ToRight());
			Assert.AreEqual(Direction.NorthWest, Direction.SouthWest.ToRight());
			Assert.AreEqual(Direction.NorthEast, Direction.NorthWest.ToRight());
		}

		[TestMethod]
		public void ToSlightLeft()
		{
			Assert.AreEqual(Direction.NorthWest, Direction.North.ToSlightLeft());
			Assert.AreEqual(Direction.North, Direction.NorthEast.ToSlightLeft());
			Assert.AreEqual(Direction.NorthEast, Direction.East.ToSlightLeft());
			Assert.AreEqual(Direction.East, Direction.SouthEast.ToSlightLeft());
			Assert.AreEqual(Direction.SouthEast, Direction.South.ToSlightLeft());
			Assert.AreEqual(Direction.South, Direction.SouthWest.ToSlightLeft());
			Assert.AreEqual(Direction.SouthWest, Direction.West.ToSlightLeft());
			Assert.AreEqual(Direction.West, Direction.NorthWest.ToSlightLeft());
		}

		[TestMethod]
		public void ToSlightRight()
		{
			Assert.AreEqual(Direction.NorthEast, Direction.North.ToSlightRight());
			Assert.AreEqual(Direction.East, Direction.NorthEast.ToSlightRight());
			Assert.AreEqual(Direction.SouthEast, Direction.East.ToSlightRight());
			Assert.AreEqual(Direction.South, Direction.SouthEast.ToSlightRight());
			Assert.AreEqual(Direction.SouthWest, Direction.South.ToSlightRight());
			Assert.AreEqual(Direction.West, Direction.SouthWest.ToSlightRight());
			Assert.AreEqual(Direction.NorthWest, Direction.West.ToSlightRight());
			Assert.AreEqual(Direction.North, Direction.NorthWest.ToSlightRight());
		}
	}
}
