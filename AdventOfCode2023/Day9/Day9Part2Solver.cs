using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using AdventOfCode2023.Day5;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace AdventOfCode2023.Day9
{
    public class Day9Part2Solver : Day9BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            int total = 0;
            foreach (string line in lines)
            {
                var numbers = Parser.ParseInt(line);
                OasisMap map = new();
                int NbNum = 0;
                foreach (var n in numbers)
                {
                    map.Oasis.Add(new Coord(NbNum, 0), n);
                    NbNum++;
                }
                CompleteMap(ref map);
                AddZeroLeft(ref map);
                ExpandLeft(ref map, map.Level - 1);
                total += FirstOasis(map);
            }
            return total.ToString();
        }

        public void CompleteMap(ref OasisMap map)
        {
            int maxLevel = map.Level;
            var lastRow = map.Oasis.Where(o => o.Key.Y == maxLevel).ToList();
            foreach (var item in lastRow[..(lastRow.Count - 1)])
            {
                int nextValue = lastRow[item.Key.X + 1].Value - item.Value;
                int nextY = maxLevel + 1;
                int nextX = item.Key.X;
                map.Oasis.Add(new Coord(nextX, nextY), nextValue);
            }
            map.Level++;
            if (IsCompleted(map))
                return;

            CompleteMap(ref map);
        }

        public void AddZeroLeft(ref OasisMap map)
        {
            int maxLevel = map.Level;
            map.Oasis.Add(new Coord(-1, maxLevel), 0);
        }

        public void ExpandLeft(ref OasisMap map, int level)
        {
            if (level == -1)
                return;

            int newValue = map.Oasis[new Coord(0, level)] - map.Oasis[new Coord(-1, level + 1)];
            map.Oasis.Add(new Coord(-1, level), newValue);

            ExpandLeft(ref map, level - 1);
        }

        public int FirstOasis(OasisMap map)
        {
            return map.Oasis[new Coord(- 1, 0)];
        }

        public bool IsCompleted(OasisMap map)
        {
            int maxLevel = map.Level;
            var lastRow = map.Oasis.Where(o => o.Key.Y == maxLevel).Select(o => o.Value).ToList();
            return lastRow.All(o => o == 0);
        }
    }

}
