﻿using AdventOfCode2023.Common;
using AdventOfCode2023.Day10.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;


namespace AdventOfCode2023.Day17
{
    public class Day17Part1Solver : Day17BaseSolver
    {
        int[,] layout;

        int[,] bests;

        int maxX = 0;
        int maxY = 0;

        int maxVisit = 0;

        int best = 0;

        ulong nbCheck = 0;

        Coord destination;

        Random r = new();

        List<Task<bool>> tasks = new();


        public override string Solve(List<string> lines)
        {
            layout = Parser.GetIntLayout(lines);

            StartMove();

            return best.ToString();
        }

        private void ResetBestLayout()
        {
            bests = new int[maxX + 1, maxY + 1];
            for(int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    bests[x, y] = best;
                }
            }
        }

        private void StartMove()
        {
            HashSet<Coord> visitedCoords = new();
            List<Direction> lastThreeDir = new();
            
            maxX = layout.GetLength(0) - 1;
            maxY = layout.GetLength(1) - 1;


            maxVisit = 2*maxX + 2*maxY;

            best = 91200;

            ResetBestLayout();

            Coord startLocation = new Coord(maxX, maxY); 
            destination = new Coord(0, 0);

            int heat = layout[startLocation.X, startLocation.Y];

            visitedCoords.Add(startLocation);

            Move(visitedCoords, lastThreeDir, startLocation, Direction.Left, heat, [Direction.Left, Direction.Up, Direction.Down, Direction.Right]);
        }

        private IEnumerable<Direction[]> Permutate<Direction>(IEnumerable<Direction> source)
        {
            return permutate(source, Enumerable.Empty<Direction>());
            IEnumerable<Direction[]> permutate(IEnumerable<Direction> reminder, IEnumerable<Direction> prefix) =>
                !reminder.Any() ? new[] { prefix.ToArray() } :
                reminder.SelectMany((c, i) => permutate(
                    reminder.Take(i).Concat(reminder.Skip(i + 1)).ToArray(),
                    prefix.Append(c)));
        }

        private void Move(HashSet<Coord> visitedCoords, List<Direction> lastDir, Coord location, Direction dir, int heat, Direction[] priority)
        {
            nbCheck++;
            if (nbCheck % 1000000000 == 0)
            {
                ConsoleWritter.Write(nbCheck + " checked with best=");
                ConsoleWritter.WriteLine(best, color: ConsoleColor.Red);
            }
      

            if (visitedCoords.Count > maxVisit)
                return;

            //4 last moves in same direction
            var lastDirection = ListDirections(lastDir, dir);
            if (lastDirection.Count() == 4 && lastDirection.Distinct().Count() == 1)
                return;

            var newLocation = dir switch
            {
                Direction.Up => new Coord(location.X, location.Y - 1),
                Direction.Right => new Coord(location.X + 1, location.Y),
                Direction.Down => new Coord(location.X, location.Y + 1),
                Direction.Left => new Coord(location.X - 1, location.Y)
            };

            //outside layout
            if (newLocation.X < 0 || newLocation.Y < 0 || newLocation.X > maxX || newLocation.Y > maxY)
                return;

            //already visited in this loop
            if (visitedCoords.Contains(newLocation))
                return;


            // destination found
            if(newLocation == destination)
            {
                if (heat < best)
                {
                    best = heat;
                    Print(best, visitedCoords);
                    foreach(var c in visitedCoords)
                    {
                        bests[c.X, c.Y] = best;
                    }
                }
                return;
            }

            

            int destHeat = layout[newLocation.X, newLocation.Y];
            //if (destHeat > 7)
            //    return false;

            int newHeat = heat + destHeat;


            // already too bad
            if (newHeat > best)
                return;

            if (bests[newLocation.X, newLocation.Y] < newHeat)
                return;

            // impossible even with all 2
            // do -10 just in case
            if (newHeat + (newLocation.X*2 + newLocation.Y*2) - 10> best)
            return;

            HashSet<Coord> newVisitedCoords = new(visitedCoords);
            newVisitedCoords.Add(newLocation);

            //Print(newHeat, newVisitedCoords);
            foreach(var nextDir in priority.OrderBy(o => r.Next()))
            {
                Move(newVisitedCoords, lastDirection, newLocation, nextDir, newHeat, priority);
            }
                
            return;
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
