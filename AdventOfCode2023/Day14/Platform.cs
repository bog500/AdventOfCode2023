using AdventOfCode2023.Common;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day14
{
    public class Platform
    {
        public List<FixRock> FixedRocks = new();

        public List<MovableRock> MovableRocks = new();

        public HashSet<Coord> RockLocations = new();

        int totalRows = 0;
        int totalCols = 0;

        public void Cycle()
        {
            TiltNorth();
            TiltWest();
            TiltSouth();
            TiltEast();
        }

        public void TiltNorth()
        {
            foreach(var r in MovableRocks.OrderBy(o => o.Coord.Y))
            {
                int newY = r.Coord.Y - 1;
                while(newY >= 0 && !RockLocations.Contains(new Coord(r.Coord.X, newY)))
                {
                    RockLocations.Remove(r.Coord);
                    r.Coord = new Coord(r.Coord.X, newY);
                    newY = r.Coord.Y - 1;
                    RockLocations.Add(r.Coord);
                }
            }
        }

        public void TiltSouth()
        {
            foreach (var r in MovableRocks.OrderByDescending(o => o.Coord.Y))
            {
                int newY = r.Coord.Y + 1;
                while (newY < totalRows && !RockLocations.Contains(new Coord(r.Coord.X, newY)))
                {
                    RockLocations.Remove(r.Coord);
                    r.Coord = new Coord(r.Coord.X, newY);
                    newY = r.Coord.Y + 1;
                    RockLocations.Add(r.Coord);
                }
            }
        }

        public void TiltWest()
        {
            foreach (var r in MovableRocks.OrderBy(o => o.Coord.X))
            {
                int newX = r.Coord.X - 1;
                while (newX >= 0 && !RockLocations.Contains(new Coord(newX, r.Coord.Y)))
                {
                    RockLocations.Remove(r.Coord);
                    r.Coord = new Coord(newX, r.Coord.Y);
                    newX = r.Coord.X - 1;
                    RockLocations.Add(r.Coord);
                }
            }
        }

        public void TiltEast()
        {
            foreach (var r in MovableRocks.OrderByDescending(o => o.Coord.X))
            {
                int newX = r.Coord.X + 1;
                while (newX < totalCols && !RockLocations.Contains(new Coord(newX, r.Coord.Y)))
                {
                    RockLocations.Remove(r.Coord);
                    r.Coord = new Coord(newX, r.Coord.Y);
                    newX = r.Coord.X + 1;
                    RockLocations.Add(r.Coord);
                }
            }
        }


        public int GetLoad()
        {
            int total = 0;

            foreach (var r in MovableRocks.OrderBy(o => o.Coord.Y))
            {
                int rockLoad = totalRows - r.Coord.Y;
                total += rockLoad;
            }

            return total;
        }

        public void SetNbRowsCols(int cols, int rows)
        {
            this.totalCols = cols;
            this.totalRows = rows;
        }

        public void Print()
        {
            Console.WriteLine("");
            for (int y = 0; y < totalRows; y++)
            {
                for (int x = 0; x < totalCols; x++)
                    {
                    Rock? r = FixedRocks.FirstOrDefault(o => o.Coord == new Coord(x, y));
                    if(r is null)
                        Console.Write(".");
                    else if (r is FixRock)
                        Console.Write("#");
                    else if (r is MovableRock)
                        Console.Write("O");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }

    public abstract class Rock
    {
        public Coord Coord { get; set; }

        public Rock(Coord c)
        {
            this.Coord = c;
        }
    }

    public class MovableRock : Rock
    {
        public MovableRock(Coord coord) : base(coord)
        {
        }
    }

    public class FixRock : Rock
    {
        public FixRock(Coord coord) : base(coord)
        {
        }
    }
}
