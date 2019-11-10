using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AdventOfCode.Common
{
	public struct Direction
	{
		public static readonly Direction None = new Direction(0, 0);
		private static Mode s_mode;

		private readonly int _deltaX;
		private readonly int _deltaY;

		static Direction()
		{
			All = (new[] { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest }).ToImmutableArray();
			NESW = (new[] { North, East, South, West }).ToImmutableArray();
		}

		private Direction(int dx, int dy)
		{
			_deltaX = Math.Max(-1, Math.Min(dx, 1));
			_deltaY = Math.Max(-1, Math.Min(dy, 1));
		}

		public enum Mode
		{
			Screen,
			Array
		}

		public static IEnumerable<Direction> All { get; }

		public static Direction East { get; } = new Direction(1, 0);
		public static IEnumerable<Direction> NESW { get; }
		public static Direction North { get; } = new Direction(0, -1);
		public static Direction NorthEast { get; } = new Direction(1, -1);
		public static Direction NorthWest { get; } = new Direction(-1, -1);
		public static Direction South { get; } = new Direction(0, 1);
		public static Direction SouthEast { get; } = new Direction(1, 1);
		public static Direction SouthWest { get; } = new Direction(-1, 1);
		public static Direction West { get; } = new Direction(-1, 0);

		public int DeltaX => s_mode == Mode.Screen ? _deltaX : _deltaY;
		public int DeltaY => s_mode == Mode.Screen ? _deltaY : _deltaX;

		public static bool operator !=(Direction l, Direction r) => !(l == r);

		public static Position operator *(Direction d, int distance) => (d.DeltaX * distance, d.DeltaY * distance);

		public static bool operator ==(Direction l, Direction r) => l.DeltaX == r.DeltaX && l.DeltaY == r.DeltaY;

		public static Direction Parse(char c)
		{
			switch (char.ToUpper(c))
			{
				case 'U':
				case 'N': return North;

				case 'D':
				case 'S': return South;

				case 'L':
				case 'W': return West;

				case 'R':
				case 'E': return East;

				default: throw new FormatException($"Can't parse the char '{c}' to {nameof(Direction)}.");
			}
		}

		public static void SetMode(Mode mode) => s_mode = mode;

		public override bool Equals(object? obj)
		{
			if (!(obj is Direction d))
				return false;
			return d.DeltaX == DeltaX && d.DeltaY == DeltaY;
		}

		public override int GetHashCode() => 3 * _deltaX + _deltaY;

		public Direction ToLeft() => new Direction(_deltaY, -_deltaX);

		public Direction ToRight() => new Direction(-_deltaY, _deltaX);

		public Direction ToSlightLeft() => new Direction(_deltaX + _deltaY, _deltaY - _deltaX);

		public Direction ToSlightRight() => new Direction(_deltaX - _deltaY, _deltaY + _deltaX);

		public override string ToString()
		{
			string s = $"ΔX={DeltaX}, ΔY={DeltaY}, ";

			if (Equals(East)) return s + nameof(East);
			else if (Equals(North)) return s + nameof(North);
			else if (Equals(South)) return s + nameof(South);
			else if (Equals(West)) return s + nameof(West);
			else if (Equals(NorthEast)) return s + nameof(NorthEast);
			else if (Equals(NorthWest)) return s + nameof(NorthWest);
			else if (Equals(SouthEast)) return s + nameof(SouthEast);
			else if (Equals(SouthWest)) return s + nameof(SouthWest);
			else return s + nameof(None);
		}
	}
}
