using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day19
{
    public class Day19Part2Solver : Day19BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            ParseRules(lines);
            var ans = RuneOneByOne();
            
            return ans.ToString();
        }

        private long RuneOneByOne()
        {
            long x = 0;
            long m = 0;
            long a = 0;
            long s = 0;

            // ############################

            machineParts.Clear();
            for (int i = 1; i <= 4000; i++)
            {
                machineParts.Add(new MachinePart(i, -1, -1, -1));
            }
            x = base.Run();

            // ############################

            machineParts.Clear();
            for (int i = 1; i <= 4000; i++)
            {
                machineParts.Add(new MachinePart(-1, i, -1, -1));
            }
            m = base.Run();

            // ############################

            machineParts.Clear();
            for (int i = 1; i <= 4000; i++)
            {
                machineParts.Add(new MachinePart(-1, -1, i, -1));
            }
            a = base.Run();

            // ############################

            machineParts.Clear();
            for (int i = 1; i <= 4000; i++)
            {
                machineParts.Add(new MachinePart(-1, -1, -1, i));
            }
            s = base.Run();

            long total = x * m * a * s;

            return total;
        }

        public void ParseRules(List<string> lines)
        {
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    break;

                var ruleset = ParseRuleSet(line);
                rulesets.Add(ruleset.Key, ruleset);
            }
        }

        protected override int GetPartValue(MachinePart part)
        {
            return 1;
        }
    }
}
