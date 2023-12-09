using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Common
{
    public struct Coord(int x, int y)
    {
        public int X => x;
        public int Y => y;
    }

    public struct Coord3D(int x, int y, int z)
    {
        public int X => x;
        public int Y => y;
        public int Z => z;
    }
}
