using System;

namespace AdventOfCode
{
	public struct Position
	{
		public static readonly Position Zero = new Position(0, 0);

		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; set; }
		public int Y { get; set; }

		public static explicit operator (int X, int Y)(Position p) => (p.X, p.Y);

		public static implicit operator Position((int x, int y) p) => new Position(p.x, p.y);

		public static Position operator -(Position p1, Position p2) => new Position(p1.X - p2.X, p1.Y - p2.Y);

		public static Position operator -(Position p, Direction d) => new Position(p.X - d.DeltaX, p.Y - d.DeltaY);

		public static bool operator !=(Position l, Position r) => !(l == r);

		public static Position operator +(Position p1, Position p2) => new Position(p1.X + p2.X, p1.Y + p2.Y);

		public static Position operator +(Position p, Direction d) => new Position(p.X + d.DeltaX, p.Y + d.DeltaY);

		public static bool operator ==(Position l, Position r) => l.X == r.X && l.Y == r.Y;

		public int BlockDistanceTo(Position p) => Math.Abs(X - p.X) + Math.Abs(Y - p.Y);

		public override bool Equals(object? obj)
		{
			if (!(obj is Position p))
				return false;
			return p.X == X && p.Y == Y;
		}

		public override int GetHashCode() => unchecked(X ^ Y);

		public void Offset(int dx, int dy)
		{
			X += dx;
			Y += dy;
		}

		public void Offset(Position p) => Offset(p.X, p.Y);

		public void Offset(Direction d, int distance) => Offset(d.DeltaX * distance, d.DeltaY * distance);

		public override string ToString() => $"X={X}, Y={Y}";
	}
}
