using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class IntegerValidatorExtensions
    {
        public static IArg<int> IsOdd(this IArg<int> arg)
        {
            Guard.That(arg).IsNotNull();

            if (!MathUtil.IsOdd(arg.Value))
                arg.ThrowOddValueExpected();

            return arg;
        }

        public static IArg<long> IsOdd(this IArg<long> arg)
        {
            Guard.That(arg).IsNotNull();

            if (!MathUtil.IsOdd(arg.Value))
                arg.ThrowOddValueExpected();

            return arg;
        }

        public static IArg<int> IsEven(this IArg<int> arg)
        {
            Guard.That(arg).IsNotNull();

            if (!MathUtil.IsEven(arg.Value))
                arg.ThrowEvenValueExpected();

            return arg;
        }

        public static IArg<long> IsEven(this IArg<long> arg)
        {
            Guard.That(arg).IsNotNull();

            if (!MathUtil.IsEven(arg.Value))
                arg.ThrowEvenValueExpected();

            return arg;
        }

        public static IArg<int> IsPrime(this IArg<int> arg)
        {
            Guard.That(arg).IsNotNull();

            if (!MathUtil.IsPrime(arg.Value))
                arg.ThrowPrimeValueExpected();

            return arg;
        }

        public static IArg<long> IsPrime(this IArg<long> arg)
        {
            Guard.That(arg).IsNotNull();

            if (!MathUtil.IsPrime(arg.Value))
                arg.ThrowPrimeValueExpected();

            return arg;
        }

        public static IArg<long> IsPositive(this IArg<long> arg)
        {
            Guard.That(arg).IsNotNull();

            if (arg.Value <= 0)
            {
                arg.ThrowPositiveValueExpected();
            }

            return arg;
        }

        public static IArg<int> IsPositive(this IArg<int> arg)
        {
            Guard.That(arg).IsNotNull();


            if (arg.Value <= 0)
            {
                arg.ThrowPositiveValueExpected();
            }

            return arg;
        }

        public static IArg<long> IsNegative(this IArg<long> arg)
        {
            Guard.That(arg).IsNotNull();

            if (arg.Value >= 0)
            {
                arg.ThrowNegativeValueExpected();
            }

            return arg;
        }

        public static IArg<int> IsNegative(this IArg<int> arg)
        {
            Guard.That(arg).IsNotNull();


            if (arg.Value >= 0)
            {
                arg.ThrowNegativeValueExpected();
            }

            return arg;
        }
    }
}