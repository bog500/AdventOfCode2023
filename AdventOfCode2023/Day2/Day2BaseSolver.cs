using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day2
{
    public abstract class Day2BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> line);

        protected List<Game> GetGames(List<string> lines)
        {
            List<Game> games = new();
            foreach (var line in lines)
            {
                Game g = ParseGame(line);
                games.Add(g);
            }
            return games;
        }

        private Game ParseGame(string s)
        {
            int gameNum = int.Parse(s.Split(':')[0].Replace("Game ", ""));
            var setParts = (s.Split(':')[1]).Split(';');
            List<Set> sets = new();
            foreach(var setPart in setParts)
            {
                Set set = ParseSet(setPart);
                sets.Add(set);
            }
            Game g = new Game()
            {
                Id = gameNum,
                Sets = sets
            };

            return g;
        }

        private Set ParseSet(string s)
        {
            Set set = new();
            var subs = s.Split(',');
            foreach(var sub in subs)
            {
                var parts = sub.Trim().Split(' ');
                int n = int.Parse(parts[0]);
                string color = parts[1];
                switch(color)
                {
                    case "blue":
                        set.Blue = n;
                        break;

                    case "red":
                        set.Red = n;
                        break;

                    case "green":
                        set.Green = n;
                        break;
                }
            }
            return set;
        }

    }
}
