using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2020
{
    public static class Day18
    {
        public static long Day18A()
        {
            string[] lines = File.ReadAllLines("Inputs/Day18A.txt");
            long p1 = 0;

            foreach (string line in lines)
                p1 += Evaluate(new Queue<char>(line.ToCharArray().Where(c => c != ' ')));
            
            return p1;
        }

        public static int Day18B()
        {
            string[] lines = File.ReadAllLines("Inputs/Day18A.txt");

            return 0;
        }

        private static long Evaluate(Queue<char> expression)
        {
            Stack<long> stack = new Stack<long>();
            Stack<char> ops = new Stack<char>();

            while (expression.Count > 0)
            {
                char c = expression.Dequeue();

                if (char.IsDigit(c))
                    stack.Push(long.Parse(c.ToString()));
                else if (c == '(')
                    stack.Push(Evaluate(expression));
                else if (c == ')')
                    break;
                else if (ops.Count == 0)
                    ops.Push(c);
                else
                {
                    long result;
                    if (ops.Pop() == '+')
                        result = stack.Pop() + stack.Pop();
                    else
                        result = stack.Pop() * stack.Pop();

                    stack.Push(result);
                    ops.Push(c);
                }
            }

            while (ops.Count > 0)
            {
                long result;
                if (ops.Pop() == '+')
                    result = stack.Pop() + stack.Pop();
                else
                    result = stack.Pop() * stack.Pop();

                stack.Push(result);
            }

            return stack.Peek();
        }
    }
}
