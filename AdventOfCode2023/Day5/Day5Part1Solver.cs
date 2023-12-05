using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day5
{
    public class Day5Part1Solver : Day5BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            Day5Data data = base.Parse(lines);

            long minValue = long.MaxValue;

            foreach(var seed in data.Seeds)
            {
                long soil = data.Maps[0].Destination(seed);
                long fertilizer = data.Maps[1].Destination(soil);
                long water = data.Maps[2].Destination(fertilizer);
                long light = data.Maps[3].Destination(water);
                long temperature = data.Maps[4].Destination(light);
                long humidity = data.Maps[5].Destination(temperature);
                long location = data.Maps[6].Destination(humidity);

                if (location < minValue)
                    minValue = location;
            }

            return minValue.ToString();
        }
    }
}
