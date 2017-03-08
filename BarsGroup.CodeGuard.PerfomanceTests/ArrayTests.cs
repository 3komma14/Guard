using System;
using System.Diagnostics;
using System.Linq;
using BarsGroup.CodeGuard.PerfomanceTests.Attibutes;
using BarsGroup.CodeGuard.Validators;
using Xunit;
using Xunit.Abstractions;

namespace BarsGroup.CodeGuard.PerfomanceTests
{
    public class ArrayTests
    {
        [Theory]
        [Repeat(20)]
        public void IsEmpty()
        {
            var array = Enumerable.Repeat(string.Empty, 10);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                Guard.That(array).IsNotEmpty();
            }
            watch.Stop();

            var guardTime = watch.ElapsedMilliseconds;

            watch.Reset();
            watch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                // ReSharper disable once UseMethodAny.2
                if (array.Count() == 0)
                {
                    throw new Exception();
                }
            }

            watch.Stop();
            var natimeTime = watch.ElapsedMilliseconds;

            Assert.True(guardTime / natimeTime <= 4);
        }
    }
}