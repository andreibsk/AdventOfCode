using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Year2019;

public class Day12 : Puzzle
{
	private readonly Moon[] _moons;

	public Day12(string[] input) : base(input)
	{
		_moons = input.Select(s => Moon.Parse(s)).ToArray();
	}

	public override DateTime Date => new DateTime(2019, 12, 12);
	public override string Title => "The N-Body Problem";

	public override string? CalculateSolution()
	{
		Moon[] moons = _moons.Select(m => new Moon(m)).ToArray();

		for (int steps = 1000; steps > 0; steps--)
		{
			for (int i = 0; i < moons.Length - 1; i++)
			{
				Moon m = moons[i];
				for (int j = i + 1; j < moons.Length; j++)
				{
					Moon n = moons[j];
					m.Velocity = new Vector3(
						m.Velocity.X + (m.Position.X < n.Position.X ? +1 : m.Position.X > n.Position.X ? -1 : 0),
						m.Velocity.Y + (m.Position.Y < n.Position.Y ? +1 : m.Position.Y > n.Position.Y ? -1 : 0),
						m.Velocity.Z + (m.Position.Z < n.Position.Z ? +1 : m.Position.Z > n.Position.Z ? -1 : 0)
						);
					n.Velocity = new Vector3(
						n.Velocity.X + (n.Position.X < m.Position.X ? +1 : n.Position.X > m.Position.X ? -1 : 0),
						n.Velocity.Y + (n.Position.Y < m.Position.Y ? +1 : n.Position.Y > m.Position.Y ? -1 : 0),
						n.Velocity.Z + (n.Position.Z < m.Position.Z ? +1 : n.Position.Z > m.Position.Z ? -1 : 0)
						);
				}
			}

			foreach (Moon m in moons)
				m.Position += m.Velocity;
		}

		int totalEnergy = 0;
		foreach (Moon m in moons)
			totalEnergy += m.Position.BlockDistanceTo(Position3.Zero) * m.Velocity.BlockDistanceTo(Position3.Zero);

		return Solution = totalEnergy.ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		int stepsx = MinStepsForRepeat(_moons, v => v.X);
		int stepsy = MinStepsForRepeat(_moons, v => v.Y);
		int stepsz = MinStepsForRepeat(_moons, v => v.Z);

		return SolutionPartTwo = stepsx.Lcm(stepsy).Lcm(stepsz).ToString();
	}

	private static int MinStepsForRepeat(Moon[] moons, Func<IVector3, int> selectAxis)
	{
		int[] initialPosOnAxis = moons.Select(m => selectAxis(m.Position)).ToArray();
		int[] initialVelOnAxis = moons.Select(m => selectAxis(m.Velocity)).ToArray();

		int[] moonPosOnAxis = initialPosOnAxis.ToArray();
		int[] moonVelOnAxis = initialVelOnAxis.ToArray();

		for (int steps = 1; ; steps++)
		{
			for (int i = 0; i < moons.Length - 1; i++)
			{
				for (int j = i + 1; j < moons.Length; j++)
				{
					moonVelOnAxis[i] += moonPosOnAxis[i] < moonPosOnAxis[j] ? +1 : moonPosOnAxis[i] > moonPosOnAxis[j] ? -1 : 0;
					moonVelOnAxis[j] += moonPosOnAxis[j] < moonPosOnAxis[i] ? +1 : moonPosOnAxis[j] > moonPosOnAxis[i] ? -1 : 0;
				}
			}

			for (int i = 0; i < moons.Length; i++)
				moonPosOnAxis[i] += moonVelOnAxis[i];

			// Check
			if (initialPosOnAxis.SequenceEqual(moonPosOnAxis) && initialVelOnAxis.SequenceEqual(moonVelOnAxis))
				return steps;
		}
	}

	private class Moon
	{
		private static readonly Regex s_regex = new Regex(@"^<x=(?<x>-?\d+), y=(?<y>-?\d+), z=(?<z>-?\d+)>$");

		public Moon(Moon moon) : this(moon.Position, moon.Velocity)
		{
		}

		public Moon(Position3 position, Vector3 velocity)
		{
			Position = position;
			Velocity = velocity;
		}

		public Position3 Position { get; set; }
		public Vector3 Velocity { get; set; }

		public static Moon Parse(string str)
		{
			Match match = s_regex.Match(str);
			if (!match.Success)
				throw new FormatException();

			return new Moon(
				new Position3(
					int.Parse(match.Groups["x"].Value),
					int.Parse(match.Groups["y"].Value),
					int.Parse(match.Groups["z"].Value)),
				Vector3.Zero);
		}
	}
}
