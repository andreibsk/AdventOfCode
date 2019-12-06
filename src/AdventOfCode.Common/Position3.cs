using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Common
{
	public struct Position3 : IVector3
	{
		public static readonly Position3 Zero = new Position3(0, 0, 0);

		public Position3(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public int X { get; }
		public int Y { get; }
		public int Z { get; }

		public static explicit operator (int X, int Y, int Z)(Position3 p) => (p.X, p.Y, p.Z);

		public static implicit operator Position3((int x, int y, int z) p) => new Position3(p.x, p.y, p.z);

		public static Position3 operator -(Position3 p, IVector3 v) => new Position3(p.X - v.X, p.Y - v.Y, p.Z - v.Z);

		public static bool operator !=(Position3 l, Position3 r) => !(l == r);

		public static Position3 operator +(Position3 p, IVector3 v) => new Position3(p.X + v.X, p.Y + v.Y, p.Z + v.Z);

		public static bool operator ==(Position3 l, Position3 r) => l.X == r.X && l.Y == r.Y && l.Z == r.Z;

		public override bool Equals(object? obj)
		{
			if (!(obj is Position3 p))
				return false;
			return p.X == X && p.Y == Y && p.Z == Z;
		}

		public override int GetHashCode() => X.CombineHashCode(Y).CombineHashCode(Z);

		public Position3 OffsetBy(int dx, int dy, int dz) => new Position3(X + dx, Y + dy, Z + dz);

		public Position3 OffsetBy(IVector3 v) => OffsetBy(v.X, v.Y, v.Z);

		public Position3 OffsetBy(IVector3 v, int multiplier) => OffsetBy(v.X * multiplier, v.Y * multiplier, v.Z * multiplier);

		public override string? ToString() => $"X={X}, Y={Y}, Z={Z}";
	}
}
