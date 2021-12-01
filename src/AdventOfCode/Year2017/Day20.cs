using System.Text.RegularExpressions;

namespace AdventOfCode.Year2017;

public class Day20 : Puzzle
{
	private const int SimulationTicksCount = 100;
	private readonly Particle[] _particles;

	public Day20(string[] input) : base(input)
	{
		_particles = input.Select((s, i) => Particle.Parse(i, s)).ToArray();
	}

	public override DateTime Date => new DateTime(2017, 12, 20);
	public override string Title => "Particle Swarm";

	public override string? CalculateSolution()
	{
		return Solution = _particles
			.OrderBy(p => p.Acceleration.BlockDistanceTo(Vector3.Zero))
			.First()
			.Id.ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		var remainingParticles = new LinkedList<Particle>(_particles);

		for (int i = 0; i < SimulationTicksCount; i++)
		{
			foreach (Particle o in remainingParticles)
				o.SimulateTick();

			LinkedListNode<Particle>? p = remainingParticles.First!;
			while (p != null)
			{
				bool remove = false;
				LinkedListNode<Particle> r;
				LinkedListNode<Particle>? o = p.Next;
				while (o != null)
				{
					if (o.Value.Position == p.Value.Position)
					{
						r = o;
						o = o.Next;
						remainingParticles.Remove(r);
						remove = true;
					}
					else
						o = o.Next;
				}

				if (remove)
				{
					r = p;
					p = p.Next;
					remainingParticles.Remove(r);
				}
				else
					p = p.Next;
			}
		}

		return SolutionPartTwo = remainingParticles.Count.ToString();
	}

	private class Particle
	{
		private static readonly Regex s_regex = new Regex(
			@"^p=<(?<px>-?\d+),(?<py>-?\d+),(?<pz>-?\d+)>, v=<(?<vx>-?\d+),(?<vy>-?\d+),(?<vz>-?\d+)>, a=<(?<ax>-?\d+),(?<ay>-?\d+),(?<az>-?\d+)>$");

		public Particle(int id, Position3 position, Vector3 velocity, Vector3 acceleration)
		{
			Id = id;
			Position = position;
			Velocity = velocity;
			Acceleration = acceleration;
		}

		public Vector3 Acceleration { get; set; }
		public int Id { get; }
		public Position3 Position { get; set; }
		public Vector3 Velocity { get; set; }

		public static Particle Parse(int id, string str)
		{
			Match match = s_regex.Match(str);
			if (!match.Success)
				throw new FormatException();

			return new Particle(
				id,
				new Position3(int.Parse(match.Groups["px"].Value), int.Parse(match.Groups["py"].Value), int.Parse(match.Groups["pz"].Value)),
				new Vector3(int.Parse(match.Groups["vx"].Value), int.Parse(match.Groups["vy"].Value), int.Parse(match.Groups["vz"].Value)),
				new Vector3(int.Parse(match.Groups["ax"].Value), int.Parse(match.Groups["ay"].Value), int.Parse(match.Groups["az"].Value)));
		}

		public void SimulateTick()
		{
			Velocity += Acceleration;
			Position += Velocity;
		}
	}
}
