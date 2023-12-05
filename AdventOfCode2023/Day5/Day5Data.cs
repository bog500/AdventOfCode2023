using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day5
{
    public record Day5Data(List<long> Seeds, List<Map> Maps)
    {
        public IEnumerable<(long SeedStart, long Range)> SeedRanges
        {
            get
            {
                for (int i = 0; i < Seeds.Count; i = i + 2)
                {
                    yield return (Seeds[i], Seeds[i + 1]);
                }
            }
        }
    }

    public record Map(int Id, string Name, List<MapRange> Ranges)
    {
        public long Gestination(long source)
        {
            foreach(var range in Ranges)
            {
                (long Dest, bool Found) dest = range.Destination(source);
                if (dest.Found)
                    return dest.Dest;
            }
            return source;
        }
    }

    public record MapRange(long DestinationRange, long SourceRange, long RangeLength)
    {
        public (long Dest, bool Found) Destination(long source)
        {
            if(source >= SourceRange && source < SourceRange + RangeLength)
            {
                return (DestinationRange + (source - SourceRange), true);
            }
            // not found
            return (0, false);
        }
    }

}
