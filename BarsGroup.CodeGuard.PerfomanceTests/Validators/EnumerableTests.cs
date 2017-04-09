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
        private const long DefaultReply = 10000000;

        [Theory]
        [Repeat(10)]
        public void IsNotEmpty()
        {
            var enumerable = Enumerable.Repeat(string.Empty, 10);
            var guardValidator = new Action(() => Guard.That(enumerable).IsNotEmpty());
            var nativeValidator = new Action(() =>
            {
                // ReSharper disable once UseMethodAny.2
                if (enumerable.Count() == 0)
                { 
                    throw new Exception();
                }
            });

            PerfTestHelper.RunTest(1.65, DefaultReply*5, guardValidator, nativeValidator);
        }

        [Theory]
        [Repeat(10)]
        public void Length()
        {
            var enumerable = Enumerable.Repeat(string.Empty, 10);
            var guardValidator = new Action(() => Guard.That(enumerable).Length(10));
            var nativeValidator = new Action(() =>
            {
                // ReSharper disable once UseMethodAny.2
                if (enumerable.Count() != 10)
                {
                    throw new Exception();
                }
            });

            PerfTestHelper.RunTest(1.65, DefaultReply, guardValidator, nativeValidator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemsCount"></param>
        /// <param name="repliesCount"></param>
        [Theory]
        [InlineData(5000, 100000)]
        [InlineData(50000, 10000)]
        [InlineData(500000, 1000)]
        [Repeat(1)]
        public void Contains_Value(int itemsCount, long repliesCount)
        {
            var list = new List<string>(Enumerable.Repeat(string.Empty, itemsCount)) {"test", "test"};
            var dataSource = list.AsEnumerable();

            var guardValidator = new Action(() => Guard.That(dataSource).Contains("test"));
            var nativeValidator = new Action(() =>
            {
                // ReSharper disable once UseMethodAny.2
                if (!dataSource.Contains("test"))
                {
                    throw new Exception();
                }
            });

            PerfTestHelper.RunTest(1.1, repliesCount, guardValidator, nativeValidator);

        }


        [Theory]
        [InlineData(3000, 50000)]
        [Repeat(1)]
        public void Contains_Pred(int itemsCount, long repliesCount)
        {
            var list = new List<string>(Enumerable.Repeat(string.Empty, itemsCount)) { "test", "test" };
            var dataSource = list.AsEnumerable();
            var guardValidator = new Action(() => Guard.That(dataSource).Contains(text => text == "test"));
            var nativeValidator = new Action(() =>
            {
                // ReSharper disable once UseMethodAny.2
                if (dataSource.All(text => text != "test"))
                {
                    throw new Exception();
                }
            });

            PerfTestHelper.RunTest(1.3, repliesCount, guardValidator, nativeValidator);
        }
    }
}