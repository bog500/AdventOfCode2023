using AdventOfCode2023.Common;
using AdventOfCode2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2023.Day3
{
    public abstract class Day3BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> line);

        protected List<Schematic> Parse(List<string> lines)
        {
            List<Schematic> list = new();
            int row = 0;
            foreach (var line in lines)
            {
                string str = "";
                int col = 0;
                foreach (char c in "." + line + ".")
                {
                    if (c == '.')
                    {
                        AddIfValid(str, row, col, ref list);
                        str = "";
                        col++;
                        continue;
                    }

                    if (c.IsNumber())
                    {
                        str += c;
                    }
                    else
                    {
                        AddIfValid(str, row, col, ref list);
                        AddIfValid("" + c, row, col + 1, ref list);
                        str = "";
                    }
                    col++;
                }
                str = "";
                AddIfValid(str, row, col, ref list);
                row++;
            }
            return list;
        }

        protected void AddIfValid(string str, int row, int col, ref List<Schematic> list)
        {
            if (string.IsNullOrEmpty(str))
                return;

            int x = col - str.Length;

            int i;
            if (int.TryParse(str, out i))
            {
                Schematic s = new SchematicNumber()
                {
                    Number = i,
                    Symbol = str,
                    Coord = new Coord(x, row)
                };
                list.Add(s);
            }
            else
            {
                Schematic s = new SchematicSymbol()
                {
                    Symbol = str,
                    Coord = new Coord(x, row)
                };
                list.Add(s);
            }

        }
    }
}
