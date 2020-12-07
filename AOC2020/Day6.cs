using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public static int Day6B()
        {
            var count = 0;
            var userCount = 0;
            var occurences = new Dictionary<char, int>();
            string[] lines = File.ReadAllLines("Inputs/Day6A.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    userCount++;
                    foreach (var item in lines[i])
                    {
                        if (occurences.ContainsKey(item))
                            occurences[item]++;
                        else
                            occurences.Add(item, 1);
                    }

                    if(i + 1 != lines.Length)
                        continue;
                }

                foreach (var item in occurences.Values)
                {
                    if (item == userCount)
                        count++;
                }

                userCount = 0;
                occurences = new Dictionary<char, int>();
            }

            return count;
        }
    }
}
