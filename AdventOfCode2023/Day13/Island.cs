using AdventOfCode2023.Common;
using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day13
{
    public struct Island
    {
        int maxX = -1;
        int maxY = -1;

        Dictionary<Coord, char> map = new();

        public Island()
        {
        }

        public void AddRow(string line)
        {
            maxY++;
            maxX = -1;
            foreach (char c in line)
            {
                maxX++;
                map.Add(new Coord(maxX, maxY), c);
            }
        }

        public (int mirrorX, int mirrorY) GetMirrors(int ignoreX = -1, int ignoreY = -1)
        {
            for(int x = 0; x < maxX; x++)
            {
                if (x == ignoreX)
                    continue;

                if (IsMirrorX(x))
                    return (x, -1);
            }

            for (int y = 0; y < maxY; y++)
            {
                if (y == ignoreY)
                    continue;

                if (IsMirrorY(y))
                    return (-1, y);
            }

            return (-1, -1);
        }

        public (int mirrorX, int mirrorY) GetNewMirrors()
        {
            var originalMirrors = GetMirrors();

            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    Toggle(x, y);
                    //Print();
                    var mirrors = GetMirrors(originalMirrors.mirrorX, originalMirrors.mirrorY);

                    if (mirrors.mirrorX != -1 || mirrors.mirrorY != -1)
                        return mirrors;

                    Toggle(x, y);
                }
            }
            return (-1, -1);
        }

        public void Print()
        {
            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    var coord = new Coord(x, y);
                    ConsoleWritter.Write(map[coord], ConsoleColor.DarkGreen);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\r\n\r\n");
        }

        private void Toggle(int x, int y)
        {
            var coord = new Coord(x, y);
            map[coord] = map[coord] switch
            {
                '#' => '.',
                '.' => '#',
            };
        }

        private bool IsMirrorX(int x)
        {
            int x1 = x;
            int x2 = x + 1;
            while(x1 >= 0 && x2 <= maxX)
            {
                string col1 = GetColumn(x1);
                string col2 = GetColumn(x2);
                if (col1 != col2)
                    return false;
                x1--;
                x2++;
            }

            if ((x1 >= 0 || x2 <= maxX))
                return true;

            return false;

        }

        private bool IsMirrorY(int y)
        {
            int y1 = y;
            int y2 = y + 1;
            while (y1 >= 0 && y2 <= maxY)
            {
                string row1 = GetRow(y1);
                string row2 = GetRow(y2);
                if (row1 != row2)
                    return false;
                y1--;
                y2++;
            }

            if ((y1 >= 0 || y2 <= maxY))
                return true;

            return false;

        }

        private string GetRow(int y)
        {
            StringBuilder sb = new();

            for (int x = 0; x <= maxX; x++)
            {
                sb.Append(map[new Coord(x, y)]);
            }

            return sb.ToString();
        }

        private string GetColumn(int x)
        {
            StringBuilder sb = new();

            for(int y = 0; y <= maxY; y++)
            {
                sb.Append(map[new Coord(x, y)]);
            }

            return sb.ToString();
        }
    }
}
