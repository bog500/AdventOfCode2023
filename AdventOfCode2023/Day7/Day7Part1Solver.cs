using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day7
{
    public class Day7Part1Solver : Day7BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            var hands = Parse(lines).OrderBy(o => o).ToList();

            int total = 0;
            int count = 0;

            foreach(var hand in hands)
            {
                count++;
                int handValue = hand.Bid * count;
                total += handValue;
            }
            return total.ToString();
        }

        public IEnumerable<Hand> Parse(List<string> lines)
        {
            foreach (var line in lines)
            {
                string cards = line.Split(' ')[0];
                int bid = int.Parse(line.Split(' ')[1]);
                yield return new HandPart1(cards, bid);
            }
        }

    }
}
