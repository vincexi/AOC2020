using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace AOC2020
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Day 1A - {Day1A()}");
            Console.WriteLine($"Day 1B - {Day1B()}");
        }

        public static double Day1A()
        {
            AOCInput input = new AOCInput();
            
            using (StreamReader r = new StreamReader("Inputs/Day1A.json"))
            {
                string json = r.ReadToEnd();
                input = JsonConvert.DeserializeObject<AOCInput>(json);
            }

            var hash = new HashSet<int>();

            foreach (var item in input.Input)
            {
                var counterpart = 2020 - item;
                if (hash.Contains(counterpart))
                    return item * counterpart;
                else
                    hash.Add(item);
            }

            return 0;
        }

        public static double Day1B()
        {
            AOCInput input = new AOCInput();

            using (StreamReader r = new StreamReader("Inputs/Day1A.json"))
            {
                string json = r.ReadToEnd();
                input = JsonConvert.DeserializeObject<AOCInput>(json);
            }

            var hash = new HashSet<int>();

            for (int i = 0; i < input.Input.Count; i++)
            {
                for (int j = i + 1; j < input.Input.Count; j++)
                {
                    var pair = input.Input[i] + input.Input[j];
                    var counterpart = 2020 - pair;
                    if (hash.Contains(counterpart))
                        return input.Input[i] * input.Input[j] * counterpart;
                    else
                    {
                        if(!hash.Contains(input.Input[i]))
                            hash.Add(input.Input[i]);
                        if(!hash.Contains(input.Input[j]))
                            hash.Add(input.Input[j]);
                    }
                }
            }

            return 0;
        }

        public class AOCInput
        {
            public List<int> Input = new List<int>();
        }
    }
}
