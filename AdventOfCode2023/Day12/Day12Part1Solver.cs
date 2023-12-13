using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day12
{
    public class Day12Part1Solver : Day12BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            int total = 0;
            foreach(var line in lines)
            {
                var s = new Spring(FormatLine(line));
                total += s.Alternates.Count;
            }
            return total.ToString();
        }

        private string FormatLine(string line)
        {

            while (line.Contains(".."))
                line = line.Replace("..", ".");

            return line;
        }

    }
}
