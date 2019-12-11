using System;
using System.Collections.Generic;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Common
{
	public struct Direction : IVector2, IComparable<Direction>
	{
		public static readonly Direction None = new Direction(0, 0);
		private static Mode s_mode;

		public Direction(int dx, int dy)
		{
			if (dx != 0 && dy != 0)
			{
				int gcd = dx.Gcd(dy);
				X = dx / gcd;
				Y = dy / gcd;
			}
			else
			{
				X = Math.Sign(dx);
				Y = Math.Sign(dy);
			}
		}

		public enum Mode
		{
			Screen,
			Array
		}

		public static IEnumerable<Direction> All => new[] { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest };
		public static Direction East => s_mode == Mode.Screen ? new Direction(1, 0) : new Direction(0, 1);
		public static IEnumerable<Direction> NESW => new[] { North, East, South, West };
		public static Direction North => s_mode == Mode.Screen ? new Direction(0, -1) : new Direction(-1, 0);
		public static Direction NorthEast => s_mode == Mode.Screen ? new Direction(1, -1) : new Direction(-1, 1);
		public static Direction NorthWest => s_mode == Mode.Screen ? new Direction(-1, -1) : new Direction(-1, -1);
		public static Direction South => s_mode == Mode.Screen ? new Direction(0, 1) : new Direction(1, 0);
		public static Direction SouthEast => s_mode == Mode.Screen ? new Direction(1, 1) : new Direction(1, 1);
		public static Direction SouthWest => s_mode == Mode.Screen ? new Direction(-1, 1) : new Direction(1, -1);
		public static Direction West => s_mode == Mode.Screen ? new Direction(-1, 0) : new Direction(0, -1);

		public float Angle => ((s_mode == Mode.Screen ? MathF.Atan2(Y, X) : MathF.Atan2(X, Y)) * 180 / MathF.PI + 360) % 360;
		public int X { get; }
		public int Y { get; }

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

		public int CompareTo(Direction other) => Math.Sign(Angle - other.Angle);

		public override bool Equals(object? obj)
		{
			if (!(obj is Direction d))
				return false;
			return d.X == X && d.Y == Y;
		}

		public override int GetHashCode() => X.CombineHashCode(Y);

		public Direction ToLeft() => s_mode == Mode.Screen ? new Direction(Y, -X) : new Direction(-Y, X);

		public Direction ToReverse() => new Direction(-X, -Y);

		public Direction ToRight() => s_mode == Mode.Screen ? new Direction(-Y, X) : new Direction(Y, -X);

		public Direction ToSlightLeft() => s_mode == Mode.Screen ? new Direction(X + Y, Y - X) : new Direction(X - Y, Y + X);

		public Direction ToSlightRight() => s_mode == Mode.Screen ? new Direction(X - Y, Y + X) : new Direction(X + Y, Y - X);

		public override string ToString()
		{
			string s = $"ΔX={X}, ΔY={Y}, {Angle}°, ";

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
