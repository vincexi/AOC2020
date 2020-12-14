using System;
using System.Collections.Generic;
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

        public static ulong Day13B()
        {
            string[] lines = File.ReadAllLines("Inputs/Day13A.txt");
            var inputs = lines[1].Split(",");
            var buses = new List<Bus>();
            
            for (uint i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] != "x")
                {
                    Bus pair = new Bus
                    {
                        Id = uint.Parse(inputs[i]),
                        Position = i
                    };
                    buses.Add(pair);
                }
            }

            ulong step = buses[0].Id;
            ulong timestamp = buses[0].Id;

            foreach (Bus pair in buses.Skip(1))
            {
                while ((timestamp + pair.Position) % pair.Id != 0)
                {
                    timestamp += step;
                }

                step *= pair.Id;
            }

            return timestamp;
        }

        private struct Bus
        {
            public uint Id;
            public uint Position;
        }
    }
}
