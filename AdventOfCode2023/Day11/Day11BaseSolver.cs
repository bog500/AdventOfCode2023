using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day11
{
    public abstract class Day11BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> line);

        long size = 0;
        List<long> rowsNoGalaxies = new();
        List<long> colsNoGalaxies = new();
        List<Galaxy> galaxies = new();


        public long CalcDistance(List<string> lines)
        {
            galaxies = GetGalaxies(lines);
            size = lines.Count;

            AdjustCoord();

            long d = AllDistance();

            return d;
        }

        protected long AllDistance()
        {
            long distance = 0;
            foreach (var g1 in galaxies)
            {
                foreach (var g2 in galaxies.Where(o => o.Id > g1.Id))
                {
                    long d = GetDistance(g1, g2);
                    distance += d;
                }
            }
            return distance;
        }

        protected void AdjustCoord()
        {
            for (long i = 0; i < size; i++)
            {
                if (!galaxies.Any(o => o.Coord.X == i))
                    colsNoGalaxies.Add(i);

                if (!galaxies.Any(o => o.Coord.Y == i))
                    rowsNoGalaxies.Add(i);
            }

            foreach (var g in galaxies)
            {
                foreach (long y in rowsNoGalaxies)
                {
                    if (g.Coord.Y > y)
                        g.ModifY += Expanding;
                }

                foreach (long x in colsNoGalaxies)
                {
                    if (g.Coord.X > x)
                        g.ModifX += Expanding;
                }
            }
        }

        protected virtual long Expanding => 1;

        protected long GetDistance(Galaxy a, Galaxy b)
        {
            return Math.Abs((a.Coord.X + a.ModifX) - (b.Coord.X + b.ModifX))
                + Math.Abs((a.Coord.Y + a.ModifY) - (b.Coord.Y + b.ModifY));
        }

        protected List<Galaxy> GetGalaxies(List<string> lines)
        {
            int id = 0;
            List<Galaxy> galaxies = new();
            int y = 0;
            foreach (var line in lines)
            {
                int x = 0;
                foreach (char c in line)
                {
                    if (c == '#')
                        galaxies.Add(new Galaxy(++id, new Coord(x, y)));
                    x++;
                }
                y++;
            }
            return galaxies;
        }

    }
}
