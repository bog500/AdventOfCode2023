using AdventOfCode2023.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day9
{
    public record OasisMap()
    {
        public int Level { get; set; } = 0;
        public Dictionary<Coord, int> Oasis = new();
        public int RowCount(int y) => Oasis.Count(o => o.Key.Y == y);
    }
}
