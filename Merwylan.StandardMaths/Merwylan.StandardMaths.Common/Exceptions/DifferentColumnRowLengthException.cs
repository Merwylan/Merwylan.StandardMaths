using System;
using System.Collections.Generic;
using System.Text;

namespace Merwylan.StandardMaths.Common.Exceptions
{
    public class DifferentColumnRowLengthException : InvalidMatrixOperationException
    {
        public DifferentColumnRowLengthException(string msg, Exception innerException = null) : base(msg, innerException) { }
    }
}
