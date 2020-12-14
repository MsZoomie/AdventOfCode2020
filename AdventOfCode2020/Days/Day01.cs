using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2020.Days
{
	class Day01 : IDay
	{
		static string inputPath = "C:\\C\\Repos\\AdventOfCode2020\\AdventOfCode2020\\AdventOfCode2020\\Inputs\\Input01.txt";
		public string SolvePart1()
		{
			var input = File.ReadAllLines(inputPath);
			foreach (var first in input)
			{
				int a = int.Parse(first);

				List<string> temp = new List<string>();
				temp.AddRange(input);
				temp.Remove(first);
				foreach (var second in temp)
				{
					int b = int.Parse(second);
					if(a + b == 2020)
					{
						var output = a * b;
						return output.ToString();
					}
				}
			}
			return "Couldn't find answer";
		}

		public string SolvePart2()
		{
			var input = File.ReadAllLines(inputPath);
			foreach (var first in input)
			{
				int a = int.Parse(first);

				List<string> outer = new List<string>();
				outer.AddRange(input);
				outer.Remove(first);
				foreach (var second in outer)
				{
					int b = int.Parse(second);
					List<string> inner = new List<string>(outer);
					inner.Remove(second);
					foreach (var third in inner)
					{
						int c = int.Parse(third);
						if (a + b + c == 2020)
						{
							var output = a * b * c;
							return output.ToString();
						}
					}
				}
			}
			return "Couldn't find answer";
		}
	}
}
