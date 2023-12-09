using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day8
{
    public record Node(string Key, string Left, string Right)
    {
        public string GetNext(char c)
        {
            return c switch
            {
                'L' => Left,
                'R' => Right
            };
        }
    }

}
