using System;
using System.Collections.Generic;
using System.Text;

namespace Merwylan.StandardMaths.Common.Exceptions
{
    public class InvalidMatrixOperationException : Exception
    {
        public InvalidMatrixOperationException(string msg, Exception innerException = null) : base(msg, innerException) {}
    }
}
