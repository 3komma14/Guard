using System;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard
{
    public static class IntegerValidatorExtensions
    {
        public static ArgumentBase<int> IsOdd(this ArgumentBase<int> argument)
        {
            if (!MathUtil.IsOdd(argument.Value))
            {
                argument.ArgumentOutRangeMessage();
            }

            return argument;
        }

        public static ArgumentBase<long> IsOdd(this ArgumentBase<long> argument)
        {
            if (!MathUtil.IsOdd(argument.Value))
            {
                argument.ArgumentOutRangeMessage();
            }

            return argument;
        }

        public static ArgumentBase<int> IsEven(this ArgumentBase<int> argument)
        {
            if (!MathUtil.IsEven(argument.Value))
            {
                argument.ArgumentOutRangeMessage();
            }

            return argument;
        }

        public static ArgumentBase<long> IsEven(this ArgumentBase<long> argument)
        {
            if (!MathUtil.IsEven(argument.Value))
            {
                argument.ArgumentOutRangeMessage();
            }

            return argument;
        }

        public static ArgumentBase<int> IsPrime(this ArgumentBase<int> argument)
        {
            if(!MathUtil.IsPrime(argument.Value))
            {
                argument.ArgumentMessage("Not a prime number");
            }

            return argument;
        }

        public static ArgumentBase<long> IsPrime(this ArgumentBase<long> argument)
        {
            if(!MathUtil.IsPrime(argument.Value))
            {
                argument.ArgumentMessage("Not a prime number");
            }

            return argument;
        }
    }
}
