using AdventOfCode2023.Common;
using Microsoft.Diagnostics.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day10.Files
{
    public struct Pipe(char symbol, Coord coord) : IComparable, IEquatable<Pipe>
    {
        public bool IsStart;
        public char Symbol => symbol;

        public void SetSymbol(char c) => symbol = c;

        public int CompareTo(object? obj)
        {
            if (obj is not Pipe)
                return -1;

            Pipe pipe2 = (Pipe)obj;
            return this.Coord.CompareTo(pipe2.Coord);
        }

        public bool Equals(Pipe other)
        {
            return this == other;
        }

        public Coord Coord => coord;

        public Move Moves => Symbol switch
        {
            '|' => new Move(right: false, bottom: true, left: false, top: true),
            '-' => new Move(right: true, bottom: false, left: true, top: false),
            'L' => new Move(right: true, bottom: false, left: false, top: true),
            'J' => new Move(right: false, bottom: false, left: true, top: true),
            '7' => new Move(right: false, bottom: true, left: true, top: false),
            'F' => new Move(right: true, bottom: true, left: false, top: false),
            _ => new Move(right: false, bottom: false, left: false, top: false),
        };

        public static bool operator ==(Pipe a, Pipe b) => a.Coord == b.Coord;
        public static bool operator !=(Pipe a, Pipe b) => !(a==b);

    }

    public struct Move(bool right, bool bottom, bool left, bool top)
    {
        public bool Right => right;
        public bool Bottom => bottom;
        public bool Left => left;
        public bool Top => top;
    }
}
