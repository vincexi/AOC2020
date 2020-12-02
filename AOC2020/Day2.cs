using AOC2020.Inputs;
using System.Collections.Generic;

namespace AOC2020
{
    public static class Day2
    {
        public static int Day2A()
        {
            var validPasswords = 0;

            AOCInput input = new AOCInput().GetInput("Inputs/Day2A.json");

            foreach (var item in input.InputString)
            {
                // "2-4 p: vpkpp"
                var arr = item.Split(" ");
                var range = arr[0].Split("-");
                var min = int.Parse(range[0]);
                var max = int.Parse(range[1]);
                var character = arr[1][0];
                var password = arr[2];

                // Console.WriteLine($"min: {min}, max: {max}, character: {character}, password: {password}");

                Dictionary<char, int> dict = new Dictionary<char, int>();

                for (int i = 0; i < password.Length; i++)
                {
                    if (dict.ContainsKey(password[i]))
                        dict[password[i]]++;
                    else
                        dict.Add(password[i], 1);

                    if (password[i] == character && dict[password[i]] > max)
                        break;
                }

                if (dict.ContainsKey(character) &&
                    dict[character] >= min &&
                    dict[character] <= max)
                    validPasswords++;
            }

            return validPasswords;
        }

        public static int Day2B()
        {
            var validPasswords = 0;

            AOCInput input = new AOCInput().GetInput("Inputs/Day2A.json");

            foreach (var item in input.InputString)
            {
                // "2-4 p: vpkpp"
                var arr = item.Split(" ");
                var range = arr[0].Split("-");
                var idxA = int.Parse(range[0]) - 1;
                var idxB = int.Parse(range[1]) - 1;
                var character = arr[1][0];
                var password = arr[2];
                
                if ((password[idxA] == character && password[idxB] != character) ||
                    (password[idxA] != character && password[idxB] == character))
                    validPasswords++;
            }

            return validPasswords;
        }
    }
}
