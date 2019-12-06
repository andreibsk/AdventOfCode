using System;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Common
{
	public struct Direction3D
	{
		public static readonly Direction3D None = new Direction3D(0, 0, 0);

		private Direction3D(int dx, int dy, int dz)
		{
			DeltaX = Math.Max(-1, Math.Min(dx, 1));
			DeltaY = Math.Max(-1, Math.Min(dy, 1));
			DeltaZ = Math.Max(-1, Math.Min(dz, 1));
		}

		public int DeltaX { get; }
		public int DeltaY { get; }
		public int DeltaZ { get; }

		public static bool operator !=(Direction3D l, Direction3D r) => !(l == r);

		public static Position operator *(Direction3D d, int distance) => (d.DeltaX * distance, d.DeltaY * distance);

		public static bool operator ==(Direction3D l, Direction3D r) => l.DeltaX == r.DeltaX && l.DeltaY == r.DeltaY;

		public override bool Equals(object? obj)
		{
			if (!(obj is Direction3D d))
				return false;
			return d.DeltaX == DeltaX && d.DeltaY == DeltaY && d.DeltaZ == DeltaZ;
		}

		public override int GetHashCode() => DeltaX.CombineHashCode(DeltaY).CombineHashCode(DeltaZ);

		public override string ToString() => $"ΔX={DeltaX}, ΔY={DeltaY}, ΔZ={DeltaZ}";
	}
}
