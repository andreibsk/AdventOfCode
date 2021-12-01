namespace AdventOfCode.Common.Extensions;

public static class VectorExtensions
{
	public static int BlockDistanceTo(this IVector2 u, IVector2 v)
	{
		return Math.Abs(u.X - v.X) + Math.Abs(u.Y - v.Y);
	}

	public static int BlockDistanceTo(this IVector3 u, IVector3 v)
	{
		return Math.Abs(u.X - v.X) + Math.Abs(u.Y - v.Y) + Math.Abs(u.Z - v.Z);
	}

	public static double DistanceTo(this IVector2 u, IVector2 v)
	{
		return Math.Sqrt(Math.Pow(u.X - v.X, 2) + Math.Pow(u.Y - v.Y, 2));
	}
}
