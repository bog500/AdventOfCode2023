using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day3
{
    public class Day3Part2Solver : Day3BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            var list = Parse(lines);

            var gears = GearRatios(list);

            int total = gears.Sum();

            return total.ToString();
        }

        private List<int> GearRatios(List<Schematic> sch)
        {
            List<int> list = new();

            List<SchematicNumber> parts = sch.OfType<SchematicNumber>().ToList();

            foreach (SchematicSymbol symb in sch.OfType<SchematicSymbol>())
            {
                if (symb.Symbol != "*")
                    continue;

                var touchingParts = parts.Where(part =>
                   symb.Coord.X >= part.StartX - 1
                && symb.Coord.X <= part.EndX + 1
                && symb.Coord.Y >= part.Coord.Y - 1
                && symb.Coord.Y <= part.Coord.Y + 1
                ).ToList();

                if (touchingParts.Count != 2)
                    continue;

                int ratio = touchingParts[0].Number * touchingParts[1].Number;
                list.Add(ratio);
            }

            return list;
        }
    }
}
