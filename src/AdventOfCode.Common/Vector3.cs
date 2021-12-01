namespace AdventOfCode.Common;

public struct Vector3 : IVector3
{
	public static readonly Vector3 Zero = new Vector3(0, 0, 0);

	public Vector3(int x, int y, int z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public int X { get; }

	public int Y { get; }

	public int Z { get; }

	public static Vector3 operator -(Vector3 l, IVector3 r) => new Vector3(l.X - r.X, l.Y - r.Y, l.Z - r.Z);

	public static bool operator !=(Vector3 l, Vector3 r) => !(l == r);

	public static Vector3 operator +(Vector3 l, IVector3 r) => new Vector3(l.X + r.X, l.Y + r.Y, l.Z + r.Z);

	public static bool operator ==(Vector3 l, Vector3 r) => l.X == r.X && l.Y == r.Y && l.Z == r.Z;

	public override bool Equals(object? obj)
	{
		if (!(obj is Vector3 v))
			return false;
		return v.X == X && v.Y == Y && v.Z == Z;
	}

	public override int GetHashCode() => X.CombineHashCode(Y).CombineHashCode(Z);

	public override string? ToString() => $"X={X}, Y={Y}, Z={Z}";
}
