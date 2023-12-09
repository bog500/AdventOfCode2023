using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day8
{
    public class Day8Part1Solver : Day8BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            SetData(lines);

            Node currentNode = Nodes["AAA"];

            int steps = CountStepsToDestination(currentNode);

            return steps.ToString();
        }

        protected override bool IsAtDestination(Node node) => node.Key == "ZZZ";
    }
}
