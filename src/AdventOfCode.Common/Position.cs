using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Common;

public struct Position : IVector2
{
	public static readonly Position Zero = new Position(0, 0);

	public Position(int x, int y)
	{
		X = x;
		Y = y;
	}

	public int X { get; }
	public int Y { get; }

	public static explicit operator (int X, int Y)(Position p) => (p.X, p.Y);

	public static implicit operator Position((int x, int y) p) => new Position(p.x, p.y);

	public static Position operator -(Position p, IVector2 v) => new Position(p.X - v.X, p.Y - v.Y);

	public static bool operator !=(Position l, Position r) => !(l == r);

	public static Position operator +(Position p, IVector2 v) => new Position(p.X + v.X, p.Y + v.Y);

	public static bool operator ==(Position l, Position r) => l.X == r.X && l.Y == r.Y;

	public override bool Equals(object? obj)
	{
		if (!(obj is Position p))
			return false;
		return p.X == X && p.Y == Y;
	}

	public override int GetHashCode() => X.CombineHashCode(Y);

	public Position OffsetBy(int dx, int dy) => new Position(X + dx, Y + dy);

	public Position OffsetBy(IVector2 v) => OffsetBy(v.X, v.Y);

	public Position OffsetBy(IVector2 v, int multiplier) => OffsetBy(v.X * multiplier, v.Y * multiplier);

	public override string? ToString() => $"X={X}, Y={Y}";
}
