using System;
using System.Collections.Generic;
using System.Text;

namespace Merwylan.StandardMaths.Common.Extensions
{ 
    public static class MatrixExtensions
    {
        public static bool IsSquare<T>(this Matrix<T> matrix) where T:IComparable =>
            matrix.Value.GetLength(0) == matrix.Value.GetLength(1);
        
    }
}
