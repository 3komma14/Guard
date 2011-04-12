using System;

namespace Seterlund.CodeGuard
{
    public static class IntegerValidatorExtensions
    {
        public static ValidatorBase<int> IsOdd(this ValidatorBase<int> validator)
        {
            if (!IsOdd(validator.Value))
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(validator);
            }

            return validator;
        }

        public static ValidatorBase<int> IsEven(this ValidatorBase<int> validator)
        {
            if (!IsEven(validator.Value))
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(validator);
            }

            return validator;
        }

        public static ValidatorBase<int> IsPrime(this ValidatorBase<int> validator)
        {
            if(!IsPrime(validator.Value))
            {
                ExceptionHelper.ThrowArgumentException(validator, "Not a prime number");
            }

            return validator;
        }

        private static bool IsOdd(int value)
        {
            return ((value & 1) == 1);
        }

        private static bool IsEven(int value)
        {
            return ((value & 1) == 0);
        }

        private static bool IsPrime(int value)
        {
            // Throw out impossibles
            if (value < 2)
            {
                return false;
            }

            // Don't need to test above the square root of a number
            var squareRootOfValue = (int)Math.Sqrt(value);
            for (var i = 2; i <= squareRootOfValue; i++)
            {
                // If remainder is 0, number is not prime
                if (value % i == 0)
                {
                    // return false
                    return false;
                }
            }

            // If all conditions are met, return true
            return true;
        }

    }
}
