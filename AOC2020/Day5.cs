using AOC2020.Inputs;
using System;
using System.Collections.Generic;
using System.IO;

namespace AOC2020
{
    public static class Day5
    {
        public static int Day5A()
        {
            var highestSeat = 0;
            AOCInput input = new AOCInput().GetInput("Inputs/Day5A.json");

            foreach (var line in input.InputString)
            {
                var seatId = 0;

                var newLine = line.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1');

                var seat = newLine.Substring(0, 7);
                var column = newLine.Substring(7, 3);

                seatId = Convert.ToInt32(seat, 2) * 8 + Convert.ToInt32(column, 2);

                highestSeat = seatId > highestSeat ? seatId : highestSeat;
            }

            return highestSeat;
        }

        public static int Day5B()
        {
            var highestSeat = 0;
            AOCInput input = new AOCInput().GetInput("Inputs/Day5A.json");

            var seats = new List<int>();

            foreach (var line in input.InputString)
            {
                var newLine = line.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1');

                var seat = newLine.Substring(0, 7);
                var column = newLine.Substring(7, 3);

                seats.Add(Convert.ToInt32(seat, 2) * 8 + Convert.ToInt32(column, 2));
            }

            seats.Sort();
            int j = 6;
            for (int i = 0; i < seats.Count; i++)
            {
                if(j != seats[i])
                {
                    return j;
                }
                j++;
            }

            return highestSeat;
        }

    }
}