using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using AdventOfCode2023.Day5;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace AdventOfCode2023.Day9
{
    public class Day9Part1Solver : Day9BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            return base.BaseSolve(lines);
        }

        protected override void AddZero(ref OasisMap map)
        {
            int maxLevel = map.Level;
            var lastRowCount = map.RowCount(maxLevel);
            map.Oasis.Add(new Coord(lastRowCount, maxLevel), 0);
        }

        protected override void Expand(ref OasisMap map, int level)
        {
            if (level == -1)
                return;

            var rowCount = map.RowCount(level);
            int newValue = map.Oasis[new Coord(rowCount-1, level)] + map.Oasis[new Coord(rowCount-1, level+1)];
            map.Oasis.Add(new Coord(rowCount, level), newValue);

            Expand(ref map, level - 1);
        }

        protected override int GetMapValue(OasisMap map)
        {
            var rowCount = map.RowCount(0);
            return map.Oasis[new Coord(rowCount - 1, 0)];
        }
    }


}
