using System;
using System.Collections.Generic;
using BarsGroup.CodeGuard.PerfomanceTests.Attibutes;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.PerfomanceTests.Validators
{
    public class CollectionTests
    {
        private const long DefaultReply = 100000000;

        [Theory]
        [Repeat(10)]
        public void IsNotEmpty()
        {
            var collection = new List<int> {1, 2, 3};

            var guardValidator = new Action(() => Guard.That(collection).IsNotEmpty());
            var nativeValidator = new Action(() =>
            {
                // ReSharper disable once UseMethodAny.2
                if (collection.Count == 0)
                { 
                    throw new Exception();
                }
            });

            PerfTestHelper.RunTest(3.5, DefaultReply, guardValidator, nativeValidator);
        }

    }
}