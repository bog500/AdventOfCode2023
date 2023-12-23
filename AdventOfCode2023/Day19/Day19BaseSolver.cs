using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day19
{
    public abstract class Day19BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        protected Dictionary<string, RuleSet> rulesets = new();
        protected List<MachinePart> machineParts = new();


        public RuleSet ParseRuleSet(string line)
        {
            string formatted = line.Replace("}", "").Replace(" ", "");

            string key = formatted.Split('{').First();

            string ruleTargetKey = formatted.Split(',').Last();

            RuleSet rset = new(key, ruleTargetKey);

            var parts = formatted.Split('{').Last().Split(',');
            foreach(var part in parts)
            {
                if (!part.Contains(':'))
                    continue;

                var rule = ParseRule(part);
                rset.Rules.Add(rule);
            }

            return rset;
        }

        public Rule ParseRule(string str)
        {
            string target = str.Split(':').Last();
            string firstPart = str.Split(':').First();
            char variable = firstPart[0];
            var isGreater = firstPart[1] == '>';
            int value = int.Parse(firstPart.Split(['<', '>']).Last());

            Rule rule = new(variable, isGreater, value, target);

            return rule;
        }

        public MachinePart ParseData(string line)
        {
            string formatted = line.Replace("{", "").Replace("}", "").Replace(" ", "");
            var parts = formatted.Split(',');

            int x = int.Parse(parts[0].Split('=').Last());
            int m = int.Parse(parts[1].Split('=').Last());
            int a = int.Parse(parts[2].Split('=').Last());
            int s = int.Parse(parts[3].Split('=').Last());

            return new MachinePart(x, m, a, s);
        }

        public long Run()
        {
            long total = 0;
            foreach(var part in this.machineParts)
            {
                RuleSet ruleset = rulesets["in"];
                int result = ExecuteRuleset(part, ruleset);
                total += result;
            }
            return total;
        }

        private int ExecuteRuleset(MachinePart part, RuleSet ruleset)
        {
            foreach(var rule in ruleset.Rules)
            {
                int v = rule.Chr switch
                {
                    'x' => part.X,
                    'm' => part.M,
                    'a' => part.A,
                    's' => part.S,
                };

                if (v < 0)
                    continue;

                if(rule.IsGreater && v > rule.Value || !rule.IsGreater && v < rule.Value)
                {
                    if (rule.TargetKey == "A")
                        return GetPartValue(part);

                    if (rule.TargetKey == "R")
                        return 0;

                    RuleSet next = rulesets[rule.TargetKey];
                    return ExecuteRuleset(part, next);
                }
            }

            if(ruleset.TargetKey == "A")
                return GetPartValue(part);

            if (ruleset.TargetKey == "R")
                return 0;

            RuleSet next2 = rulesets[ruleset.TargetKey];
            return ExecuteRuleset(part, next2);

        }

        protected abstract int GetPartValue(MachinePart p);
    }
}
