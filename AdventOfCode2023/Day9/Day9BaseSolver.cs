using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day9
{
    public abstract class Day9BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        public string BaseSolve(List<string> lines)
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
                AddZero(ref map);
                Expand(ref map, map.Level - 1);
                total += GetMapValue(map);
            }
            return total.ToString();
        }

        protected abstract void AddZero(ref OasisMap map);
        protected abstract void Expand(ref OasisMap map, int level);
        protected abstract int GetMapValue(OasisMap map);

        protected void CompleteMap(ref OasisMap map)
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

        protected bool IsCompleted(OasisMap map)
        {
            int maxLevel = map.Level;
            var lastRow = map.Oasis.Where(o => o.Key.Y == maxLevel).Select(o => o.Value).ToList();
            return lastRow.All(o => o == 0);
        }
    }
}
