using System;
using System.Collections.Generic;
using System.IO;
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
    }
}
