using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Merwylan.StandardMaths.Common;

namespace Merwylan.StandardMaths.Tests.Input.Composed
{

    public class AdditionSubtractionThrowMatrices : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Matrix<float>(new float[,] { { 2, 3, 4 }, { 3, 2, 3 }, { 4, 5, 6 } }),
                new Matrix<float>(new float[,] { { 3, 4, 5 }, { 5, 6, 7 } })
            };
            yield return new object[]
            {
                new Matrix<int>(new [,]{{1,2},{3,2},{1,6}}),
                new Matrix<int>(new [,]{{3,5,7},{1,2,3},{7,7,6}})
            };
            yield return new object[]
            {
                new Matrix<int>(new [,]{{3}}),
                new Matrix<int>(new [,]{ { 1},{1} })
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class MultiplicationThrowMatrices : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Matrix<float>(new float[,] { { 2, 3, 4 }, { 3, 2, 3 }, { 4, 5, 6 } }),
                new Matrix<float>(new float[,] { { 3, 4, 5 }, { 5, 6, 7 } })
            };
            yield return new object[]
            {
                new Matrix<float>(new float[,] { { 2, 3, 4 }, { 3, 2, 3 }}),
                new Matrix<float>(new float[,] { { 3, 4, 5 }, { 5, 6, 7 } })
            };
            yield return new object[]
            {
                new Matrix<int>(new [,]{{1,2},{3,2},{1,6}}),
                new Matrix<int>(new [,]{{3,5,7},{1,2,3},{7,7,6}})
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PowerThrowMatrices : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Matrix<float>(new float[,] { { 2, 3, 4 }, { 3, 2, 3 } }),
                3
            };
            yield return new object[]
            {
                new Matrix<int>(new [,] { { 2, 3, 4 }}),
                1
            };
            yield return new object[]
            {
                new Matrix<double>(new double[,] { {1},{2}}),
                0
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class StandardArgumentNullMatrices : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Matrix<double>(),
                new Matrix<double>()
            };
            yield return new object[]
            {
                new Matrix<double>(),
                new Matrix<double>(new double[,] { {1},{2}})
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class PowerArgumentNullMatrices : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Matrix<double>(),
                1
            };
            yield return new object[]
            {
                new Matrix<double>(),
                0
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
