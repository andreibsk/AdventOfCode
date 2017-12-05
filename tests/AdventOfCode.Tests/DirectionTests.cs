using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests
{
    public class DirectionTests
    {
		[Fact]
		public void ToRight()
		{
			Assert.Equal(Direction.East, Direction.North.ToRight());
			Assert.Equal(Direction.South, Direction.East.ToRight());
			Assert.Equal(Direction.West, Direction.South.ToRight());
			Assert.Equal(Direction.North, Direction.West.ToRight());

			Assert.Equal(Direction.SouthEast, Direction.NorthEast.ToRight());
			Assert.Equal(Direction.SouthWest, Direction.SouthEast.ToRight());
			Assert.Equal(Direction.NorthWest, Direction.SouthWest.ToRight());
			Assert.Equal(Direction.NorthEast, Direction.NorthWest.ToRight());
		}

		[Fact]
		public void ToLeft()
		{
			Assert.Equal(Direction.West, Direction.North.ToLeft());
			Assert.Equal(Direction.North, Direction.East.ToLeft());
			Assert.Equal(Direction.East, Direction.South.ToLeft());
			Assert.Equal(Direction.South, Direction.West.ToLeft());

			Assert.Equal(Direction.NorthWest, Direction.NorthEast.ToLeft());
			Assert.Equal(Direction.NorthEast, Direction.SouthEast.ToLeft());
			Assert.Equal(Direction.SouthEast, Direction.SouthWest.ToLeft());
			Assert.Equal(Direction.SouthWest, Direction.NorthWest.ToLeft());
		}

		[Fact]
		public void ToSlightRight()
		{
			Assert.Equal(Direction.NorthEast, Direction.North.ToSlightRight());
			Assert.Equal(Direction.East, Direction.NorthEast.ToSlightRight());
			Assert.Equal(Direction.SouthEast, Direction.East.ToSlightRight());
			Assert.Equal(Direction.South, Direction.SouthEast.ToSlightRight());
			Assert.Equal(Direction.SouthWest, Direction.South.ToSlightRight());
			Assert.Equal(Direction.West, Direction.SouthWest.ToSlightRight());
			Assert.Equal(Direction.NorthWest, Direction.West.ToSlightRight());
			Assert.Equal(Direction.North, Direction.NorthWest.ToSlightRight());
		}

		[Fact]
		public void ToSlightLeft()
		{
			Assert.Equal(Direction.NorthWest, Direction.North.ToSlightLeft());
			Assert.Equal(Direction.North, Direction.NorthEast.ToSlightLeft());
			Assert.Equal(Direction.NorthEast, Direction.East.ToSlightLeft());
			Assert.Equal(Direction.East, Direction.SouthEast.ToSlightLeft());
			Assert.Equal(Direction.SouthEast, Direction.South.ToSlightLeft());
			Assert.Equal(Direction.South, Direction.SouthWest.ToSlightLeft());
			Assert.Equal(Direction.SouthWest, Direction.West.ToSlightLeft());
			Assert.Equal(Direction.West, Direction.NorthWest.ToSlightLeft());
		}
	}
}
