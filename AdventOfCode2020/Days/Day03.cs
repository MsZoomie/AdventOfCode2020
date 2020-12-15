using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020.Days
{
	class Day03 : DayBase
	{
		public Day03(string inputFile) : base(inputFile) { }
		public override string InputPath { get; set; }

		public override string SolvePart1()
		{
			var input = File.ReadAllLines(InputPath);
			int[] step = { 3, 1 };

			int trees = CalculateSlope(input, step);

			//string[] map = new string[input.Length];
			//input.CopyTo(map, 0);


			//int[] pos = { step[0], step[1] };
			//int trees = 0;
			
			//while (pos[1] < input.Length)
			//{
			//	if (pos[0] >= map[0].Length - step[0])
			//	{
			//		for (int i = 0; i < map.Length; i++)
			//		{
			//			map[i] += input[i];
			//		}
			//	}

			//	if (map[pos[1]].ElementAt(pos[0]) == '#')
			//	{
			//		var temp = map[pos[1]].Remove(pos[0], 1);
			//		map[pos[1]] = temp.Insert(pos[0], "X");
			//		trees++;
			//	}
			//	else
			//	{
			//		var temp = map[pos[1]].Remove(pos[0], 1);
			//		map[pos[1]] = temp.Insert(pos[0], "O");
			//	}

			//	pos[0] += step[0];
			//	pos[1] += step[1];
			//}

			return trees.ToString();
		}


		public override string SolvePart2()
		{
			var input = File.ReadAllLines(InputPath);
			int[][] steps = { new int[] { 1, 1 }, new int[] { 3, 1 }, new int[] { 5, 1 }, new int[] { 7, 1 }, new int[] { 1, 2 } };

			int mult = 1;
			foreach (var step in steps)
			{
				mult *= CalculateSlope(input, step);
			}

			return mult.ToString();
		}

		private int CalculateSlope(string[] map, int[] step)
		{
			int[] pos = { 0, 0 };
			int trees = 0;
			
			while(pos[1] < map.Length - step[1])
			{
				pos[0] = (pos[0] + step[0]) % map[0].Length;
				pos[1] += step[1];

				if(map[pos[1]].ElementAt(pos[0]) == '#')
				{
					trees++;
				}
			}

			Console.WriteLine($"Trees: {trees}");
			return trees;
		}
	}
}
