using CodeGuard.dotNetCore.Validators;
using System;
using System.Diagnostics;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests
{
    public class SpeedTests
    {
        #region Public Methods

        [Fact]
        public void TestLambdaExpressionSpeed()
        {
            var arg = 0;

            var watch = new Stopwatch();
            watch.Start();

            var start = DateTime.Now;
            for (int i = 0; i < 10000; i++)
            {
                //arg = i;
                Guard.That(() => arg).IsEven();
            }
            var end = DateTime.Now;
            var diff = end.Subtract(start);

            watch.Stop();

            Console.WriteLine(diff.TotalMilliseconds);
            Console.WriteLine(watch.Elapsed);
            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        [Fact]
        public void TestVariableSpeed()
        {
            var arg = 0;

            var watch = new Stopwatch();
            watch.Start();

            var start = DateTime.Now;
            for (int i = 0; i < 10000; i++)
            {
                Guard.That(arg).IsEven();
            }
            var end = DateTime.Now;
            var diff = end.Subtract(start);

            watch.Stop();

            Console.WriteLine(diff.TotalMilliseconds);
            Console.WriteLine(watch.Elapsed);
            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        #endregion Public Methods
    }
}
