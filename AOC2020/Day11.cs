using System;
using System.IO;

namespace AOC2020
{
    public static class Day11
    {
        public static int Day11A()
        {
            string[] lines = File.ReadAllLines("Inputs/Day11A.txt");
            char[,] map = new char[lines.Length, lines[0].Length];
            char[,] snapshot = GetSnapshot(lines);
            bool change = false;
            change = true;
            var loops = 0;
            var count = 0;
            var iIdx = snapshot.GetLength(0);
            var jIdx = snapshot.GetLength(1);

            while (change)
            {
                change = false;
                loops++;
                count = 0;
                for (int i = 0; i < iIdx; i++)
                {
                    for (int j = 0; j < jIdx; j++)
                    {
                        var occupiedSeats = 0;

                        occupiedSeats += TopRow(i, j, snapshot, jIdx);

                        occupiedSeats += MiddleRow(i, j, snapshot, jIdx);

                        occupiedSeats += BottomRow(i, j, snapshot, iIdx, jIdx);

                        if (snapshot[i,j] == '#')
                        {
                            map[i, j] = occupiedSeats >= 4 ? 'L' : '#';
                            
                            if (map[i, j] == '#')
                                count++;
                            if (!change)
                                change = snapshot[i, j] != map[i, j];
                        }
                        else if (snapshot[i,j] == 'L')
                        {
                            map[i, j] = occupiedSeats == 0 ? '#' : 'L';
                            
                            if (map[i, j] == '#')
                                count++;
                            if (!change)
                                change = snapshot[i, j] != map[i, j];
                        }
                        else if (snapshot[i,j] == '.')
                            map[i, j] = '.';
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine($"Loop: {loops}");
                SetSnapshot(iIdx, jIdx, snapshot, map);
            }

            return count;
        }

        private static char[,] GetSnapshot(string[] lines)
        {
            char[,] snapshot = new char[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    snapshot[i, j] = lines[i][j];
                }
            }

            return snapshot;
        }

        private static void SetSnapshot(int iIdx, int jIdx, char[,] snapshot, char[,] map)
        {
            for (int i = 0; i < iIdx; i++)
            {
                for (int j = 0; j < jIdx; j++)
                {
                    snapshot[i, j] = map[i, j];
                }
            }
        }

        private static int TopRow(int i, int j, char[,] snapshot, int jIdx)
        {
            int occupiedSeats = 0;
            if (i - 1 > -1)
            {
                if (j - 1 > -1 && snapshot[i - 1, j - 1] == '#')
                    occupiedSeats++;

                if (snapshot[i - 1, j] == '#')
                    occupiedSeats++;

                if (j + 1 < jIdx && snapshot[i - 1, j + 1] == '#')
                    occupiedSeats++;
            }

            return occupiedSeats;
        }

        private static int MiddleRow(int i, int j, char[,] snapshot, int jIdx)
        {
            int occupiedSeats = 0;

            if (j - 1 > -1 && snapshot[i, j - 1] == '#')
                occupiedSeats++;

            if (j + 1 < jIdx && snapshot[i, j + 1] == '#')
                occupiedSeats++;

            return occupiedSeats;
        }

        private static int BottomRow(int i, int j, char[,] snapshot, int iIdx, int jIdx)
        {
            int occupiedSeats = 0;
            if (i + 1 < iIdx)
            {
                if (j - 1 > -1 && snapshot[i + 1, j - 1] == '#')
                    occupiedSeats++;

                if (snapshot[i + 1, j] == '#')
                    occupiedSeats++;

                if (j + 1 < jIdx && snapshot[i + 1, j + 1] == '#')
                    occupiedSeats++;
            }

            return occupiedSeats;
        }
    }
}
