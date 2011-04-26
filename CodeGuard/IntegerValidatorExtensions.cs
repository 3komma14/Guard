using System;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard
{
    public static class IntegerValidatorExtensions
    {
        public static ValidatorBase<int> IsOdd(this ValidatorBase<int> validator)
        {
            if (!MathUtil.IsOdd(validator.Value))
            {
                validator.ArgumentOutRangeMessage();
            }

            return validator;
        }

        public static ValidatorBase<long> IsOdd(this ValidatorBase<long> validator)
        {
            if (!MathUtil.IsOdd(validator.Value))
            {
                validator.ArgumentOutRangeMessage();
            }

            return validator;
        }

        public static ValidatorBase<int> IsEven(this ValidatorBase<int> validator)
        {
            if (!MathUtil.IsEven(validator.Value))
            {
                validator.ArgumentOutRangeMessage();
            }

            return validator;
        }

        public static ValidatorBase<long> IsEven(this ValidatorBase<long> validator)
        {
            if (!MathUtil.IsEven(validator.Value))
            {
                validator.ArgumentOutRangeMessage();
            }

            return validator;
        }

        public static ValidatorBase<int> IsPrime(this ValidatorBase<int> validator)
        {
            if(!MathUtil.IsPrime(validator.Value))
            {
                validator.ArgumentMessage("Not a prime number");
            }

            return validator;
        }

        public static ValidatorBase<long> IsPrime(this ValidatorBase<long> validator)
        {
            if(!MathUtil.IsPrime(validator.Value))
            {
                validator.ArgumentMessage("Not a prime number");
            }

            return validator;
        }
    }
}
