using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Common
{
	public struct Direction : IVector2
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

		public int X => s_mode == Mode.Screen ? _deltaX : _deltaY;
		public int Y => s_mode == Mode.Screen ? _deltaY : _deltaX;

		public static bool operator !=(Direction l, Direction r) => !(l == r);

		public static IVector2 operator *(Direction d, int distance) => new Vector2(d.X * distance, d.Y * distance);

		public static bool operator ==(Direction l, Direction r) => l.X == r.X && l.Y == r.Y;

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
			return d.X == X && d.Y == Y;
		}

		public override int GetHashCode() => _deltaX.CombineHashCode(_deltaY);

		public Direction ToLeft() => new Direction(_deltaY, -_deltaX);

		public Direction ToRight() => new Direction(-_deltaY, _deltaX);

		public Direction ToSlightLeft() => new Direction(_deltaX + _deltaY, _deltaY - _deltaX);

		public Direction ToSlightRight() => new Direction(_deltaX - _deltaY, _deltaY + _deltaX);

		public override string ToString()
		{
			string s = $"ΔX={X}, ΔY={Y}, ";

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
