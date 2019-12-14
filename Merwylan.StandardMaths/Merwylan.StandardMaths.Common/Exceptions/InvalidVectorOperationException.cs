using System;
using System.Collections.Generic;
using System.Text;

namespace Merwylan.StandardMaths.Common.Exceptions
{
    class InvalidVectorOperationException : Exception
    {
        public InvalidVectorOperationException(string msg, Exception innerException = null) : base(msg, innerException) { }
    }
}
