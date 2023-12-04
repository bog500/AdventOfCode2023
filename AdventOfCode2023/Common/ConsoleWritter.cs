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
            ConsoleWritter.Write(PartString(part) + ":   ", ConsoleColor.Cyan);
            ConsoleWritter.Write(answer, ConsoleColor.Green);
        }

        public static void WriteLine(object msg, ConsoleColor color = ConsoleColor.Gray)
        {
            Write(msg, color);
            Console.WriteLine("");
        }

        public static void Write(object msg, ConsoleColor color)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.Write(msg);

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
