namespace AdventOfCode.Common;

public interface IVector2<T> where T : struct
{
	public T X { get; }
	public T Y { get; }

	public string? ToString() => $"X={X}, Y={Y}";
}

public interface IVector2 : IVector2<int>
{
}
