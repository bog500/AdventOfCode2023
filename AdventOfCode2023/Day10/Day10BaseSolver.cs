using AdventOfCode2023.Common;
using AdventOfCode2023.Day10.Files;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day10
{
    public abstract class Day10BaseSolver : IPartSolver
    {
        protected Dictionary<Coord, Pipe> maze = new();

        protected HashSet<Pipe> visit = new();

        protected Pipe start;

        protected int mazeMaxX;
        protected int mazeMaxY;

        public abstract string Solve(List<string> line);

        protected void CreateMaze(List<string> lines)
        {
            int y = 0;
            foreach(var line in lines)
            {
                int x = 0;
                foreach(var c in line)
                {
                    Coord coord = new Coord(x, y);

                    Pipe p = new Pipe(c, coord);
                    if (c == 'S')
                        start = p;

                    maze.Add(coord, p);
                    x++;
                }
                mazeMaxX = x;
                y++;
            }
            mazeMaxY = y;
        }

        protected void SetStart()
        {
            start.IsStart = true;

            bool right  = start.Coord.X < mazeMaxX && maze[new Coord(start.Coord.X + 1, start.Coord.Y)].Moves.Left;
            bool bottom = start.Coord.Y < mazeMaxY && maze[new Coord(start.Coord.X, start.Coord.Y + 1)].Moves.Top;
            bool left   = start.Coord.X > 0 && maze[new Coord(start.Coord.X - 1, start.Coord.Y)].Moves.Right;
            bool top    = start.Coord.Y > 0 && maze[new Coord(start.Coord.X, start.Coord.Y - 1)].Moves.Bottom;

            char c = (right, bottom, left, top) switch
            {
                (false, true, false, true) => '|',
                (true, false, true, false) => '-',
                (true, false, false, true) => 'L',
                (false, false, true, true) => 'J',
                (false, true, true, false) => '7',
                (true, true, false, false) => 'F',  
            };

            start.SetSymbol(c);
        }

    }
}
