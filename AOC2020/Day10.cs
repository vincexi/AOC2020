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
            var list = new List<int>();
            long count = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                list.Add(int.Parse(lines[i]));
            }

            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                count += Recurse(list, i, list[i], 0);
            }
            
            return count;
        }

        private static long Recurse(List<int> list, int idx, int current, long count)
        {
            var diff = list[idx] - current;
            current = list[idx];
            long newCount = 0;
            if (diff > 3)
                return 0;
            
            if (idx + 3 < list.Count && list[idx + 3] - list[idx] < 4)
                count = Recurse(list, idx + 3, current, newCount);
            if (idx + 2 < list.Count && list[idx + 2] - list[idx] < 4)
                count = Recurse(list, idx + 2, current, newCount);
            if (idx + 1 < list.Count && list[idx + 1] - list[idx] < 4)
                count = Recurse(list, idx + 1, current, newCount);
            newCount++;
            return count + newCount;
        }
    }
}
