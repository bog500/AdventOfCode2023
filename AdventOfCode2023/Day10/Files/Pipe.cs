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
            '|' => new Move(connectRight: false, connectBottom: true, connectLeft: false, connectTop: true),
            '-' => new Move(connectRight: true, connectBottom: false, connectLeft: true, connectTop: false),
            'L' => new Move(connectRight: true, connectBottom: false, connectLeft: false, connectTop: true),
            'J' => new Move(connectRight: false, connectBottom: false, connectLeft: true, connectTop: true),
            '7' => new Move(connectRight: false, connectBottom: true, connectLeft: true, connectTop: false),
            'F' => new Move(connectRight: true, connectBottom: true, connectLeft: false, connectTop: false),
            _ => new Move(connectRight: false, connectBottom: false, connectLeft: false, connectTop: false),
        };

        public char Printable => Symbol switch
        {
            '|' => '│',
            '-' => '─',
            'L' => '└',
            'J' => '┘',
            '7' => '┐',
            'F' => '┌',
            _ => 'X',
        };

        public static bool operator ==(Pipe a, Pipe b) => a.Coord == b.Coord;
        public static bool operator !=(Pipe a, Pipe b) => !(a==b);

    }

    public struct Move(bool connectRight, bool connectBottom, bool connectLeft, bool connectTop)
    {
        public bool ConnectRight => connectRight;
        public bool ConnectBottom => connectBottom;
        public bool ConnectLeft => connectLeft;
        public bool ConnectTop => connectTop;
    }
}
