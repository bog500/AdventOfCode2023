using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day14
{
    public class Day14Part2Solver : Day14BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            var platform = base.Parse(lines);


            int nbCount = 0;

            Dictionary<string, int> keys = new();

            int cycleSize = int.MaxValue;
            bool cycleFound = false;

            while (nbCount < 2000)
            {
                

                nbCount++;
                platform.Cycle();
                var serial = string.Join(';', platform.MovableRocks
                    .OrderBy(o => o.Coord.Y)
                    .ThenBy(o => o.Coord.X)
                    .Select(o => o.Coord.X + "," + o.Coord.Y)
                    );


                if (!cycleFound)
                {
                    if (keys.Keys.Contains(serial))
                    {
                        int cycleStart = keys[serial];
                        int cycleEnd = nbCount;
                        cycleSize = cycleEnd - cycleStart;
                        cycleFound = true;
                    }
                    else
                        keys.Add(serial, nbCount);
                }else
                {
                    int modulo = (1000000000 - nbCount) % cycleSize;
                    if(modulo == 0)
                    {
                        var load2 = platform.GetLoad();
                        return load2.ToString();
                    }
                }
            }

            return "NOT FOUND";
        }
    }
}
