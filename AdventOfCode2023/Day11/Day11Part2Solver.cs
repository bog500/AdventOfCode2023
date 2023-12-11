using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day11
{
    public class Day11Part2Solver : Day11BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            var ans = base.CalcDistance(lines);
            return ans.ToString();
        }

        int _expand = 1000000;

        public void Expand(int expand) => _expand = expand;

        protected override long Expanding => (_expand - 1);
    }
}
