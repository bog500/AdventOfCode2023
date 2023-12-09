using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day8
{

    public abstract class Day8BaseSolver : IPartSolver
    {
        protected string Instructions;
        protected Dictionary<string, Node> Nodes;

        protected void SetData(List<string> lines)
        {
            Instructions = lines[0];
            Nodes = new();

            foreach (var line in lines[2..])
            {
                Node node = ParseNode(line);
                Nodes.Add(node.Key, node);
            }
        }

        public Node ParseNode(string s)
        {
            string key = s[0..3];
            string left = s[7..10];
            string right = s[12..15];
            return new Node(key, left, right);
        }

        protected int CountStepsToDestination(Node currentNode)
        {
            int steps = 0;
            int instructionNum = 0;

            while (!IsAtDestination(currentNode))
            {
                if (instructionNum == Instructions.Length)
                    instructionNum = 0;

                char move = Instructions[instructionNum];
                string nextNodeKey = currentNode.GetNext(move);
                currentNode = Nodes[nextNodeKey];

                steps++;
                instructionNum++;
            }

            return steps;
        }

        public abstract string Solve(List<string> line);

        protected abstract bool IsAtDestination(Node node);

    }
}
