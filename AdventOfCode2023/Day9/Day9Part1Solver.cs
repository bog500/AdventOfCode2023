using AdventOfCode2023.Common;


namespace AdventOfCode2023.Day9
{
    public class Day9Part1Solver : Day9BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            return base.BaseSolve(lines);
        }

        protected override void AddZero(ref OasisMap map)
        {
            int maxLevel = map.Level;
            var lastRowCount = map.CountInRow(maxLevel);
            map.Oasis.Add(new Coord(lastRowCount, maxLevel), 0);
        }

        protected override void Expand(ref OasisMap map, int level)
        {
            if (level == -1)
                return;

            var rowCount = map.CountInRow(level);
            int newValue = map.Oasis[new Coord(rowCount-1, level)] + map.Oasis[new Coord(rowCount-1, level+1)];
            map.Oasis.Add(new Coord(rowCount, level), newValue);

            Expand(ref map, level - 1);
        }

        protected override int GetMapValue(OasisMap map)
        {
            var rowCount = map.CountInRow(0);
            return map.Oasis[new Coord(rowCount - 1, 0)];
        }
    }


}
