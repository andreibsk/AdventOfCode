namespace AdventOfCode.Common
{
	public interface IVector3<T> where T : struct
	{
		public T X { get; }
		public T Y { get; }
		public T Z { get; }

		public string? ToString() => $"X={X}, Y={Y}, Z={Z}";
	}

	public interface IVector3 : IVector3<int>
	{
	}
}
