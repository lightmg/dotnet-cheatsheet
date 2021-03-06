using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Flat
{
    [MemoryDiagnoser]
    public class Class
    {
        [Benchmark]
        public void GetLength()
        {
            for (var i = 0; i < 1000; i++)
                GetLength(new Line(new Point(10, 20), new Point(30, 40)));
        }

        private static double GetLength(Line line) =>
            GetLength(line.P1, line.P2);

        private static double GetLength(Point point1, Point point2)
        {
            return Math.Sqrt(
                GetSubtractSquare(point1.X, point2.X) +
                GetSubtractSquare(point1.Y, point2.Y)
            );
        }

        private static double GetSubtractSquare(double point1, double point2)
        {
            var d = point2 - point1;
            return d * d;
        }

        private class Line
        {
            public Line(Point p1, Point p2)
            {
                P1 = p1;
                P2 = p2;
            }

            public Point P1 { get; }
            public Point P2 { get; }
        }

        private class Point
        {
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double X { get; }
            public double Y { get; }
        }
    }
}