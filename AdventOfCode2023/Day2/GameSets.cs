using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day2
{
    public struct Game
    {
        public int Id { get; set; }
        public List<Set> Sets { get; set; }

        public int MinRed => Sets.Select(o => o.Red).Max();
        public int MinBlue => Sets.Select(o => o.Blue).Max();
        public int MinGreen => Sets.Select(o => o.Green).Max();

        public int Power => MinRed * MinBlue * MinGreen;
    }

    public struct Set
    {
        public int Red { get; set; }
        public int Blue { get; set; }
        public int Green { get; set; }
    }
}
