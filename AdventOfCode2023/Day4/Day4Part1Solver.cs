using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day4
{
    public class Day4Part1Solver : Day4BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            var list = base.Parse(lines);
            double total = list.Sum(o => o.Value.Points);
            return total.ToString();
        }
    }
}
