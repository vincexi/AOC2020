using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020
{
    public static class Day4
    {
        static string[] _requiredKeys = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
        static string[] _eyeColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        public static int Day4A()
        {
            var validPassports = 0;
            string[] lines = File.ReadAllLines("Inputs/Day4A.txt");

            var passport = string.Empty;

            foreach (string line in lines)
            {
                if(!string.IsNullOrWhiteSpace(line))
                {
                    passport += $" {line}";

                    if(line != lines.Last())
                        continue;
                }

                var pairs = passport.Split(" ").Select(y => y)
                    .Where(z => !string.IsNullOrWhiteSpace(z))
                    .ToArray();

                var keys = pairs.Select(x => x.Split(":"))
                    .Select(y=>y[0])
                    .ToArray();

                passport = string.Empty;

                validPassports = _requiredKeys.All(x => keys.Contains(x)) ? validPassports + 1 : validPassports;
            }

            return validPassports;
        }

        public static int Day4B()
        {
            var validPassports = 0;
            string[] lines = File.ReadAllLines("Inputs/Day4A.txt");

            var passport = string.Empty;

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    passport += $" {line}";

                    if (line != lines.Last())
                        continue;
                }

                var pairs = passport.Split(" ").Select(y => y)
                    .Where(z => !string.IsNullOrWhiteSpace(z))
                    .ToArray();

                passport = string.Empty;

                validPassports = IsValid(pairs) ? validPassports + 1 : validPassports;
            }

            return validPassports;
        }

        private static bool IsValid(string[] pairs)
        {
            var keys = new List<string>();

            foreach (var item in pairs)
            {
                var keyValue = item.Split(":");
                keys.Add(keyValue[0]);

                if(keyValue[0] == "byr")
                {
                    if (!int.TryParse(keyValue[1], out var value) ||
                        1920 > value ||
                        value > 2002)
                        return false;
                }

                else if (keyValue[0] == "iyr")
                {
                    if (!int.TryParse(keyValue[1], out var value) ||
                        2010 > value ||
                        value > 2020)
                        return false;
                }

                else if (keyValue[0] == "eyr")
                {
                    if (!int.TryParse(keyValue[1], out var value) ||
                        2020 > value ||
                        value > 2030)
                        return false;
                }

                else if (keyValue[0] == "hgt")
                {
                    var unit = keyValue[1].Substring(keyValue[1].Length - 2);
                    var value = keyValue[1][0..^2];

                    if (unit == "cm")
                    {
                        if (!int.TryParse(value, out var height) ||
                        150 > height ||
                        height > 193)
                            return false;
                    }
                    else if (unit == "in")
                    {
                        if (!int.TryParse(value, out var height) ||
                            59 > height ||
                            height > 76)
                            return false;
                    }
                    else
                        return false;
                }

                else if (keyValue[0] == "hcl")
                {
                    Regex regex = new Regex("^#([a-f0-9]{6})$");

                    if (!regex.IsMatch(keyValue[1]))
                        return false;
                }

                else if (keyValue[0] == "ecl")
                {
                    if (!_eyeColors.Contains(keyValue[1]))
                        return false;
                }

                else if (keyValue[0] == "pid")
                {
                    if (keyValue[1].Length != 9 || !int.TryParse(keyValue[1], out _))
                        return false;
                }
            }

            if (!_requiredKeys.All(x => keys.Contains(x)))
                return false;

            return true;
        }
    }
}
