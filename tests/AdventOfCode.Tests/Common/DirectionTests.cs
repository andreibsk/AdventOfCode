using AdventOfCode.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Common
{
	[TestClass]
	[DoNotParallelize]
	public class DirectionTests
	{
		[TestMethod]
		public void ArrayModeToLeft()
		{
			Direction.SetMode(Direction.Mode.Array);

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
		public void ArrayModeToReverse()
		{
			Direction.SetMode(Direction.Mode.Array);

			Assert.AreEqual(Direction.South, Direction.North.ToReverse());
			Assert.AreEqual(Direction.West, Direction.East.ToReverse());
			Assert.AreEqual(Direction.North, Direction.South.ToReverse());
			Assert.AreEqual(Direction.East, Direction.West.ToReverse());

			Assert.AreEqual(Direction.SouthWest, Direction.NorthEast.ToReverse());
			Assert.AreEqual(Direction.NorthWest, Direction.SouthEast.ToReverse());
			Assert.AreEqual(Direction.NorthEast, Direction.SouthWest.ToReverse());
			Assert.AreEqual(Direction.SouthEast, Direction.NorthWest.ToReverse());
		}

		[TestMethod]
		public void ArrayModeToRight()
		{
			Direction.SetMode(Direction.Mode.Array);

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
		public void ArrayModeToSlightLeft()
		{
			Direction.SetMode(Direction.Mode.Array);

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
		public void ArrayModeToSlightRight()
		{
			Direction.SetMode(Direction.Mode.Array);

			Assert.AreEqual(Direction.NorthEast, Direction.North.ToSlightRight());
			Assert.AreEqual(Direction.East, Direction.NorthEast.ToSlightRight());
			Assert.AreEqual(Direction.SouthEast, Direction.East.ToSlightRight());
			Assert.AreEqual(Direction.South, Direction.SouthEast.ToSlightRight());
			Assert.AreEqual(Direction.SouthWest, Direction.South.ToSlightRight());
			Assert.AreEqual(Direction.West, Direction.SouthWest.ToSlightRight());
			Assert.AreEqual(Direction.NorthWest, Direction.West.ToSlightRight());
			Assert.AreEqual(Direction.North, Direction.NorthWest.ToSlightRight());
		}

		[TestMethod]
		public void ScreenModeToLeft()
		{
			Direction.SetMode(Direction.Mode.Screen);

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
		public void ScreenModeToReverse()
		{
			Direction.SetMode(Direction.Mode.Screen);

			Assert.AreEqual(Direction.South, Direction.North.ToReverse());
			Assert.AreEqual(Direction.West, Direction.East.ToReverse());
			Assert.AreEqual(Direction.North, Direction.South.ToReverse());
			Assert.AreEqual(Direction.East, Direction.West.ToReverse());

			Assert.AreEqual(Direction.SouthWest, Direction.NorthEast.ToReverse());
			Assert.AreEqual(Direction.NorthWest, Direction.SouthEast.ToReverse());
			Assert.AreEqual(Direction.NorthEast, Direction.SouthWest.ToReverse());
			Assert.AreEqual(Direction.SouthEast, Direction.NorthWest.ToReverse());
		}

		[TestMethod]
		public void ScreenModeToRight()
		{
			Direction.SetMode(Direction.Mode.Screen);

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
		public void ScreenModeToSlightLeft()
		{
			Direction.SetMode(Direction.Mode.Screen);

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
		public void ScreenModeToSlightRight()
		{
			Direction.SetMode(Direction.Mode.Screen);

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
