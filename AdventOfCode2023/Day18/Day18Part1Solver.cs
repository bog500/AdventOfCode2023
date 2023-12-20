using AdventOfCode2023.Common;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;


namespace AdventOfCode2023.Day18
{
    public class Day18Part1Solver : Day18BaseSolver
    {


        public override string Solve(List<string> lines)
        {
            return base.Run(lines);
        }

        protected override Instruction ParseInstructionLine(string line)
        {
            var parts = line.Split(' ');
            Direction dir = parts[0] switch
            {
                "D" => Direction.Down,
                "L" => Direction.Left,
                "R" => Direction.Right,
                "U" => Direction.Up,
            };
            int size = int.Parse(parts[1]);
            return new Instruction(dir, size);
        }
    }
}
