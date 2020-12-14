using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Days
{
	abstract class DayBase : IDay
	{
		public DayBase(string inputFile)
		{
			InputPath = $"C:\\C\\Repos\\AdventOfCode2020\\AdventOfCode2020\\AdventOfCode2020\\Inputs\\{inputFile}.txt";
		}
		public abstract string InputPath { get; set; }
		public abstract string SolvePart1();
		public abstract string SolvePart2();
	}
}
