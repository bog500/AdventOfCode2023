using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day2
{
    public class Day2Part2Solver : Day2BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            List<Game> games = GetGames(lines);

            int total = games.Sum(o => o.Power);

            return total.ToString();
        }
    }
}
