using System;
using Merwylan.StandardMaths.Common;
using System.Collections;
using System.Collections.Generic;

namespace Merwylan.StandardMaths.Tests.Input.Composed
{
    public class AdditionMatrices : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Matrix<double>(new double[,]{ { -9, 1, 6 } }),
                new Matrix<double>(new double [,] { { -6, 12, 8 } }),
                new Matrix<double>(new double[,] {{-15, 13, 14}}),
            };
            yield return new object[]
            {
                new Matrix<double>(new double[,]{ { 2, 3, 4 }, { 3, 2, 3 }, { 4, 5, 6 } }),
                new Matrix<double>(new double[,] { { 3, 4, 5 }, { 5, 6, 7 }, { 2, 3, 2 } }),
                new Matrix<double>(new double[,] {{5, 7, 9}, {8, 8, 10}, {6, 8, 8}}),
            };
            yield return new object[]
            {
                new Matrix<double>(new double[,]{}),
                new Matrix<double>(new double[,]{}),
                new Matrix<double>(new double[,]{}),
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class SubtractionMatrices : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Matrix<int>(new [,]{ { -9, 1, 6 } }),
                new Matrix<int>(new [,] { { -6, 12, 8 } }),
                new Matrix<int>(new [,] {{-3, -11, -2}}),
            };
            yield return new object[]
            {
                new Matrix<double>(new double[,]{ { 2, 3, 4 }, { 3, 2, 3 }, { 4, 5, 6 } }),
                new Matrix<double>(new double[,] { { 3, 4, 5 }, { 5, 6, 7 }, { 2, 3, 2 } }),
                new Matrix<double>(new double[,] {{ -1, -1, -1 }, { -2, -4, -4}, { 2, 2, 4 } }),
            };
            yield return new object[]
            {
                new Matrix<float>(new float[,]{}),
                new Matrix<float>(new float[,]{}),
                new Matrix<float>(new float[,]{}),
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MultiplicationMatrices : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Matrix<int>(new [,]{ { 2, 3, 4 }, { 3, 2, 3 }, { 4, 5, 6 } }),
                new Matrix<int>(new [,] { { 3, 4, 5 }, { 5, 6, 7 }, { 2, 3, 2 } }),
                new Matrix<int>(new [,] {{29, 38, 39}, {25, 33, 35}, {49, 64, 67}}),
            };
            yield return new object[]
            {
                new Matrix<double>(new double[,]{ { 2, 3 } }),
                new Matrix<double>(new double[,] { { 3 }, { 5 }}),
                new Matrix<double>(new double[,] {{21}}),
            };
            yield return new object[]
            {
                new Matrix<float>(new float[,]{}),
                new Matrix<float>(new float[,]{}),
                new Matrix<float>(new float[,]{}),
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PowerMatrices : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Matrix<int>(new [,]{{3,4},{5,6}}),
                2,
                new Matrix<int>(new [,]{{29,36},{45,56}}),
            };
            yield return new object[]
            {
                new Matrix<int>(new [,]{{3,4},{2,1}}),
                4,
                new Matrix<int>(new [,]{{417,416},{208,209}}),
            };
            yield return new object[]
            {
                new Matrix<decimal>(new decimal[,]{{1,2,3},{4,5,6},{7,8,9}}),
                3,
                new Matrix<decimal>(new decimal[,]{{ 468, 576, 684 },{ 1062, 1305, 1548 },{ 1656, 2034, 2412 } }),
            };
            yield return new object[]
            {
                new Matrix<float>(new float[,]{{}}),
                12,
                new Matrix<float>(new float[,]{{}}),
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
