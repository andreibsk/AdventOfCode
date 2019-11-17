using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Common
{
	public struct Vector2 : IVector2
	{
		public static readonly Vector2 Zero = new Vector2(0, 0);

		public Vector2(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }
		public int Y { get; }

		public static bool operator !=(Vector2 l, Vector2 r) => !(l == r);

		public static bool operator ==(Vector2 l, Vector2 r) => l.X == r.X && l.Y == r.Y;

		public override bool Equals(object? obj)
		{
			if (!(obj is Vector2 v))
				return false;
			return v.X == X && v.Y == Y;
		}

		public override int GetHashCode() => X.CombineHashCode(Y);

		public override string? ToString() => $"X={X}, Y={Y}";
	}
}
