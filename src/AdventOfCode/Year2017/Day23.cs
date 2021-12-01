using Instruction = System.Action<AdventOfCode.Year2017.Day23.Cpu>;

namespace AdventOfCode.Year2017;

public class Day23 : Puzzle
{
	private readonly Instruction[] _instructions;

	public Day23(string[] input) : base(input)
	{
		_instructions = input
			.Select<string, Instruction>(instructionString =>
			{
				instructionString.Split(' ')
					.DeconstructValuesOrDefault(out string? inst, out string? xs, out string? ys);

				long? x = xs.ToLongOrDefault(), y = ys?.ToLongOrDefault();
				char xr = xs![0], yr = ys![0];

				return inst switch
				{
					"set" => cpu => Cpu.Instructions.Set(cpu, xr, y, yr),
					"sub" => cpu => Cpu.Instructions.Sub(cpu, xr, y, yr),
					"mul" => cpu => Cpu.Instructions.Mul(cpu, xr, y, yr),
					"jnz" => cpu => Cpu.Instructions.Jnz(cpu, x, xr, y, yr),

					_ => throw new FormatException()
				};
			})
			.ToArray();
	}

	public override DateTime Date => new DateTime(2017, 12, 23);
	public override string Title => "Coprocessor Conflagration";

	public override string? CalculateSolution()
	{
		var cpu = new Cpu();
		cpu.Load(_instructions);
		cpu.Execute();

		return Solution = cpu.MulCount.ToString();
	}

	public override string? CalculateSolutionPartTwo()
	{
		int b, c, d, h = 0;

		b = 93 * 100 + 100_000;
		c = b + 17_000;

		do
		{
			d = 2;
			do
			{
				if (b % d == 0)
				{
					h += 1;
					break;
				}

				d += 1;
			}
			while (d - b != 0);

			if (b - c == 0)
				return SolutionPartTwo = h.ToString();

			b += 17;
		}
		while (true);
	}

	internal class Cpu
	{
		private readonly long[] _registers = new long['h' - 'a' + 1];
		private long _pc;
		private Instruction[] _program = Array.Empty<Instruction>();

		public Cpu()
		{
		}

		public Cpu(bool debug)
		{
			if (debug)
				this['a'] = 1;
		}

		public int MulCount { get; private set; } = 0;

		public long this[char r]
		{
			get => _registers[r - 'a'];
			private set => _registers[r - 'a'] = value;
		}

		public void Execute()
		{
			try
			{
				while (_pc >= -1 && _pc < _program.Length - 1)
					_program[++_pc].Invoke(this);
			}
			catch (IndexOutOfRangeException) { return; }
		}

		public void Load(Instruction[] program)
		{
			_program = program;
			_pc = -1;
		}

		public static class Instructions
		{
			public static readonly Action<Cpu, long?, char, long?, char> Jnz =
				(cpu, x, xr, y, yr) => cpu._pc += (x ?? cpu[xr]) != 0 ? (y ?? cpu[yr]) - 1 : 0;

			public static readonly Action<Cpu, char, long?, char> Mul =
				(cpu, xr, y, yr) => { cpu[xr] *= y ?? cpu[yr]; cpu.MulCount++; };

			public static readonly Action<Cpu, char, long?, char> Set = (cpu, xr, y, yr) => cpu[xr] = y ?? cpu[yr];
			public static readonly Action<Cpu, char, long?, char> Sub = (cpu, xr, y, yr) => cpu[xr] -= y ?? cpu[yr];
		}
	}
}
