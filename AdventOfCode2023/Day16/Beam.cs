using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.Day16
{
    public record Beam
    {
        public (int X, int Y) Coord;
        public Direction Direction;

        public Beam((int x, int y) coord, Direction direction)
        {
            this.Coord = coord;
            this.Direction = direction;
        }
    }
}
