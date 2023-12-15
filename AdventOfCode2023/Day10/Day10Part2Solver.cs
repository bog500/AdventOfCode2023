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

            SetOutside();

            Print();

            int total = (mazeMaxX + 1) * (mazeMaxY + 1);
            int inside = total - mainLoop.Count - outside.Count;

            return inside.ToString();
        }

        private void SetOutside()
        {
            for (int y = 0; y <= mazeMaxY; y++) 
            {
                bool isOutside = true;

                char lastCorner = '?';

                for (int x = 0; x <= mazeMaxX; x++)
                {
                    Coord c = new Coord(x, y);
                    Pipe p = maze[c];
                    if (mainLoop.Contains(p))
                    {
                        if (p.Symbol == '-')
                            continue;
                        else if (p.Symbol == '|')
                        {
                            isOutside = !isOutside;
                        }
                        else if (p.Symbol == 'J')
                        {
                            if(lastCorner == 'F')
                                isOutside = !isOutside;
                            lastCorner = 'J';
                        } 
                        else if (p.Symbol == '7')
                        {
                            if (lastCorner == 'L')
                                isOutside = !isOutside;
                            lastCorner = '7';
                        }
                        else if (p.Symbol == 'F')
                        {
                            lastCorner = 'F';
                        }
                        else if (p.Symbol == 'L')
                        {
                            lastCorner = 'L';
                        }

                    } 
                    else
                    {
                        if (isOutside)
                        {
                            if(!outside.Contains(p))
                                outside.Add(p);
                        }
                    }
                }
            }
        }

    }
}
