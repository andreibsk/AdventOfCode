using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2016
{
	public class Day04 : Puzzle
	{
		private readonly Room[] _rooms;

		public Day04(string[] input) : base(input)
		{
			_rooms = input.Select(Room.Parse).ToArray();
		}

		public override DateTime Date => new DateTime(2016, 12, 4);
		public override string Title => "Security Through Obscurity";

		public override string? CalculateSolution()
		{
			Solution = _rooms.Where(r => r.IsReal()).Sum(r => r.SectorId).ToString();
			return Solution;
		}

		public override string? CalculateSolutionPartTwo()
		{
			SolutionPartTwo = _rooms
				.Where(r => r.DecryptedName().Equals("northpole object storage"))
				.FirstOrDefault()
				?.SectorId.ToString();
			return SolutionPartTwo;
		}

		private class Room
		{
			private static readonly Regex s_regex = new Regex(
				@"^(?<name>([a-z]+-)*[a-z]+)-(?<sector>\d+)\[(?<checksum>[a-z]{5})\]$",
				RegexOptions.Compiled);

			public Room(string encryptedName, int sectorId, string checksum)
			{
				EncryptedName = encryptedName;
				SectorId = sectorId;
				Checksum = checksum;
			}

			public string Checksum { get; set; }
			public string EncryptedName { get; set; }
			public int SectorId { get; set; }

			public static Room Parse(string input)
			{
				Match match = s_regex.Match(input);
				if (!match.Success)
					throw new FormatException();

				return new Room(match.Groups["name"].Value, int.Parse(match.Groups["sector"].Value), match.Groups["checksum"].Value);
			}

			public string DecryptedName()
			{
				int len = 'z' - 'a' + 1;
				int shift = SectorId % len;
				return string.Concat(EncryptedName.Select(c => c == '-' ? ' ' : (char)((c - 'a' + shift) % len + 'a')));
			}

			public bool IsReal()
			{
				return Checksum == string.Concat(EncryptedName
					.Replace("-", "")
					.GroupBy(c => c)
					.OrderByDescending(g => g.Count())
					.ThenBy(g => g.Key)
					.Select(g => g.Key)
					.Take(5));
			}
		}
	}
}
