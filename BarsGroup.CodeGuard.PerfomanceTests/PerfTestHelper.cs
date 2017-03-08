using System;
using System.Diagnostics;
using Xunit;

namespace BarsGroup.CodeGuard.PerfomanceTests
{
    internal static class PerfTestHelper
    {
        public static void RunTest(double maxCoef, Action guardValidator, Action nativeValidator )
        {
            var watch = new Stopwatch();
            watch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                guardValidator();
            }
            watch.Stop();

            var guardTime = watch.ElapsedMilliseconds;

            watch.Reset();
            watch.Start();
            for (var i = 0; i < 10000000; i++)
            {
                nativeValidator();
            }

            watch.Stop();
            var natimeTime = watch.ElapsedMilliseconds;

            Assert.True(Math.Round((float)guardTime / natimeTime, 2) <= maxCoef, $"Guard time - {guardTime}, native time - {natimeTime}");
        }

    }
}