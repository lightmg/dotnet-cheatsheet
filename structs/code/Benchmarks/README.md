``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1348 (21H1/May2021Update)
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.209
  [Host]     : .NET 5.0.12 (5.0.1221.52207), X64 RyuJIT
  DefaultJob : .NET 5.0.12 (5.0.1221.52207), X64 RyuJIT


```
|        Namespace |         Type |           Mean |         Error |        StdDev |   Gen 0 | Allocated |
|----------------- |------------- |---------------:|--------------:|--------------:|--------:|----------:|
|  **Benchmarks.Flat** |        **Class** |      **18.564 μs** |     **0.3604 μs** |     **0.4812 μs** | **22.9492** |  **96,000 B** |
|  Benchmarks.Flat |       Struct |       1.630 μs |     0.0239 μs |     0.0211 μs |       - |         - |
|  Benchmarks.Flat | StructWithIn |       1.627 μs |     0.0205 μs |     0.0191 μs |       - |         - |
| **Benchmarks.Array** |        **Class** | **434,739.486 μs** | **4,722.2309 μs** | **4,186.1347 μs** |       **-** |         **-** |
| Benchmarks.Array |       Struct | 359,919.719 μs | 7,040.1632 μs | 6,914.3816 μs |       - |   1,384 B |
