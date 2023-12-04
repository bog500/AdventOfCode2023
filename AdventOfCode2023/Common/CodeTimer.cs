using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Common
{
    internal class CodeTimer : IDisposable
    {
        Stopwatch sw = new();
        public CodeTimer()
        {
            sw.Start();
        }

        public void Dispose()
        {
            sw.Stop();

            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("    " + sw.ElapsedMilliseconds + "ms");

            Console.ForegroundColor = oldColor;
            
        }
    }
}
