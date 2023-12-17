using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;
using static AdventOfCode2023.Day15.Day15Part2Solver;


namespace AdventOfCode2023.Day16
{
    public abstract class Day16BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        protected char[,] GetLayout(List<string> lines)
        {
            char[,] layout;

            int rows = lines.Count;
            int cols = lines[0].Length;

            layout = new char[cols, rows];

            int y = 0;
            foreach (var line in lines)
            {
                int x = 0;
                foreach (char c in line)
                {
                    layout[x, y] = c;
                    x++;
                }
                y++;
            }

            return layout;
        }
    }
}
