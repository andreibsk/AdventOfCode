using Instruction = System.Action<AdventOfCode.Year2017.Day18.Cpu>;

namespace AdventOfCode.Year2017;

public class Day18 : Puzzle
{
	private readonly Instruction[] _instructions;

	public Day18(string[] input) : base(input)
	{
		_instructions = input
			.Select<string, Instruction>(instructionString =>
			{
				instructionString.Split(' ')
					.DeconstructValuesOrDefault(out string? inst, out string? xs, out string? ys);

				long? x = xs.ToLongOrDefault(), y = ys?.ToLongOrDefault();
				char xr = xs![0];
				char? yr = ys?[0];

				return inst switch
				{
					"snd" => cpu => Cpu.Instructions.Snd(cpu, x, xr),
					"set" => cpu => Cpu.Instructions.Set(cpu, xr, y, yr.Value),
					"add" => cpu => Cpu.Instructions.Add(cpu, xr, y, yr.Value),
					"mul" => cpu => Cpu.Instructions.Mul(cpu, xr, y, yr.Value),
					"mod" => cpu => Cpu.Instructions.Mod(cpu, xr, y, yr.Value),
					"rcv" => cpu => Cpu.Instructions.Rcv(cpu, x, xr),
					"jgz" => cpu => Cpu.Instructions.Jgz(cpu, x, xr, y, yr.Value),

					_ => throw new FormatException()
				};
			})
			.ToArray();
	}

	public override DateTime Date => new DateTime(2017, 12, 18);
	public override string Title => "Duet";

	public override string? CalculateSolution()
	{
		var cpu = new Cpu();
		cpu.Load(_instructions);
		cpu.Execute(c => !c.RecoveredFrequency.HasValue);

		return Solution = cpu.RecoveredFrequency.ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		var cpu0 = new Cpu(id: 0);
		var cpu1 = new Cpu(id: 1);
		cpu0.Load(_instructions);
		cpu1.Load(_instructions);
		cpu0.Connect(cpu1.IncomingMessages!);
		cpu1.Connect(cpu0.IncomingMessages!);

		while (!(cpu0.Waiting && cpu1.Waiting))
		{
			cpu0.Execute(c => !c.Waiting);
			cpu1.Execute(c => !c.Waiting);
		}

		return SolutionPartTwo = cpu1.SentCount.ToString();
	}

	internal class Cpu
	{
		private readonly long[] _registers = new long['z' - 'a' + 1];
		private long _freq;
		private long _pc;
		private Instruction[] _program = Array.Empty<Instruction>();
		private bool _waited = false;

		public Cpu()
		{
			NetworkAware = false;
		}

		public Cpu(int id)
		{
			this['p'] = id;
			NetworkAware = true;
			IncomingMessages = new Queue<long>();
		}

		public Queue<long>? IncomingMessages { get; }
		public bool NetworkAware { get; }
		public Queue<long>? OutgoingMessages { get; private set; }
		public long? RecoveredFrequency { get; private set; } = null;
		public int SentCount { get; private set; } = 0;
		public bool Waiting => _waited && IncomingMessages?.Any() != true;

		public long this[char r]
		{
			get => _registers[r - 'a'];
			private set => _registers[r - 'a'] = value;
		}

		public void Connect(Queue<long> destinationQueue)
		{
			OutgoingMessages = destinationQueue;
		}

		public void Execute(Func<Cpu, bool> condition)
		{
			while (_pc >= -1 && _pc < _program.Length - 1 && condition(this))
				_program[++_pc].Invoke(this);
		}

		public void Load(Instruction[] program)
		{
			_program = program;
			_pc = -1;
		}

		public static class Instructions
		{
			public static readonly Action<Cpu, char, long?, char> Add = (cpu, x, y, yr) => cpu[x] += y ?? cpu[yr];

			public static readonly Action<Cpu, long?, char, long?, char> Jgz = (cpu, x, xr, y, yr) =>
				cpu._pc += (x ?? cpu[xr]) > 0 ? (y ?? cpu[yr]) - 1 : 0;

			public static readonly Action<Cpu, char, long?, char> Mod = (cpu, x, y, yr) => cpu[x] %= y ?? cpu[yr];
			public static readonly Action<Cpu, char, long?, char> Mul = (cpu, x, y, yr) => cpu[x] *= y ?? cpu[yr];

			public static readonly Action<Cpu, long?, char> Rcv = (cpu, x, xr) =>
			{
				if (!cpu.NetworkAware)
				{
					cpu.RecoveredFrequency = (x ?? cpu[xr]) != 0 ? cpu._freq : cpu.RecoveredFrequency;
					return;
				}

				if (cpu.IncomingMessages!.TryDequeue(out long value))
				{
					cpu._waited = false;
					cpu[xr] = value;
				}
				else
				{
					cpu._waited = true;
					cpu._pc--;
				}
			};

			public static readonly Action<Cpu, char, long?, char> Set = (cpu, x, y, yr) => cpu[x] = y ?? cpu[yr];

			public static readonly Action<Cpu, long?, char> Snd = (cpu, x, xr) =>
			{
				if (cpu.NetworkAware)
				{
					cpu.OutgoingMessages!.Enqueue(x ?? cpu[xr]);
					cpu.SentCount++;
				}
				else
				{
					cpu._freq = x ?? cpu[xr];
				}
			};
		}
	}
}
