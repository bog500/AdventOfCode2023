using AdventOfCode2023.Common;
using AdventOfCode2023.Day01;
using static AdventOfCode2023.Common.Enums;


ClueReader cr = new ClueReader(DayEnum.Day1);

List<string> demo1Lines = cr.Read(FileEnum.Demo1);
List<string> demo2Lines = cr.Read(FileEnum.Demo2);
List<string> clueLines = cr.Read(FileEnum.Clue);

Part1Solver part1Solver = new Part1Solver();
Part2Solver part2Solver = new Part2Solver();

int demo1Total = part1Solver.Solve(demo1Lines);
ConsoleWritter.Answer(PartEnum.Demo1, demo1Total);

int part1Total = part1Solver.Solve(clueLines);
ConsoleWritter.Answer(PartEnum.Part1, part1Total);

int demo2Total = part2Solver.Solve(demo2Lines);
ConsoleWritter.Answer(PartEnum.Demo2, demo2Total);

int part2Total = part2Solver.Solve(clueLines);
ConsoleWritter.Answer(PartEnum.Part2, part2Total);