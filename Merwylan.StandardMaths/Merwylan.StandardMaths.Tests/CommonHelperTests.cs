using System;
using System.Collections.Generic;
using System.Text;
using Merwylan.StandardMaths.Common.Helpers;
using Merwylan.StandardMaths.Tests.Input.Composed;
using Xunit;

namespace Merwylan.StandardMaths.Tests
{
    public class CommonHelperTests
    {
        [ClassData(typeof(ConvertIntToDoubleInput))]
        [Theory]
        public void Convert_Integer_To_Double_Should_Convert(int input, double expected)
        {
            var actual = CommonHelper.TryConvert<double>(input, out var hasConverted);
            Assert.Equal(expected,actual);
            Assert.True(hasConverted);
        }

        [ClassData(typeof(ConvertDoubleToIntInput))]
        [Theory]
        public void Convert_Double_To_Integer_Should_Convert(double input, int expected)
        {
            var actual = CommonHelper.TryConvert<int>(input, out var hasConverted);
            Assert.Equal(expected, actual);
            Assert.True(hasConverted);
        }
    }
}
