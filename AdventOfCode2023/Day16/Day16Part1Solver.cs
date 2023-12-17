using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
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

    public class Day16Part1Solver : Day16BaseSolver
    {
        protected char[,] layout;
        protected char[,] energy;

        int maxX = 0;
        int maxY = 0;

        List<Beam> beams = new List<Beam>();

        public override string Solve(List<string> lines)
        {
            Init(lines);

            Simulate();

            var list = energy.Cast<char>().ToList();
            int countEnergized = list.Count(o => o == '#');

            return countEnergized.ToString();
        }

        protected void Simulate()
        {
            int simulation = 0;
            while(beams.Any() && simulation < 1000)
            {
                simulation++;
                List<Beam> beamsToDelete = new();
                List<Beam> beamsToAdd = new();
                for(int i = 0; i < beams.Count; i++)
                {
                    Beam b = beams[i];
                    (int X, int Y) newCoord = b.Direction switch
                    {
                        Direction.Up    => (b.Coord.X, b.Coord.Y - 1),
                        Direction.Down  => (b.Coord.X, b.Coord.Y + 1),
                        Direction.Left  => (b.Coord.X - 1, b.Coord.Y),
                        Direction.Right => (b.Coord.X + 1, b.Coord.Y),
                    };
                    if (newCoord.X < 0 || newCoord.Y < 0 || newCoord.X > maxX || newCoord.Y > maxY)
                    {
                        beamsToDelete.Add(b);
                        continue;
                    }

                    b.Coord = newCoord;

                    energy[b.Coord.X, b.Coord.Y] = '#';

                    switch (layout[b.Coord.X, b.Coord.Y], b.Direction)
                    {
                        case ('\\', Direction.Up):
                            b.Direction = Direction.Left;
                            break;

                        case ('\\', Direction.Left):
                            b.Direction = Direction.Up;
                            break;

                        case ('\\', Direction.Right):
                            b.Direction = Direction.Down;
                            break;

                        case ('\\', Direction.Down):
                            b.Direction = Direction.Right;
                            break;


                        // #################################

                        case ('/', Direction.Up):
                            b.Direction = Direction.Right;
                            break;

                        case ('/', Direction.Right):
                            b.Direction = Direction.Up;
                            break;

                        case ('/', Direction.Down):
                            b.Direction = Direction.Left;
                            break;

                        case ('/', Direction.Left):
                            b.Direction = Direction.Down;
                            break;

                        // #################################

                        case ('|', Direction.Right):
                        case ('|', Direction.Left):
                            b.Direction = Direction.Up;
                            beamsToAdd.Add(new Beam(b.Coord, Direction.Down));
                            break;

                        // #################################

                        case ('-', Direction.Up):
                        case ('-', Direction.Down):
                            b.Direction = Direction.Left;
                            beamsToAdd.Add(new Beam(b.Coord, Direction.Right));
                            break;

                        // #################################

                        case ('|', Direction.Up):
                        case ('|', Direction.Down):
                        case ('-', Direction.Right):
                        case ('-', Direction.Left):
                        case ('.', _):
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                        
                }

                beams = beams.Except(beamsToDelete).ToList();
                beams.AddRange(beamsToAdd);

            }
        }

        protected void Init(List<string> lines)
        {
            int rows = lines.Count;
            int cols = lines[0].Length;

            maxX = cols - 1;
            maxY = rows - 1;

            layout = new char[cols, rows];
            energy = new char[cols, rows];

            int y = 0;
            foreach(var line in lines)
            {
                int x = 0;
                foreach(char c in line)
                {
                    layout[x, y] = c;
                    energy[x, y] = '.';
                    x++;
                }
                y++;
            }

            beams = new List<Beam>()
            {
                new Beam((-1, 0), Direction.Right)
            };

        }
    }
}
