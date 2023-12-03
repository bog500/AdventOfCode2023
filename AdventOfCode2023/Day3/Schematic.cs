using AdventOfCode2023.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day3
{
    public abstract class Schematic
    {
        public string Symbol { get; set; }

        public Coord Coord { get; set; }

        public int StartX => Coord.X;

        public int EndX => StartX + Symbol.Length - 1;
    }
}
