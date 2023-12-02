using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day2
{
    public class Day2Part1Solver : Day2BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            List<Game> games = GetGames(lines);

            int total = 0;
            foreach(var game in games)
            {
                if (!game.Sets.Any(o =>
                       o.Red > 12
                    || o.Green > 13
                    || o.Blue > 14
                    ))
                    total += game.Id;
            }
            return total.ToString();
        }

    }
}
