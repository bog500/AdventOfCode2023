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

        protected HashSet<Pipe> outside = new();
        protected HashSet<Pipe> mainLoop = new();

        protected Pipe start;

        protected int mazeMaxX;
        protected int mazeMaxY;

        public abstract string Solve(List<string> line);

        protected void CreateMaze(List<string> lines)
        {
            maze = new();
            mainLoop = new();
            outside = new();

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
                mazeMaxX = x-1;
                y++;
            }
            mazeMaxY = y-1;
        }

        protected void SetStart()
        {
            start.IsStart = true;

            bool right  = start.Coord.X < mazeMaxX && maze[start.Coord.MoveRight()].Moves.ConnectLeft;
            bool bottom = start.Coord.Y < mazeMaxY && maze[start.Coord.MoveBottom()].Moves.ConnectTop;
            bool left   = start.Coord.X > 0 && maze[start.Coord.MoveLeft()].Moves.ConnectRight;
            bool top    = start.Coord.Y > 0 && maze[start.Coord.MoveTop()].Moves.ConnectBottom;

            char c = (right, bottom, left, top) switch
            {
                (false, true, false, true) => '|',
                (true, false, true, false) => '-',
                (true, false, false, true) => 'L',
                (false, false, true, true) => 'J',
                (false, true, true, false) => '7',
                (true, true, false, false) => 'F',
                (false, false, false, false) => '.',
            };

            start.SetSymbol(c);
        }

        protected void CheckMainLoop()
        {
            Pipe current = start;
            mainLoop.Clear();
            do
            {
                mainLoop.Add(current);
                current = GetNext(current);
            } while (current.Coord != start.Coord && !mainLoop.Contains(current));
        }

        private Pipe GetNext(Pipe current)
        {
            Pipe? dest = null;

            if (HasVisited(dest) && current.Moves.ConnectLeft)
                dest = maze[current.Coord.MoveLeft()];
            if (HasVisited(dest) && current.Moves.ConnectRight)
                dest = maze[current.Coord.MoveRight()];
            if (HasVisited(dest) && current.Moves.ConnectTop)
                dest = maze[current.Coord.MoveTop()];
            if (HasVisited(dest) && current.Moves.ConnectBottom)
                dest = maze[current.Coord.MoveBottom()];

            return dest!.Value;
        }

        private bool HasVisited(Pipe? dest)
        {
            if (!dest.HasValue)
                return true;

            if (mainLoop.Contains(dest.Value))
                return true;

            return false;
        }

        protected void Print()
        {
            StringBuilder sb = new();
            for (int y = 0; y <= mazeMaxY; y++)
            {
                for (int x = 0; x <= mazeMaxX; x++)
                {
                    Coord c = new Coord(x, y);
                    if (mainLoop.Contains(maze[c]))
                        sb.Append(maze[c].Printable);
                    else if (!outside.Contains(maze[c]))
                        sb.Append('░');
                    else
                        sb.Append('.');
                }
                sb.Append(Environment.NewLine);
            }
            using (StreamWriter outputFile = new StreamWriter(Path.Combine("Day10", "Day10.txt")))
            {
                outputFile.Write(sb.ToString());
            }
        }
    }
}
