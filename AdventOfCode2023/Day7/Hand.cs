using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day7
{
    public class HandPart1 : Hand
    {
        public HandPart1(string cards, int bid)
        {
            base.Cards = cards;
            base.Bid = bid;
        }

        public override int CardValue(char c) => c switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => 11,
            'T' => 10,
            _ => c - '0'
        };
    }

    public class HandPart2 : Hand
    {
        public HandPart2(string cards, int bid)
        {
            base.Cards = cards;
            base.Bid = bid;
        }

        public override int CardValue(char c) => c switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => 1,
            'T' => 10,
            _ => c - '0'
        };
    }

    public abstract class Hand : IComparable
    {
        public string Cards;
        public int Bid;

        public enum KindEnum
        {
            FiveOfAKind = 7,
            FourOfAKind = 6,
            FullHouse = 5,
            ThreeOfAKind = 4,
            TwoPairs = 3,
            OnePair = 2,
            HighCard = 1
        }

        public abstract int CardValue(char c);

        public int CompareTo(object? obj)
        {
            if (obj is null || obj is not Hand)
                throw new NotImplementedException();

            Hand other = (Hand)obj;

            int compare = 0;

            if (obj is HandPart1)
                compare = this.Kind.CompareTo(other.Kind);

            if (obj is HandPart2)
                compare = this.KindWild.CompareTo(other.KindWild);

            if (compare != 0)
                return compare;

            for (int i = 0; i < 5; i++)
            {
                int card1 = CardValue(this.Cards[i]);
                int card2 = CardValue(other.Cards[i]);
                compare = card1.CompareTo(card2);
                if (compare != 0)
                    return compare;
            }
            return 0;
        }

        public KindEnum KindWild
        {
            get
            {
                const string cardswap = "AKQT98765432";
                string originalCards = this.Cards;
                KindEnum best = KindEnum.HighCard;

                foreach(char c in cardswap)
                {
                    this.Cards = originalCards.Replace('J', c);
                    if (this.Kind > best)
                        best = this.Kind;
                }

                this.Cards = originalCards;
                return best;
            }
        }

        public KindEnum Kind
        {
            get
            {
                var groups = this.Cards
                    .GroupBy(o => o)
                    .OrderByDescending(o => o.Count())
                    .ToList();

                int groupCount = groups.Count();
                int firstGroupCount = groups[0].Count();

                return (groupCount, firstGroupCount) switch
                {
                    (1, _) => KindEnum.FiveOfAKind,
                    (4, _) => KindEnum.OnePair,
                    (5, _) => KindEnum.HighCard,
                    (2, 4) => KindEnum.FourOfAKind,
                    (2, 3) => KindEnum.FullHouse,
                    (3, 3) => KindEnum.ThreeOfAKind,
                    (3, 2) => KindEnum.TwoPairs,
                    (_, _) => throw new NotImplementedException()
                };               
            }
        }
            
    }
}
