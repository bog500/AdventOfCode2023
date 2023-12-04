using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day4
{
    public class Day4Part2Solver : Day4BaseSolver
    {
        int NbCards = 0;

        // Card Id, Card
        Dictionary<int, Card> cards;

        public override string Solve(List<string> lines)
        {
            cards = base.Parse(lines);

            NbCards = 0;
            foreach (var card in cards.Values)
            {
                CountCards(card);
            }

            return NbCards.ToString();
        }

        private void CountCards(Card card)
        {
            NbCards++;
            int nbCards = card.WinCount;
            for(int i = 1; i <= nbCards; i++)
            {
                int nextId = card.Id + i;
                if(cards.ContainsKey(nextId))
                {
                    Card nextCard = cards[nextId];
                    CountCards(nextCard);
                }
            }
        }
    }
}
