using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day6
{
    public abstract class Day6BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        protected abstract string FormatLine(string line);

        protected IEnumerable<Race> Parse(List<string> lines)
        {
            string timeStr = FormatLine(lines.First().Replace("Time:",""));
            string distanceStr = FormatLine(lines.Last().Replace("Distance:",""));

            var times = Parser.ParseInt(timeStr);
            var dists = Parser.ParseLong(distanceStr);

            for(int i = 0; i < times.Count; i++)
            {
                yield return new Race(times[i], dists[i]);
            }
        }

        protected long CalcErrorMargin(IEnumerable<Race> races)
        {
            long total = 1;
            foreach (Race race in races)
            {
                var nbWin = CalcNbWin(race);
                total *= nbWin;
            }

            return total;
        }

        public static long CalcNbWin(Race race)
        {
            long nbWin = 0;
            for (int buttonTime = 0; buttonTime <= race.Time / 2; buttonTime++)
            {
                var dist = CalcDistance(buttonTime, race);
                if (dist > race.Distance)
                    nbWin += 2;
            }

            if (race.Time % 2 == 0)
                nbWin--;

            return nbWin;
        }

        public static long CalcDistance(long buttonTime, Race race)
        {

            var travelTime = race.Time - buttonTime;
            var speed = buttonTime;

            return travelTime * speed;
        }

    }
}
