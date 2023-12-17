using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;
using static AdventOfCode2023.Day15.Day15Part2Solver;


namespace AdventOfCode2023.Day16
{
    public class BeamSimulator(char[,] layout, List<Beam> beams)
    {
        char[,] energy;

        int maxX = 0;
        int maxY = 0;

        HashSet<(int, int, Direction)> locations = new();

        private void Init()
        {
            maxX = layout.GetLength(0) - 1;
            maxY = layout.GetLength(1) - 1;

            energy = new char[maxX + 1, maxY + 1];
            locations = new();

            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    energy[x, y] = '.';
                    x++;
                }
            }
        }

        public void Simulate()
        {
            Init();

            while (beams.Any())
            {
                List<Beam> beamsToDelete = new();
                List<Beam> beamsToAdd = new();
                for (int i = 0; i < beams.Count; i++)
                {
                    Beam b = beams[i];
                    (int X, int Y) newCoord = b.Direction switch
                    {
                        Direction.Up => (b.Coord.X, b.Coord.Y - 1),
                        Direction.Down => (b.Coord.X, b.Coord.Y + 1),
                        Direction.Left => (b.Coord.X - 1, b.Coord.Y),
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

                int nbLocation = locations.Count;

                foreach (var b in beams)
                {
                    locations.Add((b.Coord.X, b.Coord.Y, b.Direction));
                }

                beams = beams.Except(beamsToDelete).ToList();

                foreach (var b in beamsToAdd)
                {
                    var key = ((b.Coord.X, b.Coord.Y, b.Direction));
                    if(!locations.Contains(key))
                    {
                        beams.Add(b);
                        locations.Add(key);
                    }
                }

                // no new location were found in this round
                if (nbLocation == locations.Count)
                    break;
            }
        }

        public int GetEnergized()
        {
            var list = energy.Cast<char>().ToList();
            int countEnergized = list.Count(o => o == '#');
            return countEnergized;
        }
    }
}
