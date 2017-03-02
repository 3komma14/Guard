using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class IntegerValidatorExtensions
    {
        public static IArg<int> IsOdd(this IArg<int> arg)
        {
            Guard.That(arg).IsNotNull();


            if (!MathUtil.IsOdd(arg.Value))
            {
                var message = ErrorMessageFactory.NotOddNumber(arg);
                arg.ThrowArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<long> IsOdd(this IArg<long> arg)
        {
            Guard.That(arg).IsNotNull();


            if (!MathUtil.IsOdd(arg.Value))
            {
                var message = ErrorMessageFactory.NotOddNumber(arg);
                arg.ThrowArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<int> IsEven(this IArg<int> arg)
        {
            Guard.That(arg).IsNotNull();


            if (!MathUtil.IsEven(arg.Value))
            {
                var message = ErrorMessageFactory.NotEvenNumber(arg);
                arg.ThrowArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<long> IsEven(this IArg<long> arg)
        {
            Guard.That(arg).IsNotNull();


            if (!MathUtil.IsEven(arg.Value))
            {
                var message = ErrorMessageFactory.NotEvenNumber(arg);
                arg.ThrowArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<int> IsPrime(this IArg<int> arg)
        {
            Guard.That(arg).IsNotNull();


            if (!MathUtil.IsPrime(arg.Value))
            {
                var message = ErrorMessageFactory.NotPrimeNumber(arg);
                arg.ThrowArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<long> IsPrime(this IArg<long> arg)
        {
            Guard.That(arg).IsNotNull();


            if (!MathUtil.IsPrime(arg.Value))
            {
                var message = ErrorMessageFactory.NotPrimeNumber(arg);
                arg.ThrowArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<long> IsPositive(this IArg<long> arg)
        {
            Guard.That(arg).IsNotNull();


            if (arg.Value <= 0)
            {
                var message = ErrorMessageFactory.NotPositiveNumber(arg);
                arg.ThrowArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<int> IsPositive(this IArg<int> arg)
        {
            Guard.That(arg).IsNotNull();


            if (arg.Value <= 0)
            {
                var message = ErrorMessageFactory.NotPositiveNumber(arg);
                arg.ThrowArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<long> IsNegative(this IArg<long> arg)
        {
            Guard.That(arg).IsNotNull();

            if (arg.Value >= 0)
            {
                var message = ErrorMessageFactory.NotNegativeNumber(arg);
                arg.ThrowArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<int> IsNegative(this IArg<int> arg)
        {
            Guard.That(arg).IsNotNull();


            if (arg.Value >= 0)
            {
                var message = ErrorMessageFactory.NotNegativeNumber(arg);
                arg.ThrowArgumentOutRange(message);
            }

            return arg;
        }
    }
}