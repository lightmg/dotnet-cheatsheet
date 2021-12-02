``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.209
  [Host]     : .NET 5.0.12 (5.0.1221.52207), X64 RyuJIT DEBUG
  DefaultJob : .NET 5.0.12 (5.0.1221.52207), X64 RyuJIT


```
|                  Namespace |                      Type |         Method |           Mean |         Error |         StdDev |   Gen 0 | Allocated |
|--------------------------- |-------------------------- |--------------- |---------------:|--------------:|---------------:|--------:|----------:|
|  **Benchmarks.FlatBenchmarks** |            **ClassBenchmark** |      **GetLength** |      **18.403 μs** |     **0.3358 μs** |      **0.5793 μs** | **22.9492** |  **96,000 B** |
|  Benchmarks.FlatBenchmarks |           StructBenchmark |      GetLength |       1.584 μs |     0.0135 μs |      0.0120 μs |       - |         - |
|  Benchmarks.FlatBenchmarks |     StructWithInBenchmark |      GetLength |       2.210 μs |     0.0321 μs |      0.0268 μs |       - |         - |
| **Benchmarks.ArrayBenchmarks** | **ClassWithFieldsBenchmarks** | **GetMaxDistance** | **444,457.765 μs** | **8,669.1775 μs** | **16,702.5618 μs** |       **-** |         **-** |
| Benchmarks.ArrayBenchmarks |          StructBenchmarks | GetMaxDistance | 348,421.908 μs | 2,019.1776 μs |  1,686.1047 μs |       - |   1,336 B |
