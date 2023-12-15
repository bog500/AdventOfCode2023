using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Day15.Day15Part2Solver;

namespace AdventOfCode2023.Day15
{
    public class Day15Part2Solver : Day15BaseSolver
    {
        List<Box> boxes = new();

        public override string Solve(List<string> lines)
        {
            // init boxes
            boxes = new();
            for (int boxNum = 0; boxNum < 256; boxNum++)
            {
                boxes.Add(new(boxNum));
            }

            foreach (string str in lines[0].Split(','))
            {
                Step step = ParseStep(str);
                Box box = boxes[step.Hash];
                if(step.Operation == '-')
                {
                    Lens? len = box.LensList.FirstOrDefault(o => o.Label == step.Label);
                    if(len is not null)
                    {
                        box.LensList.Remove(len);
                    }
                }
                else
                {
                    var newLen = new Lens(step.Label, step.FocalLength.Value);
                    var oldLen = box.LensList.FirstOrDefault(o => o.Label == step.Label);
                    if(oldLen is null)
                    {
                        box.LensList.Add(newLen);
                    }
                    else
                    {
                        int index = box.LensList.IndexOf(oldLen);
                        box.LensList[index] = newLen;
                    }
                }
            }

            int total = Sum();

            return total.ToString();
        }

        private int Sum()
        {
            int total = 0;
            foreach(var box in boxes)
            {

                int lenSlot = 1;
                foreach(var len in box.LensList)
                {
                    int boxNum = 1 + box.Number;
                    int power = boxNum * lenSlot * len.FocalLength;

                    total += power;

                    lenSlot++;
                }
            }
            return total;
        }

        public Step ParseStep(string str)
        {
            string label = str.Split(new[] { '=', '-' })[0];
            int hash = base.Hash(label);

            int? focalLength = null;

            char operation = '-';
            if (str.Contains('='))
            {
                operation = '=';
                focalLength = str.Last() - '0';
            }

            Step i = new Step(label, hash, operation, focalLength);
            return i;
        }

        internal record Box(int Number)
        {
            public List<Lens> LensList = new();
        }

        internal record Lens(string Label, int FocalLength)
        {

        }

        
    }

    public struct Step(string label, int hash, char operation, int? focalLength)
    {
        public string Label => label;
        public int Hash => hash;
        public char Operation => operation;
        public int? FocalLength => focalLength;
    }
}
