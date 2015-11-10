using System;
using Seterlund.CodeGuard.Internals;
using System.Diagnostics.Contracts;

namespace Seterlund.CodeGuard
{

    public static class IntegerValidatorExtensions
    {
        public static IArg<int> IsOdd(this IArg<int> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
#endif
            if (!MathUtil.IsOdd(arg.Value))
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<long> IsOdd(this IArg<long> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
#endif
            if (!MathUtil.IsOdd(arg.Value))
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<int> IsEven(this IArg<int> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
#endif
            if (!MathUtil.IsEven(arg.Value))
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<long> IsEven(this IArg<long> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
#endif
            if (!MathUtil.IsEven(arg.Value))
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<int> IsPrime(this IArg<int> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
#endif
            if (!MathUtil.IsPrime(arg.Value))
            {
                arg.Message.Set("Not a prime number");
            }

            return arg;
        }

        public static IArg<long> IsPrime(this IArg<long> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
#endif
            if (!MathUtil.IsPrime(arg.Value))
            {
                arg.Message.Set("Not a prime number");
            }

            return arg;
        }

        public static IArg<long> IsPositive(this IArg<long> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
#endif
            if (arg.Value <= 0)
            {
                arg.Message.Set("Is not positive");
            }

            return arg;
        }

        public static IArg<int> IsPositive(this IArg<int> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
#endif
            if (arg.Value <= 0)
            {
                arg.Message.Set("Is not positive");
            }

            return arg;
        }

        public static IArg<long> IsNegative(this IArg<long> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<long>>() != null);
#endif
            if (arg.Value >= 0)
            {
                arg.Message.Set("Is not negative");
            }

            return arg;
        }

        public static IArg<int> IsNegative(this IArg<int> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<int>>() != null);
#endif
            if (arg.Value >= 0)
            {
                arg.Message.Set("Is not negative");
            }

            return arg;
        }
    }
}
