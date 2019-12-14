using System;
using System.Collections.Generic;
using System.Text;

namespace Merwylan.StandardMaths.Common.Exceptions
{
    public class DifferentDimensionException : InvalidMatrixOperationException
    {
        public DifferentDimensionException(string msg, Exception innerException = null) : base(msg, innerException) { }
    }
}
