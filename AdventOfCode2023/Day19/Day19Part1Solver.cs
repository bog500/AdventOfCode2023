using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day19
{
    public class Day19Part1Solver : Day19BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            ParseAll(lines);
            var ans = base.Run();
            return ans.ToString();
        }

        public void ParseAll(List<string> lines)
        {
            bool doRules = true;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    doRules = false;
                    continue;
                }

                if (doRules)
                {
                    var ruleset = ParseRuleSet(line);
                    rulesets.Add(ruleset.Key, ruleset);
                }
                else
                    machineParts.Add(ParseData(line));
            }
        }

        protected override int GetPartValue(MachinePart part)
        {
            return part.X + part.M + part.A + part.S;
        }
    }
}
