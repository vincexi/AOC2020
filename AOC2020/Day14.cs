using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2020
{
    public static class Day14
    {
        public static ulong Day14A()
        {
            string[] lines = File.ReadAllLines("Inputs/Day14A.txt");
            var list = new List<string>();
            var dict = new Dictionary<string, ulong>();
            var newDict = new Dictionary<string, ulong>();

            foreach (var line in lines)
            {
                if (line.StartsWith("mask"))
                {
                    dict = GetRegister(list);
                    newDict = new Dictionary<string, ulong>(dict.Concat(newDict.Where(x => !dict.Keys.Contains(x.Key))));
                    list = new List<string>();
                }

                list.Add(line);
            }

            dict = GetRegister(list);
            newDict = new Dictionary<string, ulong>(dict.Concat(newDict.Where(x => !dict.Keys.Contains(x.Key))));

            ulong total = 0;

            foreach (var item in newDict.Values)
            {
                total += item;
            }

            return total;
        }

        private static Dictionary<string, ulong> GetRegister(List<string> lines)
        {
            var dict = new Dictionary<string, ulong>();
            if (lines.Count == 0)
                return dict;

            string mask = lines[0].Substring(lines[0].Length - 36, 36);

            for (int i = 1; i < lines.Count; i++)
            {
                var key = Regex.Matches(lines[i], @"\[(.+?)\]")
                                    .Cast<Match>()
                                    .Select(m => m.Groups[1].Value)
                                    .ToArray()[0];
                var value = Convert.ToString((long)Convert.ToUInt64(lines[i].Split(" = ")[1]), 2) ;

                value = value.PadLeft(mask.Length, '0');
                
                var result = mask.ToCharArray();
                
                for (int j = 0; j < mask.Length; j++)
                {
                    if (mask[j] == 'X')
                        result[j] = value[j];
                }

                ulong newValue = Convert.ToUInt64(new string(result), 2);
                
                if (!dict.TryAdd(key, newValue))
                    dict[key] = newValue;
            }
            return dict;
        }

        public static long Day14A2()
        {
            string[] lines = File.ReadAllLines("Inputs/Day14A.txt");
            var dict = new Dictionary<int, long>();
            string mask = string.Empty;
            var input = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("mask"))
                {
                    mask = lines[i].Replace(" ", "").Split("=")[1];
                }
                else
                {
                    var memLocation = int.Parse(lines[i].Replace(" ", "").Split("=")[0].Remove(0, 4).TrimEnd(']'));
                    input = int.Parse(lines[i].Replace(" ", "").Split("=")[1]);
                    if (!dict.ContainsKey(memLocation))
                    {
                        dict.Add(memLocation, ApplyMask(input, mask));
                    }
                    else
                    {
                        dict[memLocation] = ApplyMask(input, mask);
                    }
                }
            }

            return dict.Sum(x => x.Value);
        }

        private static long ApplyMask(int input, string mask)
        {
            var value = Convert.ToString(input, 2);
            var integerValueLength = value.Length;

            for (int k = 0; k < mask.Length - integerValueLength; k++)
            {
                value = "0" + value;
            }
            var result = new char[mask.Length];

            for (int j = mask.Length - 1; j >= 0; j--)
            {
                if (mask[j] == '1')
                {
                    result[j] = '1';
                }
                else if (mask[j] == '0')
                {
                    result[j] = '0';
                }
                else
                {
                    result[j] = value[j];
                }
            }

            var maskedBinary = new string(result);
            return Convert.ToInt64(maskedBinary, 2);
        }
    }
}
