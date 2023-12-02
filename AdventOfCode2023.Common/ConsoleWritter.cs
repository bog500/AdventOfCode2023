using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.Common
{
    public static class ConsoleWritter
    {
        public static void Answer(PartEnum part, object answer)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(PartString(part) + ":   ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(answer);

            Console.ForegroundColor = oldColor;
        }

        private static string PartString(PartEnum partEnum) =>
            partEnum switch
            {
                PartEnum.Part1 => "Part 1",
                PartEnum.Part2 => "Part 2",
                PartEnum.Demo1 => "Demo 1",
                PartEnum.Demo2 => "Demo 2",
                _ => "??"
            };
    }
}
