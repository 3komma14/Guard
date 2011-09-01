using System;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard
{
    public static class IntegerValidatorExtensions
    {
        public static Arg<int> IsOdd(this Arg<int> arg)
        {
            if (!MathUtil.IsOdd(arg.Value))
            {
                arg.ArgumentOutRangeMessage();
            }

            return arg;
        }

        public static Arg<long> IsOdd(this Arg<long> arg)
        {
            if (!MathUtil.IsOdd(arg.Value))
            {
                arg.ArgumentOutRangeMessage();
            }

            return arg;
        }

        public static Arg<int> IsEven(this Arg<int> arg)
        {
            if (!MathUtil.IsEven(arg.Value))
            {
                arg.ArgumentOutRangeMessage();
            }

            return arg;
        }

        public static Arg<long> IsEven(this Arg<long> arg)
        {
            if (!MathUtil.IsEven(arg.Value))
            {
                arg.ArgumentOutRangeMessage();
            }

            return arg;
        }

        public static Arg<int> IsPrime(this Arg<int> arg)
        {
            if(!MathUtil.IsPrime(arg.Value))
            {
                arg.ArgumentMessage("Not a prime number");
            }

            return arg;
        }

        public static Arg<long> IsPrime(this Arg<long> arg)
        {
            if(!MathUtil.IsPrime(arg.Value))
            {
                arg.ArgumentMessage("Not a prime number");
            }

            return arg;
        }
    }
}
