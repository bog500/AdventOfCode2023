using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day4
{
    public record Card(int Id, HashSet<int> WinningNumbers, HashSet<int> PlayedNumbers)
    {
        public HashSet<int> PlayedWinningNumbers => WinningNumbers.Intersect(PlayedNumbers).ToHashSet();

        public double Points => WinCount == 0 ? 0 : Math.Pow(2, WinCount - 1);

        public int WinCount => PlayedWinningNumbers.Count;

    }
}
