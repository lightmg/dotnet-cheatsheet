using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run(
    Assembly.GetExecutingAssembly(),
    ManualConfig.Create(DefaultConfig.Instance)
        .WithOptions(ConfigOptions.JoinSummary)
        .WithOptions(ConfigOptions.DisableLogFile));