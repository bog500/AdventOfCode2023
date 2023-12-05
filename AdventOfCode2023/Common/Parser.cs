using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2023.Common
{
    public static class Parser
    {
        public static List<int> ParseInt(string s, char splitChar = ' ')
        {
            List<int> ints = s
                .Split(splitChar)
                .Where(o => !string.IsNullOrEmpty(o))
                .Select(o => int.Parse(o))
                .ToList();
            return ints;
        }

        public static List<long> ParseLong(string s, char splitChar = ' ')
        {
            List<long> ints = s
                .Split(splitChar)
                .Where(o => !string.IsNullOrEmpty(o))
                .Select(o => long.Parse(o))
                .ToList();
            return ints;
        }

        public static int CharToInt(char c)
        {
            return (int)c - 48; 
        }
    }
}
