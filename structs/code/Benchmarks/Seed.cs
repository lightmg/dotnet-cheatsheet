using System;
using System.Linq;

namespace Benchmarks
{
    public static class Seed
    {
        public static readonly (int x, int y, int z)[] Coords = Enumerable.Range(1, 10000)
            .Select(x => (new Random(x).Next(), new Random(x * 2).Next(), new Random(x * 3).Next()))
            .ToArray();
    }
}