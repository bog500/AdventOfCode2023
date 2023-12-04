using AdventOfCode2023;
using AdventOfCode2023.Common;
using static AdventOfCode2023.Common.Enums;

/*
foreach (var runner in DayRunners.GetAll())
{
    runner.RunAll();
}
*/

IDayRunner runner5 = DayRunners.Get(DayEnum.Day5);
runner5.RunAll();

