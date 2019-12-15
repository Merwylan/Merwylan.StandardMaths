using System;
using System.Collections.Generic;
using System.Text;

namespace Merwylan.StandardMaths.Common.Helpers
{
    public static class CommonHelper
    {
        public static bool TryConvert<T>(object value, out T converted)
        {
            converted = default(T);

            try
            {
                converted = (T)Convert.ChangeType(value, typeof(T));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
