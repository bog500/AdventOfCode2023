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
    public class Day10Part1Solver : Day10BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            CreateMaze(lines);
            SetStart();
            var steps = CountSteps();

            return steps.ToString();
        }

        public int CountSteps()
        {
            int nb = 0;
            Pipe current = start;
            visit.Clear();
            do
            {
                visit.Add(current);
                current = GetNext(current);
                nb++;
            } while (current.Coord != start.Coord && !visit.Contains(current)) ;

            return nb/2;
        }

        private Pipe GetNext(Pipe current)
        {
            Pipe? dest = null;

            if (HasVisited(dest) && current.Moves.Left)
                dest = maze[new Coord(current.Coord.X - 1, current.Coord.Y)];
            if (HasVisited(dest) && current.Moves.Right)
                dest = maze[new Coord(current.Coord.X + 1, current.Coord.Y)];
            if (HasVisited(dest) && current.Moves.Top)
                dest = maze[new Coord(current.Coord.X, current.Coord.Y - 1)];
            if (HasVisited(dest) && current.Moves.Bottom)
                dest = maze[new Coord(current.Coord.X, current.Coord.Y + 1)];

            return dest!.Value;
        }

        private bool HasVisited(Pipe? dest)
        {
            if (!dest.HasValue)
                return true;

            if (visit.Contains(dest.Value))
                return true;

            return false;
        }
    }
}
