using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
	class Day02 : DayBase
	{
		public Day02(string inputFile) : base(inputFile) {}

		public override string InputPath { get; set; }
		public override string SolvePart1()
		{
			var input = File.ReadAllLines(InputPath);
			int validPwdCount = 0;

			foreach (var row in input)
			{
				string[] pwd = row.Split(' ', '-', ':');

				var occurrences = pwd.Last().Count(x => x == pwd[2].First());
				if (occurrences >= int.Parse(pwd[0]) && occurrences <= int.Parse(pwd[1]))
				{
					validPwdCount++;
				}
			}
			return validPwdCount.ToString();
		}

		public override string SolvePart2()
		{
			var input = File.ReadAllLines(InputPath);
			int validPwdCount = 0;

			foreach (var row in input)
			{
				string[] pwd = row.Split(' ', '-', ':');
				if (pwd.Last().ElementAt(int.Parse(pwd[0]) - 1) == pwd[2].First()
					^ pwd.Last().ElementAt(int.Parse(pwd[1]) - 1) == pwd[2].First())
				{
					validPwdCount++;
				}
			}

			return validPwdCount.ToString();
		}
	}
}
