using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Running;

namespace Merwylan.StandardMaths.Benchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MatrixBenchmark>();
            Console.ReadLine();
        }
    }

}
