using System;
using System.IO;

namespace AOC2020
{
    public static class Day12
    {
        public static int Day12A()
        {
            string[] lines = File.ReadAllLines("Inputs/Day12A.txt");
            int verticle = 0;
            int horizontal = 0;
            var position = "E";
            var degree = 90;
            
            foreach (var line in lines)
            {
                var direction = line.Substring(0, 1);
                var distance = int.Parse(line.Substring(1));

                if (direction == "F")
                    SetDistance(ref verticle, ref horizontal, position, distance);

                else if (direction == "L")
                {
                    degree = ((degree + 360) - distance) % 360;
                    position = SetPosition(degree);
                }

                else if (direction == "R")
                {
                    degree = ((degree + 360) + distance) % 360;
                    position = SetPosition(degree);
                }

                else
                    SetDistance(ref verticle, ref horizontal, direction, distance);
            }

            Console.WriteLine($"horizontal: {horizontal}, verticle: {verticle}");

            return Math.Abs(horizontal) + Math.Abs(verticle);
        }

        public static int Day12B()
        {
            string[] lines = File.ReadAllLines("Inputs/Day12A.txt");
            int verticle = 0;
            int horizontal = 0;
            var position = "E";
            var degree = 90;

            foreach (var line in lines)
            {
                var direction = line.Substring(0, 1);
                var distance = int.Parse(line.Substring(1));

                if (direction == "F")
                    SetDistance(ref verticle, ref horizontal, position, distance);

                else if (direction == "L")
                {
                    degree = ((degree + 360) - distance) % 360;
                    position = SetPosition(degree);
                }

                else if (direction == "R")
                {
                    degree = ((degree + 360) + distance) % 360;
                    position = SetPosition(degree);
                }

                else
                    SetDistance(ref verticle, ref horizontal, direction, distance);
            }

            Console.WriteLine($"horizontal: {horizontal}, verticle: {verticle}");

            return Math.Abs(horizontal) + Math.Abs(verticle);
        }

        private static void SetDistance(ref int verticle, ref int horizontal, string direction, int distance)
        {
            if (direction == "N")
                verticle += distance;
            else if (direction == "S")
                verticle -= distance;
            else if (direction == "E")
                horizontal += distance;
            else if (direction == "W")
                horizontal -= distance;
        }

        private static string SetPosition(int degree)
        {
            var position = string.Empty;

            if (degree == 0)
                position = "N";

            else if (degree == 90)
                position = "E";

            else if (degree == 180)
                position = "S";

            else if (degree == 270)
                position = "W";

            return position;
        }
    }
}
