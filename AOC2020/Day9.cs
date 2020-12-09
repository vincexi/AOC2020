using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2020
{
    public static class Day9
    {
        public static long Day9A()
        {
            string[] lines = File.ReadAllLines("Inputs/Day9A.txt");
            var list = new List<long>();
            var preamble = 25;
            for (int i = 0; i < lines.Length; i++)
            {
                if (list.Count > preamble)
                    return list[preamble];

                if(list.Count < preamble)
                {
                    list.Add(long.Parse(lines[i]));
                    continue;
                }
                var item = long.Parse(lines[i]);

                for (int j = 0; j < list.Count; j++)
                {
                    var comp = item - list[j];
                    
                    if (list.Contains(comp) && comp != list[j])
                    {
                        list.RemoveAt(0);
                    }
                }
                list.Add(item);
            }

            return 0;
        }

        public static long Day9B()
        {
            string[] lines = File.ReadAllLines("Inputs/Day9A.txt");
            var list = new List<long>();
            var preamble = 25;
            for (int i = 0; i < lines.Length; i++)
            {
                if (list.Count > preamble)
                    return list[preamble];

                if (list.Count < preamble)
                {
                    list.Add(long.Parse(lines[i]));
                    continue;
                }
                var item = long.Parse(lines[i]);

                for (int j = 0; j < list.Count; j++)
                {
                    var comp = item - list[j];

                    if (list.Contains(comp) && comp != list[j])
                    {
                        list.RemoveAt(0);
                    }
                }
                list.Add(item);
            }

            return 0;
        }
    }
}
