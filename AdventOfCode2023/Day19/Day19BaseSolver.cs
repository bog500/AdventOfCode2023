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

        Dictionary<string, RuleSet> rulesets = new();
        List<MachinePart> machineParts = new();

        public void ParseAll(List<string> lines)
        {
            bool doRules = true;
            foreach(var line in lines)
            {
                if(string.IsNullOrEmpty(line))
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

        public int Run()
        {
            int total = 0;
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
                var v = rule.Chr switch
                {
                    'x' => part.X,
                    'm' => part.M,
                    'a' => part.A,
                    's' => part.S,
                };

                if(rule.IsGreater && v > rule.Value || !rule.IsGreater && v < rule.Value)
                {
                    if (rule.TargetKey == "A")
                        return part.X + part.M + part.A + part.S;

                    if (rule.TargetKey == "R")
                        return 0;

                    RuleSet next = rulesets[rule.TargetKey];
                    return ExecuteRuleset(part, next);
                }
            }

            if(ruleset.TargetKey == "A")
                return part.X + part.M + part.A + part.S;

            if (ruleset.TargetKey == "R")
                return 0;

            RuleSet next2 = rulesets[ruleset.TargetKey];
            return ExecuteRuleset(part, next2);

        }
    }
}
