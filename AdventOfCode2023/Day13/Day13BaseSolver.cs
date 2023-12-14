using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day13
{
    public abstract class Day13BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        public List<Island> Parse(List<string> lines)
        {
            List<Island> list = new();

            if (lines.Last() != "")
                lines.Add("");

            Island island = new();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    list.Add(island);
                    island = new();
                }
                else
                    island.AddRow(line);
            }
            return list;
        }


    }
}
