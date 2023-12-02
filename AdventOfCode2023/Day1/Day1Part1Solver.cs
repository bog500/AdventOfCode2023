using AdventOfCode2023.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day1
{
    public class Day1Part1Solver : IPartSolver
    {
        public string Solve(List<string> lines)
        {
            int total = 0;
            foreach (var line in lines)
            {
                string formattedLine = formatLine(line);
                char first = '0';
                char last = '0';
                bool firstDefined = false;
                bool lastDefined = false;
                foreach (char c in formattedLine)
                {
                    if (c >= '0' && c <= '9')
                    {
                        if (firstDefined)
                        {
                            last = c;
                            lastDefined = true;
                        }
                        else
                        {
                            first = c;
                            firstDefined = true;
                        }
                    }
                }
                if (!lastDefined)
                {
                    last = first;
                }
                int i = int.Parse("" + first + last);
                total += i;
            }
            return total.ToString();
        }

        protected virtual string formatLine(string line)
        {
            return line;
        }
    }
}
