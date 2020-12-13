using System;
using System.IO;
using System.Linq;

namespace AOC2020
{
    public static class Day13
    {
        public static int Day13A()
        {
            string[] lines = File.ReadAllLines("Inputs/Day13A.txt");

            int time = int.Parse(lines[0]);
            int[] buses = lines[1].Split(",")
                .Where(x => x != "x")
                .Select(x => int.Parse(x))
                .ToArray();

            int lowestDiff = int.MaxValue;
            int busId = 0;

            foreach (var bus in buses)
            {
                int diff = int.MaxValue;
                int div = time / bus;
                int mult = (bus * div);
                
                if (mult < time)
                    mult += bus;

                diff = mult - time;
                Console.WriteLine($"busId: {bus}, time difference: {diff}");

                if (diff < lowestDiff)
                {
                    lowestDiff = diff;
                    busId = bus;
                }
            }

            return  busId * lowestDiff;
        }
    }
}
