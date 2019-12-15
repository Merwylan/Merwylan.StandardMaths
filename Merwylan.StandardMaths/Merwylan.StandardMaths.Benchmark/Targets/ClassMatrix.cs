using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Merwylan.StandardMaths.Common.Exceptions;
using Merwylan.StandardMaths.Common.Helpers;
using MiscUtil;

namespace Merwylan.StandardMaths.Benchmark.Targets
{
    public class Matrix<T> : IComparable<Matrix<T>> where T : IComparable
    {
        /// <summary>
        /// The wrapper value of the matrix.
        /// </summary>
        public readonly T[,] Value;

        /// <summary>
        /// Returns the identity matrix of the current matrix (the same row length and column width).
        /// </summary>
        public Matrix<T> IdentityMatrix => GetIdentityMatrix(Value.GetLength(0), Value.GetLength(1));

        public bool IsEmpty => Value.Length < 1;
        public bool IsEmptyOrNull => Value is null || IsEmpty;

        public Matrix(T[,] matrix)
        {
            if (matrix is null) throw new ArgumentNullException();
            Value = matrix;
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix) =>
            Add(firstMatrix, secondMatrix);

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix) =>
            Subtract(firstMatrix, secondMatrix);

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix) =>
            Multiply(firstMatrix, secondMatrix);

        /// <summary>
        /// Adds two matrices. Matrices must have the same dimensions.
        /// </summary>
        /// <param name="firstMatrix"></param>
        /// <param name="secondMatrix"></param>
        /// <returns></returns>
        public static Matrix<T> Add(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if(firstMatrix is null) throw new ArgumentNullException(nameof(firstMatrix));
            if(secondMatrix is null) throw new ArgumentNullException(nameof(secondMatrix));

            var firstValue = firstMatrix.Value;
            var secondValue = secondMatrix.Value;

            if (firstValue.GetLength(0) != secondValue.GetLength(0) ||
                firstValue.GetLength(1) != secondValue.GetLength(1))
            {
                throw new DifferentDimensionException(
                    "Matrices must have the same dimensions to perform an addition operation.");
            }

            return AddOrSubtract(firstValue, secondValue);
        }

        /// <summary>
        /// Subtracts two matrices. Matrices must have the same dimensions.
        /// </summary>
        /// <param name="firstMatrix"></param>
        /// <param name="secondMatrix"></param>
        /// <returns></returns>
        public static Matrix<T> Subtract(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix is null) throw new ArgumentNullException(nameof(firstMatrix));
            if (secondMatrix is null) throw new ArgumentNullException(nameof(secondMatrix));

            var firstValue = firstMatrix.Value;
            var secondValue = secondMatrix.Value;

            if (firstValue.GetLength(0) != secondValue.GetLength(0) ||
                firstValue.GetLength(1) != secondValue.GetLength(1))
            {
                throw new DifferentDimensionException("Matrices must have the same dimensions to subtract.");
            }

            return AddOrSubtract(firstValue, secondValue, false);
        }

        private static Matrix<T> AddOrSubtract(T[,] firstValue, T[,] secondValue, bool positive = true)
        {
            var result = firstValue;

            for (var rowIndex = 0; rowIndex < result.GetLength(0); rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < result.GetLength(1); columnIndex++)
                {
                    result[rowIndex, columnIndex] = positive
                        ? Operator<T>.Add(result[rowIndex, columnIndex], secondValue[rowIndex, columnIndex])
                        : Operator<T>.Subtract(result[rowIndex, columnIndex], secondValue[rowIndex, columnIndex]);
                }
            }

            return new Matrix<T>(result);
        }

        /// <summary>
        /// Multiplies two matrices. Column width of first matrix must equal row count of second matrix.
        /// </summary>
        /// <param name="firstMatrix">The first matrix in the multiplication determines the amount of rows in the returned matrix.</param>
        /// <param name="secondMatrix">The second matrix in the multiplication determines the amount of column in the returned matrix.</param>
        /// <returns></returns>
        public static Matrix<T> Multiply(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix is null) throw new ArgumentNullException(nameof(firstMatrix));
            if (secondMatrix is null) throw new ArgumentNullException(nameof(secondMatrix));

            var firstValue = firstMatrix.Value;
            var secondValue = secondMatrix.Value;

            if (firstValue.GetLength(1) != secondValue.GetLength(0))
            {
                throw new DifferentColumnRowLengthException(
                    "Numbers of columns of the first matrix must be equal to the numbers of rows of the second matrix in order to do a multiplication operation.");
            }

            return Dot(firstMatrix.Value, secondMatrix.Value);
        }

        private static Matrix<T> Dot(T[,] firstValue, T[,] secondValue)
        {
            // Row length of matrix 1 equals column length of matrix 2
            int sharedLength = firstValue.GetLength(1);
            int firstMatrixRowSize = firstValue.GetLength(0);
            int secondMatrixColumnSize = secondValue.GetLength(1);

            var result = new T[firstMatrixRowSize, secondMatrixColumnSize];

            for (var rowIndex = 0; rowIndex < firstMatrixRowSize; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < secondMatrixColumnSize; columnIndex++)
                {
                    result[rowIndex, columnIndex] =
                        MultiplyRowColumn(rowIndex, columnIndex, firstValue, secondValue);
                }
            }

            return new Matrix<T>(result);
        }

        /// <summary>
        /// Returns the matrix to the power of n.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="n">Exponent.</param>
        /// <returns></returns>
        public static Matrix<T> Power(Matrix<T> matrix, int n)
        {
            if (matrix is null) throw new ArgumentNullException(nameof(matrix));

            if (matrix.IsEmpty) return matrix;

            if (n < 0)
                throw new InvalidMatrixOperationException("Power is not allowed to be lower than 0.");
            if (matrix.Value.GetLength(0) != matrix.Value.GetLength(1))
                throw new InvalidMatrixOperationException("Power operation is only allowed on square matrices.");

            return n == 0 ? GetIdentityMatrix(matrix.Value.GetLength(0), matrix.Value.GetLength(1)) : Pow(matrix, n);
        }

        private static Matrix<T> Pow(Matrix<T> matrix, int n)
        {
            var result = matrix;
            var remainder = matrix.IdentityMatrix;

            while (n > 1)
            {
                if (n % 2 == 0)
                {
                    result *= result;
                    n /= 2;
                }
                else
                {
                    remainder *= result;
                    result *= result;
                    n = (n - 1) / 2;
                }
            }

            return result * remainder;
        }

        private static Matrix<T> GetIdentityMatrix(int rowCount, int columnCount)
        {
            var identity = new T[rowCount, columnCount];

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    var one = CommonHelper.TryConvert<T>(1, out var succeeded);

                    if (!succeeded) throw new Exception("An unexpected exception has been thrown.");

                    identity[i, j] = IsCellDiagonal(i, j) ? one : Operator<T>.Zero;
                }
            }

            return new Matrix<T>(identity);
        }

        private static T MultiplyRowColumn(int rowIndex, int columnIndex, T[,] firstMatrix, T[,] secondMatrix)
        {
            T temp = Operator<T>.Zero;

            for (var cellIndex = 0; cellIndex < firstMatrix.GetLength(1); cellIndex++)
            {
                temp = Operator.Add<T>(temp,
                    Operator.Multiply<T>(firstMatrix[rowIndex, cellIndex], secondMatrix[cellIndex, columnIndex]));
            }

            return temp;
        }

        private static bool IsCellDiagonal(int rowIdx, int columnIdx) => rowIdx == columnIdx;

        public int CompareTo(Matrix<T> obj)
        {
            var equal =
                Value.Rank == obj.Value.Rank &&
                Enumerable.Range(0, Value.Rank)
                    .All(dimension => Value.GetLength(dimension) == obj.Value.GetLength(dimension)) &&
                Value.Cast<T>().SequenceEqual(obj.Value.Cast<T>());
            return equal ? 0 : -1;
        }
    }
}
