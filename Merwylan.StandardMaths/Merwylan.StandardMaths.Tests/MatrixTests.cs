using System;
using System.Runtime.InteropServices;
using Merwylan.StandardMaths.Common;
using Merwylan.StandardMaths.Common.Exceptions;
using Merwylan.StandardMaths.Tests.Input.Composed;
using Xunit;

namespace Merwylan.StandardMaths.Tests
{
    public class MatrixTests
    {
        [ClassData(typeof(AdditionMatrices))]
        [Theory]
        public void Add_Matrix_Same_Dimensions_Should_Return_Summed_Matrix<T>(Matrix<T> matrix1, Matrix<T> matrix2, Matrix<T> expected) 
            where T:IComparable
        {
            var result = matrix1 + matrix2;
            Assert.Equal(expected, result);
        }

        [ClassData(typeof(AdditionSubtractionThrowMatrices))]
        [Theory]
        public void Add_Matrix_Different_Dimensions_Should_Throw_DifferentDimensionException<T>(Matrix<T> matrix1,
            Matrix<T> matrix2) where T : IComparable
        {
            Assert.Throws<DifferentDimensionException>(() => Matrix<T>.Add(matrix1, matrix2));
        }

        [ClassData(typeof(SubtractionMatrices))]
        [Theory]
        public void Subtract_Matrix_Same_Dimensions_Should_Return_Subtracted_Matrix<T>(Matrix<T> matrix1, Matrix<T> matrix2, Matrix<T> expected) 
            where T : IComparable
        {
            var result = matrix1 - matrix2;
            Assert.Equal(expected, result);
        }

        [ClassData(typeof(AdditionSubtractionThrowMatrices))]
        [Theory]
        public void Subtract_Matrix_Different_Dimensions_Should_Throw_DifferentDimensionException<T>(Matrix<T> matrix1,
            Matrix<T> matrix2) where T : IComparable
        {
            Assert.Throws<DifferentDimensionException>(() => Matrix<T>.Subtract(matrix1, matrix2));
        }


        [ClassData(typeof(MultiplicationMatrices))]
        [Theory]
        public void Multiply_Matrix_Same_ColumnRowLength_Should_Return_Multiplied_Matrix<T>(Matrix<T> matrix1, Matrix<T> matrix2, Matrix<T> expected) 
            where T : IComparable
        {
            var result = matrix1 * matrix2;
            Assert.Equal(expected, result);
        }

        [ClassData(typeof(MultiplicationThrowMatrices))]
        [Theory]
        public void Multiply_Matrix_Different_ColumnRowLength_Should_Throw_DifferentColumnRowLengthException<T>(Matrix<T> matrix1,Matrix<T> matrix2) 
            where T:IComparable
        {
            Assert.Throws<DifferentColumnRowLengthException>(() => Matrix<T>.Multiply(matrix1,matrix2));
        }

        [ClassData(typeof(PowerMatrices))]
        [Theory]
        public void Power_Matrix_Square_Should_Return_Powered_Matrix<T>(Matrix<T> matrix, int power, Matrix<T> expected) where T:IComparable
        {
            var actual = Matrix<T>.Power(matrix, power);
            Assert.Equal(expected, actual);
        }

        [ClassData(typeof(PowerThrowMatrices))]
        [Theory]
        public void Power_Matrix_NotSquare_Should_Throw_InvalidMatrixOperationException<T>(Matrix<T> matrix, int power) where T:IComparable
        {
            Assert.Throws<InvalidMatrixOperationException>(() => Matrix<T>.Power(matrix,power));
        }

    }
}
