using System;
using System.Linq;
using BarsGroup.CodeGuard.PerfomanceTests.Attibutes;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.PerfomanceTests.Validators
{
    public class ArrrayTests
    {
        private const long DefaultReply = 10000000;

        [Theory]
        [Repeat(10)]
        public void IsNotEmpty()
        {
            var array = Enumerable.Repeat(string.Empty, 10).ToArray();
            var guardValidator = new Action(() => Guard.That(array).IsNotEmpty());
            var nativeValidator = new Action(() =>
            {
                // ReSharper disable once UseMethodAny.2
                if (array.Length == 0)
                { 
                    throw new Exception();
                }
            });

            PerfTestHelper.RunTest(8.6, DefaultReply*5, guardValidator, nativeValidator);
        }

        [Theory]
        [Repeat(10)]
        public void CountIs()
        {
            var array = Enumerable.Repeat(string.Empty, 10).ToArray();
            var guardValidator = new Action(() => Guard.That(array).CountIs(10));
            var nativeValidator = new Action(() =>
            {
                // ReSharper disable once UseMethodAny.2
                if (array.Length != 10)
                {
                    throw new Exception();
                }
            });

            PerfTestHelper.RunTest(8.9, DefaultReply*10, guardValidator, nativeValidator);
        }
    }
}