using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2020
{
    public static class Day16
    {
        public static int Day16A()
        {
            string[] lines = File.ReadAllLines("Inputs/Day16A.txt");
            var tickets = new List<List<int>>();
            var idx = 0;
            var hashes = new List<HashSet<int>>();

            while (lines[idx] != string.Empty)
            {
                var hash = new HashSet<int>();
                foreach (var item in lines[idx].Split(": ")[1].Split(" or "))
                {
                    var numbers = item.Split("-");
                    Enumerable.Range(int.Parse(numbers[0]), int.Parse(numbers[1]) - int.Parse(numbers[0]) + 1)
                        .ToList()
                        .ForEach(x=> hash.Add(x));
                }
                hashes.Add(hash);
                idx++;
            }

            idx += 5;

            while (idx < lines.Length)
            {
                var ticket = lines[idx].Split(",")
                    .Select(x => int.Parse(x))
                    .ToList();

                for (int i = 0; i < hashes.Count; i++)
                {

                }

                idx++;
            }

            return 0;
        }

        public static int Day16B()
        {
            string[] lines = File.ReadAllLines("Inputs/Day16A.txt");

            return 0;
        }
    }
}
