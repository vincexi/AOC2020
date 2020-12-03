using AOC2020.Inputs;
using System;

namespace AOC2020
{
    public static class Day3
    {
        public static long Day3A()
        {
            long trees = 0;

            AOCInput input = new AOCInput().GetInput("Inputs/Day3A.json");

            int i = 0;
            int j = 0;

            while(i < input.InputString.Count)
            {
                trees = CheckForTree(input.InputString[i][j], trees);

                i++;
                j += 3;
                j = WrapMap(j, input.InputString[0].Length);
            }

            return trees;
        }

        public static long Day3B()
        {
            //Right 1, down 1.
            //Right 3, down 1. (This is the slope you already checked.)
            //Right 5, down 1.
            //Right 7, down 1.
            //Right 1, down 2.

            var treesA = new TreeCount(1);
            var treesB = new TreeCount(3);
            var treesC = new TreeCount(5);
            var treesD = new TreeCount(7);
            var treesE = new TreeCount(1);

            AOCInput input = new AOCInput().GetInput("Inputs/Day3A.json");

            int i = 0;
            int mapLength = input.InputString[i].Length;
            while (i < input.InputString.Count)
            {
                treesA.Count = CheckForTree(input.InputString[i][treesA.Idx], treesA.Count);
                treesA.Idx += treesA.Slope;
                treesA.Idx = WrapMap(treesA.Idx, mapLength);

                treesB.Count = CheckForTree(input.InputString[i][treesB.Idx], treesB.Count);
                treesB.Idx += treesB.Slope;
                treesB.Idx = WrapMap(treesB.Idx, mapLength);

                treesC.Count = CheckForTree(input.InputString[i][treesC.Idx], treesC.Count);
                treesC.Idx += treesC.Slope;
                treesC.Idx = WrapMap(treesC.Idx, mapLength);

                treesD.Count = CheckForTree(input.InputString[i][treesD.Idx], treesD.Count);
                treesD.Idx += treesD.Slope;
                treesD.Idx = WrapMap(treesD.Idx, mapLength);

                i++;
            }

            i = 0;
            while (i < input.InputString.Count)
            {
                treesE.Count = CheckForTree(input.InputString[i][treesE.Idx], treesE.Count);
                treesE.Idx += treesE.Slope;
                treesE.Idx = WrapMap(treesE.Idx, mapLength);

                i += 2;
            }

            Console.WriteLine($"A: {treesA.Count}, B: {treesB.Count}, C: {treesC.Count}, D: {treesD.Count}, E: {treesE.Count}");

            return treesA.Count * treesB.Count * treesC.Count * treesD.Count * treesE.Count;
        }

        private static long CheckForTree(char location, long currentCount)
        {
            if (location == '#')
                currentCount++;
            return currentCount;
        }

        private static int WrapMap(int j, int length)
        {
            return j > length - 1 ? j - length : j;
        }

        public class TreeCount
        {
            public TreeCount(int slope)
            {
                Slope = slope;
            }
            public int Idx { get; set; }
            public long Count { get; set; }
            public int Slope { get; set; }
        }
    }
}