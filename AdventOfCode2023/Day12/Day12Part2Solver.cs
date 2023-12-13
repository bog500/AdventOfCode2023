using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day12
{
    public class Day12Part2Solver : Day12BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            int total = 0;
            foreach (var line in lines)
            {
                var s = new Spring(FormatLine(line));
                total += s.Alternates.Count;
            }
            return total.ToString();
        }

        private string FormatLine(string line)
        {
            var parts = line.Split(' ');

            string newLine = parts[0] + '?' + parts[0] + '?' + parts[0] + '?' + parts[0] + '?' + parts[0]
                + ' ' 
                + parts[1] + ',' + parts[1] + ',' + parts[1] + ',' + parts[1] + ',' + parts[1];

            while (newLine.Contains(".."))
                newLine = newLine.Replace("..", ".");

            return newLine;
        }
    }
}
