//using System;
//using NUnit.Framework;

//namespace Seterlund.CodeGuard.UnitTests
//{
//    [TestFixture]
//    [Ignore]
//    public class SpeedTests
//    {
//        [Test]
//        public void TestLambdaExpressionSpeed()
//        {
//            var arg = 0;

//            var start = DateTime.Now;
//            for (int i = 0; i < 10000; i++ )
//            {
//                //arg = i;
//                Guard.That(() => arg).IsEven();                
//            }
//            var end = DateTime.Now;
//            var diff = end.Subtract(start);

//            Console.WriteLine(diff.TotalMilliseconds);
//        }

//        [Test]
//        public void TestVariableSpeed()
//        {
//            var arg = 0;

//            var start = DateTime.Now;
//            for (int i = 0; i < 10000; i++)
//            {
//                Guard.That(arg).IsEven();
//            }
//            var end = DateTime.Now;
//            var diff = end.Subtract(start);

//            Console.WriteLine(diff.TotalMilliseconds);
//        }

//    }
//}
