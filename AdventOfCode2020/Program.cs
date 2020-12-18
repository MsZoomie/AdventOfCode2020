using System;

namespace AdventOfCode2020
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Advent of Code 2020");

			var day = new Days.Day18("ExInput18");
			Console.WriteLine("Part 1:\n" + day.SolvePart1());

			Console.WriteLine("Part 2:\n" + day.SolvePart2());
		}
	}
}
