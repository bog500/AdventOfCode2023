using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using Microsoft.Diagnostics.Tracing.Parsers.Clr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day8
{
    public class Day8Part2Solver : Day8BaseSolver
    {
        
        public override string Solve(List<string> lines)
        {
            SetData(lines);

            var currentNodes = Nodes.Where(o => o.Key.EndsWith('A')).Select(o => o.Value).ToList();

            List<long> steps = new();

            foreach(var currentNode in currentNodes)
            {
                steps.Add(base.CountStepsToDestination(currentNode));
            }

            var ans = MathFunc.LeastCommonMultiple(steps);

            return ans.ToString();
        }
        protected override bool IsAtDestination(Node node) => node.Key.EndsWith('Z');

    }
}
