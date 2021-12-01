using System;
using System.Linq;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2017;

public class Day24 : Puzzle
{
	private readonly (int P0, int P1)[] _components;
	private readonly bool[] _usedComponents;

	public Day24(string[] input) : base(input)
	{
		_components = input.Select(s => s.Split('/').Select(int.Parse).ToValueTuple<int, int>()).ToArray();
		_usedComponents = new bool[_components.Length];
	}

	public override DateTime Date => new DateTime(2017, 12, 24);
	public override string Title => "Electromagnetic Moat";

	public override string? CalculateSolution()
	{
		Array.Fill(_usedComponents, false);
		return Solution = MaxBridgeStrength(previousPort: 0).ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		Array.Fill(_usedComponents, false);
		return SolutionPartTwo = MaxStrengthOfLongestBridge(previousPort: 0).ToString();
	}

	private int GetCurrentStrength()
	{
		int strength = 0;
		for (int i = _components.Length - 1; i >= 0; i--)
			if (_usedComponents[i])
				strength += _components[i].P0 + _components[i].P1;
		return strength;
	}

	private int MaxBridgeStrength(int previousPort)
	{
		int maxStrength = int.MinValue;
		for (int i = 0; i < _usedComponents.Length; i++)
		{
			if (_usedComponents[i])
				continue;

			if (_components[i].P0 == previousPort)
			{
				// P0 connected to previous component
				_usedComponents[i] = true;
				maxStrength = Math.Max(maxStrength, MaxBridgeStrength(_components[i].P1));
				_usedComponents[i] = false;
			}

			if (_components[i].P1 == previousPort)
			{
				// P1 connected to previous component
				_usedComponents[i] = true;
				maxStrength = Math.Max(maxStrength, MaxBridgeStrength(_components[i].P0));
				_usedComponents[i] = false;
			}
		}

		return maxStrength != int.MinValue ? maxStrength : GetCurrentStrength();
	}

	private int MaxStrengthOfLongestBridge(int previousPort)
	{
		int maxLength = int.MinValue;
		return MaxStrengthOfLongestBridge(previousPort, length: 0, ref maxLength);
	}

	private int MaxStrengthOfLongestBridge(int previousPort, int length, ref int maxLength)
	{
		maxLength = Math.Max(maxLength, length);

		int maxStrength = int.MinValue;
		for (int i = 0; i < _usedComponents.Length; i++)
		{
			if (_usedComponents[i])
				continue;

			if (_components[i].P0 == previousPort)
			{
				// P0 connected to previous component
				_usedComponents[i] = true;
				maxStrength = Math.Max(maxStrength, MaxStrengthOfLongestBridge(_components[i].P1, length + 1, ref maxLength));
				_usedComponents[i] = false;
			}

			if (_components[i].P1 == previousPort)
			{
				// P1 connected to previous component
				_usedComponents[i] = true;
				maxStrength = Math.Max(maxStrength, MaxStrengthOfLongestBridge(_components[i].P0, length + 1, ref maxLength));
				_usedComponents[i] = false;
			}
		}

		return length >= maxLength ? Math.Max(maxStrength, GetCurrentStrength()) : maxStrength;
	}
}
