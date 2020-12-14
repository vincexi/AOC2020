using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public static class Day10
    {
        public static int Day10A()
        {
            string[] lines = File.ReadAllLines("Inputs/Day10A.txt");
            var list = new List<int>();
            int current = 0;
            int low = 0;
            int high = 1;

            foreach (var line in lines)
            {
                list.Add(int.Parse(line));
            }

            list.Sort();

            foreach (var item in list)
            {
                var diff = Math.Abs(item - current);
                if (diff == 1)
                    low++;
                else if (diff == 3)
                    high++;
                current = item;
            }

            Console.WriteLine($"low: {low}, high: {high}");

            return low * high;
        }

        public static long Day10B()
        {
            string[] lines = File.ReadAllLines("Inputs/Day10A.txt");
            var list = new List<int> { 0 };

            for (int i = 0; i < lines.Length; i++)
            {
                list.Add(int.Parse(lines[i]));
            }

            list.Sort();
            var memo = new long[list.Count];
            memo[0] = 1;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] - list[i - 1] <= 3)
                    memo[i] += memo[i - 1];

                if (i > 1 && list[i] - list[i - 2] <= 3)
                    memo[i] += memo[i - 2];

                if (i > 2 && list[i] - list[i - 3] <= 3)
                    memo[i] += memo[i - 3];
            }

            return memo[list.Count - 1];
        }
    }
}
