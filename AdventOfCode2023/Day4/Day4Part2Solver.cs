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
        // Card Id, Card
        Dictionary<int, Card> cards;

        public override string Solve(List<string> lines)
        {
            cards = base.Parse(lines);
            cardWins = new();

            foreach (var card in cards.Values)
            {
                GetTotalCardCount(card);
            }

            int total = cardWins.Sum(o => o.Value);
            return total.ToString();
        }

        Dictionary<int, int> cardWins = new();
        private int GetTotalCardCount(Card card)
        {
            if(cardWins.ContainsKey(card.Id))
            {
                return cardWins[card.Id];
            }

            int totalWinCard = 1;
            int nbCards = card.WinCount;
            for (int i = 1; i <= nbCards; i++)
            {
                int nextId = card.Id + i;
                if (cards.ContainsKey(nextId))
                {
                    Card nextCard = cards[nextId];
                    totalWinCard += GetTotalCardCount(nextCard);
                }
            }
            cardWins.Add(card.Id, totalWinCard);
            return totalWinCard;
        }
    }
}
