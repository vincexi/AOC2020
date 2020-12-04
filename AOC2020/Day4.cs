using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2020
{
    public static class Day4
    {
        public static int Day4A()
        {
            var validPassports = 0;
            var totalPassports = 0;
            var requiredKeys = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            string[] lines = File.ReadAllLines("Inputs/Day4A.txt");

            var passport = string.Empty;

            foreach (string line in lines)
            {
                if(!string.IsNullOrWhiteSpace(line))
                {
                    passport += $" {line}";
                    continue;
                }

                var pairs = passport.Split(" ");
                
                var keys = pairs.Select(x => x.Split(":"))
                    .Select(y=>y[0])
                    .Where(z=> !string.IsNullOrWhiteSpace(z))
                    .ToArray();

                passport = string.Empty;
                totalPassports++;

                var isValid = true;

                foreach (var item in requiredKeys)
                {
                    if(!keys.Contains(item))
                    {
                        isValid = false;
                        break;
                    }
                }

                validPassports = isValid ? validPassports + 1 : validPassports;
            }

            Console.WriteLine($"Total passports {totalPassports}");
            return validPassports;
        }

    }
}
