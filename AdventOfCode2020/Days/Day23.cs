using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
	class Day23 : DayBase
	{
		static Dictionary<long, Node> allCups;
		public Day23(string inputFile) : base(inputFile)
		{
		}

		public override string InputPath { get; set; }

		public override string SolvePart1()
		{
			var input = File.ReadAllText(InputPath);
			var cups = GetCups(input, input.Length);
			cups = DoMoves(cups, 100);
			var output = GetOrder(cups);

			return output;
		}

		public override string SolvePart2()
		{
			var input = File.ReadAllText(InputPath);
			var startcup = InitCups(input);
			var output = BigGame(startcup);
			return output.ToString();
		}

		private List<int> GetCups(string input, int numbers)
		{
			var cups = new List<int>();
			foreach (var item in input)
			{
				if (int.TryParse(item.ToString(), out var val))
					cups.Add(val);
			}

			int i = 1;
			while (cups.Count < numbers)
			{
				cups.Add(cups.Max() + 1);
				i++;
			}

			return cups;
		}

		private static Node InitCups(string input)
		{
			var cups = new List<Node>();
			allCups = new Dictionary<long, Node>();
			for (int i = 0; i < input.Length; i++)
			{
				var cup = new Node(int.Parse(input[i].ToString()));
				cups.Add(cup);
				allCups.Add(cup.Value, cup);

				if (i > 0)
				{
					cups[i - 1].Next = cups[i % input.Length];
				}
			}

			var current = cups.Last();

			for (int i = input.Length+1; i <= 1000000; i++)
			{
				current.Next = new Node(i);
				current = current.Next;
				allCups.Add(i, current);
			}

			current.Next = cups[0];

			return cups[0];
		}

		private List<int> DoMoves(List<int> cups, int moves)
		{
			for (int i = 0; i < moves; i++)
			{
				var current = cups.First();
				var spares = cups.GetRange(1, 3);
				cups.RemoveRange(1, 3);

				var destination = -1;
				for (int j = 1; j < cups.Max(); j++)
				{
					var wanted = (9 + (current - j)) % 9;
					if (wanted == 0)
						wanted = 9;

					if (cups.Contains(wanted))
					{
						destination = wanted;
						break;
					}
				}

				cups.InsertRange(cups.IndexOf(destination) + 1, spares);
				cups.Remove(current);
				cups.Add(current);
			}

			return cups;
		}

		private string GetOrder(List<int> cups)
		{
			int start = cups.IndexOf(1);
			var output = new StringBuilder();

			for (int i = 1; i < cups.Count; i++)
			{
				output.Append(cups[(start + i) % cups.Count].ToString());
			}

			return output.ToString();
		}

		private long BigGame(Node startcup)
		{
			int moves = 10000000;
			var current = startcup;

			for (int i = 0; i < moves; i++)
			{
				var spares = new long[]
				{
					current.Next.Value,
					current.Next.Next.Value,
					current.Next.Next.Next.Value
				};
				var firstSpare = current.Next;
				current.Next = current.Next.Next.Next.Next;

				var nextVal = current.Value == 1 ? 1000000 : current.Value - 1;

				while (spares.Contains(nextVal))
				{
					nextVal--;
					if (nextVal == 0)
						nextVal = 1000000;
				}

				var destination = allCups[nextVal];
				firstSpare.Next.Next.Next = destination.Next;
				destination.Next = firstSpare;

				current = current.Next;
			}

			return allCups[1].Next.Value * allCups[1].Next.Next.Value;
		}

		private class Node
		{
			public long Value { get; set; }
			public Node Next { get; set; }
			public Node(long value)
			{
				Value = value;
			}
		}
	}
}