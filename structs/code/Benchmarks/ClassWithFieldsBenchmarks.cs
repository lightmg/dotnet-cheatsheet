using System;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class ClassWithFieldsBenchmarks
    {
        private static readonly Point3D[] Points = Seed.Coords.Select(p => new Point3D(p.x, p.y, p.z)).ToArray();

        [Benchmark]
        public double GetMaxDistance()
        {
            var maxDistance = 0d;
            foreach (var point1 in Points)
            foreach (var point2 in Points)
            {
                var distance = GetDistanceBetween(point1, point2);

                if (maxDistance < distance)
                    maxDistance = distance;
            }

            return maxDistance;
        }

        private static double GetDistanceBetween(in Point3D point1, in Point3D point2)
        {
            return Math.Sqrt(
                GetSubtractSquare(point1.X, point2.X) +
                GetSubtractSquare(point1.Y, point2.Y) +
                GetSubtractSquare(point1.Z, point2.Z)
            );
        }

        private static double GetSubtractSquare(in int point1, in int point2)
        {
            var d = point2 - point1;
            return d * d;
        }

        private class Point3D
        {
            public readonly int X;
            public readonly int Y;
            public readonly int Z;

            public Point3D(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }
    }
}