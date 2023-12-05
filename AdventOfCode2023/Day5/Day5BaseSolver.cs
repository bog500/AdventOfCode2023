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

        protected Day5Data data;

        protected Day5Data Parse(List<string> lines)
        {
            List<long> seeds = Parser.ParseLong(lines[0].Replace("seeds: ", ""));

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
                    var values = Parser.ParseLong(line);
                    ranges.Add(new(values[0], values[1], values[2]));
                }
            }

            Day5Data data = new(seeds, maps);
            return data;
        }

        protected async Task<long> GetLocation(long seed)
        {
            await Task.Delay(0);
            long soil = data.Maps[0].Gestination(seed);
            long fertilizer = data.Maps[1].Gestination(soil);
            long water = data.Maps[2].Gestination(fertilizer);
            long light = data.Maps[3].Gestination(water);
            long temperature = data.Maps[4].Gestination(light);
            long humidity = data.Maps[5].Gestination(temperature);
            long location = data.Maps[6].Gestination(humidity);
            return location;
        }

    }
}
