using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day5
{
    public abstract class Day5BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        protected Day5Data Parse(List<string> lines)
        {
            List<long> seeds = lines[0]
                .Replace("seeds: ", "")
                .Split(' ')
                .Where(o => !string.IsNullOrEmpty(o))
                .Select(o => long.Parse(o))
                .ToList();

            List<Map> maps = new();

            int Id = 0;
            List<MapRange> ranges = new();
            string name = "";
            foreach(var line in lines)
            {
                if (line.StartsWith("seeds:"))
                    continue;

                if (string.IsNullOrEmpty(line) && name == "")
                    continue;

                if (string.IsNullOrEmpty(line))
                {
                    Id++;
                    maps.Add(new(Id, name, new (ranges)));
                    ranges = new();
                }else if (line[0].IsLetter())
                {
                    name = line;
                }
                else
                {
                    var values = line.Split(' ')
                    .Where(o => !string.IsNullOrEmpty(o))
                    .Select(o => long.Parse(o))
                    .ToList();

                    ranges.Add(new(values[0], values[1], values[2]));
                }
            }

            Day5Data data = new(seeds, maps);
            return data;
        }

    }
}
