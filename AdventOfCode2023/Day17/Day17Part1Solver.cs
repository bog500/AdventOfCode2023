using AdventOfCode2023.Common;
using AdventOfCode2023.Day10.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;


namespace AdventOfCode2023.Day17
{
    public class Day17Part1Solver : Day17BaseSolver
    {
        int[,] layout;

        int maxX = 0;
        int maxY = 0;

        int maxVisit = 0;

        int best = 0;

        Coord destination;

        public override string Solve(List<string> lines)
        {
            layout = Parser.GetIntLayout(lines);

            StartMove();

            return best.ToString();
        }

        private void StartMove()
        {
            HashSet<Coord> visitedCoords = new();
            List<Direction> lastThreeDir = new();
            
            maxX = layout.GetLength(0) - 1;
            maxY = layout.GetLength(1) - 1;

            maxVisit = maxX * maxY / 4;

            best = 1200;

            Coord startLocation = new Coord(maxX, maxY); 
            destination = new Coord(0, 0);

            int heat = layout[startLocation.X, startLocation.Y];

            visitedCoords.Add(startLocation);

            var left = Move(visitedCoords, lastThreeDir, startLocation, Direction.Left, heat);
            var up = Move(visitedCoords, lastThreeDir, startLocation, Direction.Up, heat);

            Task.WhenAll([left, up]);

        }

        private async Task<bool> Move(HashSet<Coord> visitedCoords, List<Direction> lastDir, Coord location, Direction dir, int heat)
        {
            await Task.Delay(0);
            if (visitedCoords.Count > maxVisit)
                return false;

            //4 last moves in same direction
            var lastDirection = ListDirections(lastDir, dir);
            if (lastDirection.Count() == 4 && lastDirection.Distinct().Count() == 1)
                return false;

            var newLocation = dir switch
            {
                Direction.Up => new Coord(location.X, location.Y - 1),
                Direction.Right => new Coord(location.X + 1, location.Y),
                Direction.Down => new Coord(location.X, location.Y + 1),
                Direction.Left => new Coord(location.X - 1, location.Y)
            };

            //outside layout
            if (newLocation.X < 0 || newLocation.Y < 0 || newLocation.X > maxX || newLocation.Y > maxY)
                return false;

            //already visited in this loop
            if (visitedCoords.Contains(newLocation))
                return false;


            // destination found
            if(newLocation == destination)
            {
                if (heat < best)
                {
                    best = heat;
                    Print(best, visitedCoords);
                }
                return true;
            }

            int destHeat = layout[newLocation.X, newLocation.Y];
            if (destHeat > 7)
                return false;

            int newHeat = heat + destHeat;


            // already too bad
            if (newHeat > best)
                return false;

            // impossible even with all 2
            // do -10 just in case
            if (newHeat + (newLocation.X*2 + newLocation.Y*2) - 10> best)
                return false;

            HashSet<Coord> newVisitedCoords = new(visitedCoords);
            newVisitedCoords.Add(newLocation);


            int heatUp = GetHeat(newLocation, Direction.Up).heat;
            int heatLeft = GetHeat(newLocation, Direction.Left).heat;


            if(heatUp < heatLeft)
            {
                await Move(newVisitedCoords, lastDirection, newLocation, Direction.Up, newHeat);
                await Move(newVisitedCoords, lastDirection, newLocation, Direction.Left, newHeat);
            }
            else
            {
                await Move(newVisitedCoords, lastDirection, newLocation, Direction.Left, newHeat);
                await Move(newVisitedCoords, lastDirection, newLocation, Direction.Up, newHeat);
            }
            await Move(newVisitedCoords, lastDirection, newLocation, Direction.Down, newHeat);
            await Move(newVisitedCoords, lastDirection, newLocation, Direction.Right, newHeat);

            return false;
        }

        private void Print(int heat, HashSet<Coord> visitedCoords)
        {
            ConsoleWritter.WriteLine("");
            ConsoleWritter.WriteLine("=== " + heat + " ===", ConsoleColor.Cyan);
            return;
            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    if(visitedCoords.Contains(new Coord(x,y)))
                        ConsoleWritter.Write("#", ConsoleColor.Yellow);
                    else
                        ConsoleWritter.Write(layout[x,y], ConsoleColor.DarkGreen);
                }
                ConsoleWritter.WriteLine("");
            }
        }

        private List<Direction> ListDirections(List<Direction> lastDir, Direction newDirection)
        {
            List<Direction> newList = new(lastDir);
            newList.Add(newDirection);
            if (newList.Count > 4)
                newList.RemoveAt(0);

            return newList;            
        }
        
        private (int heat, Direction dir) GetHeat(Coord location, Direction dir)
        {
            var newLocation = dir switch
            {
                Direction.Up => new Coord(location.X, location.Y - 1),
                Direction.Right => new Coord(location.X + 1, location.Y),
                Direction.Down => new Coord(location.X, location.Y + 1),
                Direction.Left => new Coord(location.X - 1, location.Y)
            };

            //outside layout
            if (newLocation.X < 0 || newLocation.Y < 0 || newLocation.X > maxX || newLocation.Y > maxY)
                return (-1, dir);

            return (layout[newLocation.X, newLocation.Y], dir);
        }
    }


}
