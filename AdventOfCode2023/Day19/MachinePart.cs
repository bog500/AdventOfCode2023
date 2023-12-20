using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day19
{

    public record RuleSet(string Key, string TargetKey)
    {
        public List<Rule> Rules = new();
    }

    public record Rule(char Chr, bool IsGreater, int Value , string TargetKey)
    {

    }

    public record MachinePart(int X, int M, int A, int S)
    {

    }
}
