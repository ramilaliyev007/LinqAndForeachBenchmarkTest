```

BenchmarkDotNet v0.13.6, Windows 11 (10.0.22621.1992/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.100-preview.3.23178.7
  [Host]     : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2


```
|                   Method |       Mean |    Error |   StdDev |    Gen0 |    Gen1 | Allocated |
|------------------------- |-----------:|---------:|---------:|--------:|--------:|----------:|
| SetOrderLinesWithForeach | 4,166.5 μs | 71.34 μs | 66.74 μs | 15.6250 |       - | 241.95 KB |
|    SetOrderLinesWithLinq |   188.7 μs |  3.19 μs |  4.03 μs | 35.1563 | 20.7520 | 431.34 KB |
