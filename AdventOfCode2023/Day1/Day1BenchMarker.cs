using AdventOfCode2023.Common;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Common.Enums;

namespace AdventOfCode2023.Day1
{
    public class Day1BenchMarker
    {
        public void Run()
        {
            var config = DefaultConfig.Instance.AddJob(Job
                .ShortRun
                .WithLaunchCount(1)
                .WithWarmupCount(3)
                .WithToolchain(InProcessEmitToolchain.Instance)
                );

            BenchmarkRunner.Run<Day1BenchMarks>(ManualConfig
                                .Create(config)
                                .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                                .WithOptions(ConfigOptions.JoinSummary)
                                .WithOptions(ConfigOptions.DisableLogFile)
                                );
        }
    }
}
