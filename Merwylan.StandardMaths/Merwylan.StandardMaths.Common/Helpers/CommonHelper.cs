using System;
using System.Collections.Generic;
using System.Text;

namespace Merwylan.StandardMaths.Common.Helpers
{
    public static class CommonHelper
    {
        public static T TryConvert<T>(object value, out bool hasConverted)
        {
            var converted = default(T);

            try
            {
                converted = (T)Convert.ChangeType(value, typeof(T));
                hasConverted = true;
            }
            catch
            {
                hasConverted = false;
            }

            return converted;
        }
    }
}
