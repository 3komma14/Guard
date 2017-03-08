using System;
using System.Collections.Generic;
using System.Linq;
using BarsGroup.CodeGuard.PerfomanceTests.Attibutes;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.PerfomanceTests.Validators
{
    public class EnumerableTests
    {
        readonly IEnumerable<string> _enumerable = Enumerable.Repeat(string.Empty, 10);

        //[Theory]
        //[Repeat(10)]
        [Fact]
        public void IsNotEmpty()
        {
            var guardValidator = new Action(() => Guard.That(_enumerable).IsNotEmpty());
            var nativeValidator = new Action(() =>
            {
                // ReSharper disable once UseMethodAny.2
                if (_enumerable.Count() == 0)
                { 
                    throw new Exception();
                }
            });

            PerfTestHelper.RunTest(3.2, guardValidator, nativeValidator);
        }
    }
}