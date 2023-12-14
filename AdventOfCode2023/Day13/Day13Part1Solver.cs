using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day13
{
    public class Day13Part1Solver : Day13BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            var list = base.Parse(lines);

            int total = 0;

            foreach(var island in list)
            {
                var mirrors = island.GetMirrors();

                if (mirrors.mirrorX != -1)
                    total += mirrors.mirrorX + 1;

                if (mirrors.mirrorY != -1)
                    total += 100 * (mirrors.mirrorY + 1);
            }

            return total.ToString();
        }
    }
}
