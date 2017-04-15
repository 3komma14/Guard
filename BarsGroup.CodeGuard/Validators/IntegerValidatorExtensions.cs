using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class IntegerValidatorExtensions
    {
        public static ArgBase<int> IsOdd(this ArgBase<int> arg)
        {
            if (!MathUtil.IsOdd(arg.Value))
                arg.ThrowOddValueExpected();

            return arg;
        }

        public static ArgBase<long> IsOdd(this ArgBase<long> arg)
        {
            if (!MathUtil.IsOdd(arg.Value))
                arg.ThrowOddValueExpected();

            return arg;
        }

        public static ArgBase<int> IsEven(this ArgBase<int> arg)
        {
            if (!MathUtil.IsEven(arg.Value))
                arg.ThrowEvenValueExpected();

            return arg;
        }

        public static ArgBase<long> IsEven(this ArgBase<long> arg)
        {
            if (!MathUtil.IsEven(arg.Value))
                arg.ThrowEvenValueExpected();

            return arg;
        }

        public static ArgBase<int> IsPrime(this ArgBase<int> arg)
        {
            if (!MathUtil.IsPrime(arg.Value))
                arg.ThrowPrimeValueExpected();

            return arg;
        }

        public static ArgBase<long> IsPrime(this ArgBase<long> arg)
        {
            if (!MathUtil.IsPrime(arg.Value))
                arg.ThrowPrimeValueExpected();

            return arg;
        }

        public static ArgBase<long> IsPositive(this ArgBase<long> arg)
        {
            if (arg.Value <= 0)
            {
                arg.ThrowPositiveValueExpected();
            }

            return arg;
        }

        public static ArgBase<int> IsPositive(this ArgBase<int> arg)
        {
            if (arg.Value <= 0)
            {
                arg.ThrowPositiveValueExpected();
            }

            return arg;
        }

        public static ArgBase<long> IsNegative(this ArgBase<long> arg)
        {
            if (arg.Value >= 0)
            {
                arg.ThrowNegativeValueExpected();
            }

            return arg;
        }

        public static ArgBase<int> IsNegative(this ArgBase<int> arg)
        {
            if (arg.Value >= 0)
            {
                arg.ThrowNegativeValueExpected();
            }

            return arg;
        }
    }
}