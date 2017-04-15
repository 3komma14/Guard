using System;
using System.Linq;
using BarsGroup.CodeGuard.PerfomanceTests.Attibutes;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.PerfomanceTests.Validators
{
    public class BooleanTests
    {
        private const long DefaultReply = 100000000;

        [Theory]
        [Repeat(10)]
        public void IsTrue()
        {
            var b = true;
            var guardValidator = new Action(() => Guard.That(b).IsTrue());
            var nativeValidator = new Action(() =>
            {
                // ReSharper disable once UseMethodAny.2
                if (b != true)
                { 
                    throw new Exception();
                }
            });

            PerfTestHelper.RunTest(5.4, DefaultReply, guardValidator, nativeValidator);
        }

        [Theory]
        [Repeat(10)]
        public void IsFalse()
        {
            var b = false;
            var guardValidator = new Action(() => Guard.That(b).IsFalse());
            var nativeValidator = new Action(() =>
            {
                // ReSharper disable once UseMethodAny.2
                if (b != false)
                {
                    throw new Exception();
                }
            });

            PerfTestHelper.RunTest(5.4, DefaultReply, guardValidator, nativeValidator);
        }
    }
}