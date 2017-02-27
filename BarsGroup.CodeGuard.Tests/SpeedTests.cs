using System;
using System.Diagnostics;
using BarsGroup.CodeGuard.Validators;
using Xunit;
using Xunit.Abstractions;

namespace BarsGroup.CodeGuard.Tests
{
    
    public class SpeedTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public SpeedTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        //[Fact]
        public void TestLambdaExpressionSpeed()
        {
            var arg = 0;

            var watch = new Stopwatch();
            watch.Start();

            var start = DateTime.Now;
            for (var i = 0; i < 10000000; i++)
            {
                //arg = i;
                Guard.That(arg).IsEven();
            }
            var end = DateTime.Now;
            var diff = end.Subtract(start);

            watch.Stop();

            
            _outputHelper.WriteLine("Total Milliseconds : {0}", diff.TotalMilliseconds);
            _outputHelper.WriteLine("Elapsed : {0}", watch.Elapsed);
            _outputHelper.WriteLine("Elapsed Milliseconds : {0}", watch.ElapsedMilliseconds);
        }
        
    }

}
