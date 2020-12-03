using AOC2020.Inputs;

namespace AOC2020
{
    public static class Day3
    {
        public static int Day3A()
        {
            var trees = 0;

            AOCInput input = new AOCInput().GetInput("Inputs/Day3A.json");
            
            int i = 0;
            int j = 0;

            while(i < input.InputString.Count)
            {
                if (input.InputString[i][j] == '#')
                    trees++;
                
                i++;
                j += 3;
                j = j > input.InputString[0].Length - 1 ? j - input.InputString[0].Length : j;
            }

            return trees;
        }
    }
}
