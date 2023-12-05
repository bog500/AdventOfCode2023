using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AdventOfCode2023.Day5
{
    public class Day5Part1Solver : Day5BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            data = base.Parse(lines);

            long minValue = long.MaxValue;

            foreach(var seed in data.Seeds)
            {
                long location = GetLocation(seed).Result;

                if (location < minValue)
                    minValue = location;
            }

            return minValue.ToString();
        }
    }
}
