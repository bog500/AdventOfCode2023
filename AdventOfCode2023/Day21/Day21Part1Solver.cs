using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Day15.Day15Part2Solver;

namespace AdventOfCode2023.Day21
{
    public class Day21Part1Solver : Day21BaseSolver
    {
        char[,] map;
        int[,] visited;

        int rows;
        int cols;

        int maxSteps = 0;

        public override string Solve(List<string> lines)
        {
            (int x, int y)  start = Init(lines);
            Print();
            Visit(start.x, start.y, 0);
            Print();
            int total = Count();
            return total.ToString();
        }

        protected int Count()
        {
            int total = 0;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (visited[x, y] >= 0 && visited[x, y] < int.MaxValue && visited[x, y] % 2 == 0)
                        total++;
                }
            }
            return total;
        }

        protected void Print()
        {
            return;
            ConsoleWritter.WriteLine("");

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++) 
                {
                    if (map[x, y] == 'S')
                        ConsoleWritter.Write("S", ConsoleColor.Green);
                    else if (visited[x, y] >= 0 && visited[x, y] < int.MaxValue && visited[x, y] % 2 == 0)
                        ConsoleWritter.Write("O", ConsoleColor.Yellow);
                    else if (visited[x, y] >= 0 && visited[x, y] < int.MaxValue && visited[x, y] % 2 == 1)
                        ConsoleWritter.Write("O", ConsoleColor.DarkYellow);
                    else if (map[x,y] == '#')
                        ConsoleWritter.Write("#", ConsoleColor.Cyan);
                    else
                        ConsoleWritter.Write(".", ConsoleColor.DarkGray);
                }
                ConsoleWritter.WriteLine("");
            }
            ConsoleWritter.WriteLine("");
        }

        protected (int x, int y) Init(List<string> lines)
        {
            (int x, int y) start = (0,0);

            map = Parser.GetLayout(lines);

            rows = lines.Count;
            cols = lines[0].Length;

            // 6 for demo map
            // 64 for real map
            maxSteps = rows < 20 ? 6 : 64;

            visited = new int[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (map[x, y] == '#')
                        visited[x, y] = -1;
                    else
                        visited[x, y] = int.MaxValue;

                    if (map[x, y] == 'S')
                        start = (x, y);
                }
            }

            return start;
        }

        protected void Visit(int x, int y, int steps)
        {
            // too many steps
            if (steps > maxSteps)
                return;
            
            // out of bound
            if (x < 0 || y < 0 || x >= cols || y >= rows)
                return;

            // Rock
            if (map[x, y] == '#')
                return;

            // already  visited more quickly
            if (visited[x, y] <= steps)
                return;

            visited[x, y] = steps;

            int nextSteps = steps + 1;

            Visit(x + 1, y, nextSteps);
            Visit(x - 1, y, nextSteps);
            Visit(x, y + 1, nextSteps);
            Visit(x, y - 1, nextSteps);
        }
    }
}
