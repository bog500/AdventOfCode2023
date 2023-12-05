using AdventOfCode2023.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day1
{
    public class Day1Part1Solver : IPartSolver
    {
        public string Solve(List<string> lines)
        {
            int total = 0;
            foreach (var line in lines)
            {
                string formattedLine = formatLine(line);
                List<char> number = new();
                foreach (char c in formattedLine)
                {
                    if (c.IsNumber())
                        number.Add(c);
                }
                int i = int.Parse("" + number.First() + number.Last());
                total += i;
            }
            return total.ToString();
        }

        protected virtual string formatLine(string line)
        {
            return line;
        }
    }
}
