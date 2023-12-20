using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;
using static AdventOfCode2023.Day15.Day15Part2Solver;


namespace AdventOfCode2023.Day18
{
    public abstract class Day18BaseSolver : IPartSolver
    {
        int minX = 0;
        int maxX = 0;

        int minY = 0;
        int maxY = 0;

        HashSet<(int x, int y)> map;
        HashSet<(int x, int y)> outside;

        private void SetMinMax()
        {
            minX = map.Min(o => o.x);
            maxX = map.Max(o => o.x);

            minY = map.Min(o => o.y);
            maxY = map.Max(o => o.y);
        }

        private void Print(HashSet<(int x, int y)> analyzed = null)
        {
            return;
            List<(int x, int y)> list = new(map);
            if (analyzed != null)
                list.AddRange(analyzed);


            ConsoleWritter.WriteLine("");
            for (int y = maxY; y >= minY; y--)
            {
                for (int x = minX - 1; x <= maxX; x++)
                {
                    var exists = list.Contains((x, y));
                    if (exists)
                        ConsoleWritter.Write("#", ConsoleColor.Green);
                    else
                        ConsoleWritter.Write(".");
                }
                ConsoleWritter.WriteLine("");
            }
        }

        private HashSet<(int x, int y)> OrderDict(Dictionary<(int x, int y), string> dict)
        {
            HashSet<(int x, int y)> order = new();

            while (order.Count != dict.Count)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    for (int x = minX; x <= maxX; x++)
                    {
                        if (dict.ContainsKey((x, y)) && !order.Contains((x, y)))
                        {
                            order.Add((x, y));
                            break;
                        }

                    }
                }
            }


            return order;
        }

        private void FillInside()
        {
            outside = new();

            int previousOutside = -1;

            while (previousOutside < outside.Count)
            {
                previousOutside = outside.Count;
                for (int x = minX - 1; x <= maxX + 1; x++)
                {
                    for (int y = minY - 1; y <= maxY + 1; y++)
                    {
                        (int x, int y) loc = (x, y);
                        if (map.Contains(loc))
                            continue;
                        if (outside.Contains(loc))
                            continue;

                        bool added = CheckOutside(loc);
                        if(added)
                        {
                            x = x - 1;
                            y = y - 1;
                        }
                    }
                }

            }

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    (int x, int y) loc = (x, y);
                    if (!outside.Contains(loc))
                    {
                        map.Add(loc);
                    }
                }
            }

        }

        private bool CheckOutside((int x, int y) loc)
        {

            if (outside.Contains(loc))
                return false;

            if (loc.x < minX || loc.x > maxX || loc.y < minY || loc.y > maxY)
            {
                outside.Add(loc);
                return false;
            }

            if (map.Contains(loc))
            {
                return false;
            }

            (int x, int y) right = (loc.x + 1, loc.y);
            (int x, int y) left = (loc.x - 1, loc.y);
            (int x, int y) up = (loc.x, loc.y + 1);
            (int x, int y) down = (loc.x, loc.y - 1);

            if (outside.Contains(right))
            {
                outside.Add(loc);
                return true;
            }

            if (outside.Contains(left))
            {
                outside.Add(loc);
                return true;
            }

            if (outside.Contains(up))
            {
                outside.Add(loc);
                return true;
            }

            if (outside.Contains(down))
            {
                outside.Add(loc);
                return true;
            }

            return false;
        }

        private HashSet<(int x, int y)> DoTrench(List<Instruction> instructions)
        {
            HashSet<(int x, int y)> map = new();

            (int x, int y) location = (0, 0);

            map.Add(location);
            foreach (var i in instructions)
            {
                for (int repeat = 0; repeat < i.Size; repeat++)
                {
                    (int x, int y) move = i.Dir switch
                    {
                        Direction.Left => (-1, 0),
                        Direction.Right => (1, 0),
                        Direction.Up => (0, 1),
                        Direction.Down => (0, -1)
                    };

                    location = (location.x + move.x, location.y + move.y);
                    map.Add(location);
                }
            }

            return map;
        }

        private List<Instruction> GetInstructions(List<string> lines)
        {
            List<Instruction> list = new();
            foreach (var line in lines)
            {
                list.Add(ParseInstructionLine(line));
            }
            return list;
        }

        protected abstract Instruction ParseInstructionLine(string line);

        public abstract string Solve(List<string> lines);

        public string Run(List<string> lines)
        {
            var instructions = GetInstructions(lines);
            map = DoTrench(instructions);
            SetMinMax();
            Print();
            FillInside();
            Print();

            return map.Count.ToString();
        }
    }
}
