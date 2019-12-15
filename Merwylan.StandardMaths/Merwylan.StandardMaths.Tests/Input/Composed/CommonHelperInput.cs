using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Merwylan.StandardMaths.Tests.Input.Composed
{
    public class ConvertIntToDoubleInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                1,
                1d
            };
            yield return new object[]
            {
                6,
                6d
            };
            yield return new object[]
            {
                -12341,
                -12341d
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class ConvertDoubleToIntInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                123.3565,
                123
            };
            yield return new object[]
            {
                6.1,
                6
            };
            yield return new object[]
            {
                0d,
                0
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
