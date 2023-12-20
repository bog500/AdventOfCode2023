using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.Day18
{
    public class Day18Part2Solver : Day18BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            return base.Run(lines);
        }

        protected override Instruction ParseInstructionLine(string line)
        {
            var parts = line.Split(' ');

            string formatted = parts[2].Replace("(", "").Replace(")", "").Replace("#","");

            string hex = formatted.Substring(0, 5);
            int size = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);

            Direction dir = formatted.Last() switch
            {
                '1' => Direction.Down,
                '2' => Direction.Left,
                '0' => Direction.Right,
                '3' => Direction.Up,
            };
            return new Instruction(dir, size);
        }
    }
}
