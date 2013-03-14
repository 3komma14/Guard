using System;
using $rootnamespace$.CodeGuard.Internals;

namespace $rootnamespace$.CodeGuard
{
    public static class IntegerValidatorExtensions
    {
        public static IArg<int> IsOdd(this IArg<int> arg)
        {
            if (!MathUtil.IsOdd(arg.Value))
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<long> IsOdd(this IArg<long> arg)
        {
            if (!MathUtil.IsOdd(arg.Value))
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<int> IsEven(this IArg<int> arg)
        {
            if (!MathUtil.IsEven(arg.Value))
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<long> IsEven(this IArg<long> arg)
        {
            if (!MathUtil.IsEven(arg.Value))
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<int> IsPrime(this IArg<int> arg)
        {
            if(!MathUtil.IsPrime(arg.Value))
            {
                arg.Message.Set("Not a prime number");
            }

            return arg;
        }

        public static IArg<long> IsPrime(this IArg<long> arg)
        {
            if(!MathUtil.IsPrime(arg.Value))
            {
                arg.Message.Set("Not a prime number");
            }

            return arg;
        }
    }
}
