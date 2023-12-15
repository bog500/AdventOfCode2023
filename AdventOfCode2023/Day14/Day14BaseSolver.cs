using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day14
{
    public abstract class Day14BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        protected Platform Parse(List<string> lines)
        {
            Platform p = new();

            int y = 0;
            foreach(var line in lines)
            {
                int x = -1;
                foreach(char c in line)
                {
                    x++;
                    if (c == '.')
                        continue;

                    Coord coord = new(x, y);
                    p.RockLocations.Add(coord);
                    if (c == 'O')
                    {
                        MovableRock rock = new MovableRock(coord);
                        p.MovableRocks.Add(rock);
                    }
                    else
                    {
                        FixRock rock = new FixRock(coord);
                        p.FixedRocks.Add(rock);
                    }                    
                    
                }
                y++;
            }

            p.SetNbRowsCols(lines[0].Length, lines.Count);

            return p;
        }

    }
}
