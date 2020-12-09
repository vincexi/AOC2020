using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2020
{
    public static class Day8
    {
        public static int Day8A()
        {
            string[] lines = File.ReadAllLines("Inputs/Day8A.txt");
            var acc = 0;
            var idx = 0;
            var hash = new HashSet<int>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (!hash.Add(idx))
                    return acc;

                var inputs = lines[idx].Split(" ");
                
                if (inputs[0] == "nop")
                {
                    idx++;
                    continue;
                }
                
                if (inputs[0] == "acc")
                {
                    idx++;
                    acc += int.Parse(inputs[1]);
                }
                
                else if (inputs[0] == "jmp")
                    idx += int.Parse(inputs[1]);
            }

            return 0;
        }

        public static int Day8B()
        {
            string[] lines = File.ReadAllLines("Inputs/Day8A.txt");
            var acc = 0;
            var idx = 0;
            var hash = new HashSet<int>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (!hash.Add(idx))
                    return acc;

                var inputs = lines[idx].Split(" ");

                if (inputs[0] == "nop")
                {
                    idx++;
                    continue;
                }

                if (inputs[0] == "acc")
                {
                    idx++;
                    acc += int.Parse(inputs[1]);
                }

                else if (inputs[0] == "jmp")
                    idx += int.Parse(inputs[1]);
            }

            return 0;
        }
    }
}
