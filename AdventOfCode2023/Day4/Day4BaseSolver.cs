using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day4
{
    public abstract class Day4BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        protected Dictionary<int, Card> Parse(List<string> lines)
        {
            Dictionary<int, Card> cards = new();

            foreach(string line in lines)
            {
                Card card = ParseCard(line);
                cards.Add(card.Id, card);
            }

            return cards;
        }

        private Card ParseCard(string line)
        {
            string[] parts = line.Split(':', '|');

            int id = int.Parse(parts[0].Split(' ').Last());

            HashSet<int> winning = GetNumbers(parts[1]);
            HashSet<int> played = GetNumbers(parts[2]);

            Card c = new Card(id, winning, played);
            return c;
        }

        private HashSet<int> GetNumbers(string s) => s.Split(' ')
            .Where(o => !string.IsNullOrWhiteSpace(o))
            .Select(o => int.Parse(o.Trim()))
            .ToHashSet();
    }
}
