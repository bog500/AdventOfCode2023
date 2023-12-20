using AdventOfCode2023.Common;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;


namespace AdventOfCode2023.Day18
{
    public class Day18Part1Solver : Day18BaseSolver
    {
        int minX = 0;
        int maxX = 0;

        int minY = 0;
        int maxY = 0;

        Dictionary<(int x, int y), string> map;
        HashSet<(int x, int y)> outside;

        public override string Solve(List<string> lines)
        {
            var instructions = GetInstructions(lines);
            map = DoTrench(instructions);
            SetMinMax();
            Print();
            FillInside();
            Print();

            return map.Count.ToString();
        }

        private void SetMinMax()
        {
            minX = map.Keys.Min(o => o.x);
            maxX = map.Keys.Max(o => o.x);

            minY = map.Keys.Min(o => o.y);
            maxY = map.Keys.Max(o => o.y);
        }

        public void Print(HashSet<(int x, int y)> analyzed = null)
        {
            return;
            List<(int x, int y)> list = new(map.Keys);
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

        public HashSet<(int x, int y)> OrderDict(Dictionary<(int x, int y), string> dict)
        {
            HashSet<(int x, int y)> order = new();

            while(order.Count != dict.Count)
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

        public void FillInside()
        {
            outside = new();

            int previousOutside = -1;

            while(previousOutside < outside.Count)
            {
                previousOutside = outside.Count;
                for (int x = minX-1; x <= maxX+1; x++)
                {
                    for (int y = minY-1; y <= maxY+1; y++)
                    {
                        (int x, int y) loc = (x, y);
                        if (map.ContainsKey(loc))
                            continue;
                        if (outside.Contains(loc))
                            continue;

                        CheckOutside(loc);
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
                        map.TryAdd(loc, "");
                    }
                }
            }

        }

        public void CheckOutside((int x, int y) loc)
        {
            
            if (outside.Contains(loc))
                return;

            if(loc.x < minX || loc.x > maxX || loc.y < minY || loc.y > maxY)
            {
                outside.Add(loc);
                return;
            }

            if (map.ContainsKey(loc))
            {
                return;
            }

            (int x, int y) right = (loc.x + 1 , loc.y);
            (int x, int y) left = (loc.x - 1, loc.y);
            (int x, int y) up = (loc.x , loc.y + 1);
            (int x, int y) down = (loc.x, loc.y - 1);

            if (outside.Contains(right))
            {
                outside.Add(loc);
                return;
            }

            if (outside.Contains(left))
            {
                outside.Add(loc);
                return;
            }

            if (outside.Contains(up))
            {
                outside.Add(loc);
                return;
            }

            if (outside.Contains(down))
            {
                outside.Add(loc);
                return;
            }

            return;
        }

        public Dictionary<(int x, int y), string> DoTrench(List<Instruction> instructions)
        {
            Dictionary<(int x, int y), string> dict = new();

            (int x, int y) location = (0, 0);

            dict.Add(location, "");
            foreach(var i in instructions)
            {
                for(int repeat = 0; repeat < i.Size; repeat++)
                {
                    (int x, int y) move = i.Dir switch
                    {
                        Direction.Left => (-1, 0),
                        Direction.Right => (1, 0),
                        Direction.Up => (0, 1),
                        Direction.Down => (0, -1)
                    };

                    location = (location.x + move.x, location.y + move.y);
                    dict.TryAdd(location, i.Color);
                }
            }

            return dict;
        }

        public List<Instruction> GetInstructions(List<string> lines)
        {
            List<Instruction> list = new();
            foreach (var line in lines)
            {
                list.Add(new(line));
            }
            return list;
        }

    }

    public class Instruction
    {
        public Direction Dir { get; set; }
        public byte Size { get; set; }
        public string Color { get; set; }

        public Instruction(string line)
        {
            var parts = line.Split(' ');
            Dir = parts[0] switch
            {
                "D" => Direction.Down,
                "L" => Direction.Left,
                "R" => Direction.Right,
                "U" => Direction.Up,
            };
            Size = byte.Parse(parts[1]);
            Color = parts[2];
        }
    }
}
