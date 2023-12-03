using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day3
{
    public class Day3Part1Solver : Day3BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            var list = Parse(lines);

            var touching = Touching(list);

            int total = touching.Sum(o => o.Number);

            return total.ToString();
        }

        private List<SchematicNumber> Touching(List<Schematic> sch)
        {
            List<SchematicNumber> list = new();

            List<SchematicSymbol> symbols = sch.OfType<SchematicSymbol>().ToList();

            foreach (SchematicNumber part in sch.OfType<SchematicNumber>())
            {
                if(symbols.Any(symb =>
                   symb.Coord.X >= part.StartX-1
                && symb.Coord.X <= part.EndX+1
                && symb.Coord.Y >= part.Coord.Y-1
                && symb.Coord.Y <= part.Coord.Y+1
                ))
                    list.Add(part);
            }

            return list;
        }

    }
}
