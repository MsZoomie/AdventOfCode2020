using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
	class Day18 : DayBase
	{
		public Day18(string inputFile) : base(inputFile)
		{
		}

		public override string InputPath { get; set; }

		public override string SolvePart1()
		{
			var input = File.ReadAllLines(InputPath);

			long output = 0;

			for (int i = 0; i < input.Length; i++)
			{
				var temp = StartCalculation(input[i], false);
				output += temp;
				Console.WriteLine($"{i + 1}: {temp}");
			}

			return $"sum: {output}\n";
		}

		public override string SolvePart2()
		{
			var input = File.ReadAllLines(InputPath);

			long output = 0;

			for (int i = 0; i < input.Length; i++)
			{
				var temp = StartCalculation(input[i], true);
				output += temp;
				Console.WriteLine($"{i + 1}: {temp}");
			}

			return $"sum: {output}\n";
		}

		private long StartCalculation(string input, bool convert)
		{
			if (convert)
			{
				input = ConvPart2(input);
			}

			var exp = input.Replace("(", " ( ");
			exp = exp.Replace(")", " ) ");
			var elements = exp.Split();

			var value = Calculate(elements, out _);

			return value;
		}

		private string ConvPart2(string input)
		{
			var output = input.Replace("*", ")*(");

			var indx = output.IndexOf(")*");
			output = output.Remove(indx, 1);
			output += ")";

			return output;
		}

		private static long Calculate(string[] elements, out int index)
		{
			long value = 0;
			index = 0;

			var nums = new Stack<long>();
			var ops = new Stack<string>();

			for (int i = 0; i < elements.Length; i++)
			{
				var element = elements[i];
				switch (element)
				{
					case "(":
						var inner = elements.Skip(i + 1).Take(elements.Length - 1).ToArray();
						var val = Calculate(inner, out int newIndex);
						i += newIndex;
						if (ops.Count > 0)
						{
							var op = ops.Pop();
							switch (op)
							{
								case "+":
									value += val;
									break;
								case "*":
										value *= val;
									break;
								default:
									break;
							}
						}
						else
						{
							value = val;
						}
						break;
					case ")":
						index = i + 1;
						return value;
					case "+":
					case "*":
						ops.Push(element);
						break;
					default:
						if (long.TryParse(element, out val))
						{
							if (ops.Count > 0)
							{
								var op = ops.Pop();
								switch (op)
								{
									case "+":
										value += val;
										break;
									case "*":
										value *= val;
										break;
									default:
										break;
								}
							}
							else
							{
								value = val;
							}
						}
						break;
				}
			}

			return value;
		}
	}
}
