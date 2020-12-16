using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2020
{
    public static class Day15
    {
        public static int Day15A()
        {
            string[] lines = File.ReadAllLines("Inputs/Day15A.txt");

            var dict = new Dictionary<int, int[]>();
            var inputs = lines[0].Split(",");
            for (int i = 0; i < inputs.Length; i++)
            {
                dict.Add(int.Parse(inputs[i]), new int[] { i + 1, 0 });
            }

            var isNew = true;
            var lastNumber = int.Parse(inputs[^1]);
            var newIdx = 0;

            for (int i = inputs.Length + 1; i < 2021; i++)
            {
                if(isNew)
                {
                    if (dict.ContainsKey(newIdx))
                    {
                        dict[newIdx][1] = i;
                        isNew = false;
                    }
                    else
                    {
                        dict.Add(newIdx, new int[] { i, 0 });
                        isNew = true;
                    }

                    lastNumber = dict.First(x => x.Key == newIdx).Key;
                }
                else
                {
                    var age = dict[lastNumber][1] - dict[lastNumber][0];
                    dict[lastNumber][0] = dict[lastNumber][1];
                    dict[lastNumber][1] = i;

                    if (dict.ContainsKey(age))
                    {
                        isNew = false;
                        dict[age][1] = i;
                    }
                    else
                    {
                        isNew = true;
                        dict.Add(age, new int[] { i, 0 });
                    }

                    lastNumber = age;
                }
            }

            return lastNumber;
        }

        public static int Day15B()
        {
            string[] lines = File.ReadAllLines("Inputs/Day15A.txt");

            var dict = new Dictionary<int, int[]>();
            var inputs = lines[0].Split(",");
            for (int i = 0; i < inputs.Length; i++)
            {
                dict.Add(int.Parse(inputs[i]), new int[] { i + 1, 0 });
            }

            var isNew = true;
            var lastNumber = int.Parse(inputs[^1]);
            var newIdx = 0;

            for (int i = inputs.Length + 1; i < 30000001; i++)
            {
                if (isNew)
                {
                    if (dict.ContainsKey(newIdx))
                    {
                        dict[newIdx][1] = i;
                        isNew = false;
                    }
                    else
                    {
                        dict.Add(newIdx, new int[] { i, 0 });
                        isNew = true;
                    }

                    lastNumber = dict.First(x => x.Key == newIdx).Key;
                }
                else
                {
                    var age = dict[lastNumber][1] - dict[lastNumber][0];
                    dict[lastNumber][0] = dict[lastNumber][1];
                    dict[lastNumber][1] = i;

                    if (dict.ContainsKey(age))
                    {
                        isNew = false;
                        dict[age][1] = i;
                    }
                    else
                    {
                        isNew = true;
                        dict.Add(age, new int[] { i, 0 });
                    }

                    lastNumber = age;
                }
            }

            return lastNumber;
        }
    }
}
