using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Merwylan.StandardMaths.Common;

namespace Merwylan.StandardMaths.Benchmark
{
    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    [RPlotExporter]
    public class MatrixBenchmark
    {
        [ParamsSource(nameof(ValuesForAdditionSubtraction))]
        public Matrix<double> _matrix1;
        [ParamsSource(nameof(ValuesForAdditionSubtraction))]
        public Matrix<double> _matrix2;

        [ParamsSource(nameof(ValuesForTargetAdditionSubtraction))]
        public Targets.Matrix<double> _targetMatrix1;
        [ParamsSource(nameof(ValuesForTargetAdditionSubtraction))]
        public Targets.Matrix<double> _targetMatrix2;

        public IEnumerable<Matrix<double>> ValuesForAdditionSubtraction => new[]
        {
            new Matrix<double>(new double[,]{{3},{4}}),
            new Matrix<double>(new double[,]{{36,12},{-443,435},{3453,234}}),
            new Matrix<double>(new double[,]{{3},{4},{455},{45234}}),
            new Matrix<double>(new double[,]{{3},{4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231},
                {4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231}}),
            new Matrix<double>(new double[,]{}),
        };

        public IEnumerable<Targets.Matrix<double>> ValuesForTargetAdditionSubtraction => new[]
        {
            new Targets.Matrix<double>(new double[,]{{3},{4}}),
            new Targets.Matrix<double>(new double[,]{{36,12},{-443,435},{3453,234}}),
            new Targets.Matrix<double>(new double[,]{{3},{4},{455},{45234}}),
            new Targets.Matrix<double>(new double[,]{{3},{4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231},
                {4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231},{4},{23423},{-1231}}),
            new Targets.Matrix<double>(new double[,]{}),
        };

        [Benchmark]
        public Matrix<double> AddMatrix() => _matrix1 + _matrix2;

        [Benchmark]
        public Targets.Matrix<double> AddTargetMatrix() => _targetMatrix1 + _targetMatrix2;

        [Benchmark] 
        public Matrix<double> SubtractMatrix() => _matrix1 - _matrix2;

        [Benchmark]
        public Targets.Matrix<double> SubtractTargetMatrix() => _targetMatrix1 - _targetMatrix2;

    }
}
