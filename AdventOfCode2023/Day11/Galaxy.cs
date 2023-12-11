using AdventOfCode2023.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day11
{
    public class Galaxy(int id, Coord c)
    {
        public int Id => id;
        public Coord Coord => c;

        public long ModifX = 0;

        public long ModifY = 0;
    }
}
