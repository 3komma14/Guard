using System;
using System.Diagnostics;
using NUnit.Framework;
using Seterlund.CodeGuard.Validators;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class SpeedTests
    {
        [Test]
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

        [Test]
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

    }

}
