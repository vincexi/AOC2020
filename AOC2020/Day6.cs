using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public static class Day6
    {
        public static int Day6A()
        {
            var count = 0;
            string[] lines = File.ReadAllLines("Inputs/Day6A.txt");

            var answers = string.Empty;

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    answers += $"{line}";

                    if (line != lines.Last())
                        continue;
                }

                var counts = new HashSet<char>();

                for (int i = 0; i < answers.Length; i++)
                {
                    if (!counts.Contains(answers[i]))
                    {
                        counts.Add(answers[i]);
                        count++;
                    }

                }

                answers = string.Empty;
            }

            return count;
        }

    }
}
