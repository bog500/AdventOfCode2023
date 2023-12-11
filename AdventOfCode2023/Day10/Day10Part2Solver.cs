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
    /// <summary>
    /// INCOMPLETE. Doesn't work.
    /// </summary>
    public class Day10Part2Solver : Day10BaseSolver
    {
        public override string Solve(List<string> lines)
        {

            CreateMaze(lines);
            SetStart();
            CheckMainLoop();

            SetOutsideStart();

            Print();

            int total = (mazeMaxX + 1) * (mazeMaxY + 1);
            int inside = total - mainLoop.Count - outside.Count;

            return inside.ToString();
        }



        private void CheckOutside(Coord c)
        {
            Pipe p = maze[c];
            if (!mainLoop.Contains(p) && !outside.Contains(p))
            {
                outside.Add(p);

                if (p.Coord.X > 0)
                    CheckOutside(p.Coord.MoveLeft());

                if (p.Coord.X < mazeMaxX-1)
                    CheckOutside(p.Coord.MoveRight());

                if (p.Coord.Y > 0)
                    CheckOutside(p.Coord.MoveTop());

                if (p.Coord.Y < mazeMaxY-1)
                    CheckOutside(p.Coord.MoveBottom());
            }
        }

        private void SetOutsideStart()
        {
            for(int x = 0;  x <= mazeMaxX; x++)
            {
                for (int y = 0; y <= mazeMaxY; y++)
                {
                    // if pipe is not on the border
                    if (!(x == 0 || y == 0 || x == mazeMaxX || y == mazeMaxY))
                        continue;

                    CheckOutside(new Coord(x, y));
                }
            }

        }
       
    }
}
