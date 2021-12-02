using System;
using System.IO;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

var config = ManualConfig.CreateEmpty()
    .AddColumnProvider(DefaultColumnProviders.Instance)
    .AddLogger(ConsoleLogger.Default)
    .WithOptions(ConfigOptions.JoinSummary)
    .WithOptions(ConfigOptions.DisableLogFile)
    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
    .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.Method, MethodOrderPolicy.Alphabetical));

var runResult = BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(config: config).Single();
var exportedFileName = MarkdownExporter.GitHub.ExportToFiles(runResult, ConsoleLogger.Unicode).Single();
File.Move(exportedFileName, Path.Combine(GetProjectRootDirectory(), "README.md"), true);

string GetProjectRootDirectory()
{
    var projectName = Assembly.GetExecutingAssembly().GetName().Name + ".csproj";
    return FindBaseDirectory(dir => dir.EnumerateFiles("*.csproj").Select(file => file.Name).Contains(projectName));
}

string FindBaseDirectory(Func<DirectoryInfo, bool> isMatch)
{
    var current = new DirectoryInfo(Directory.GetCurrentDirectory());
    while (!isMatch(current))
    {
        current = current.Parent ??
                  throw new InvalidOperationException("Could not find matching directory");
    }

    return current?.FullName;
}