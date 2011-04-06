using System;

namespace Seterlund.CodeGuard
{
    public static class IComparableValidatorExtensions
    {
        public static ValidatorBase<T> IsEqual<T>(this ValidatorBase<T> validator, T argument) where T : IComparable
        {
            return IsEqual(validator, () => argument);
        }

        public static ValidatorBase<T> IsEqual<T>(this ValidatorBase<T> validator, Func<T> argument) where T : IComparable
        {
            if (validator.Value.CompareTo(argument()) != 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(validator);
            }

            return validator;
        }

        public static ValidatorBase<T> IsGreaterThan<T>(this ValidatorBase<T> validator, T argument) where T : IComparable
        {
            return IsGreaterThan(validator, () => argument);
        }

        public static ValidatorBase<T> IsGreaterThan<T>(this ValidatorBase<T> validator, Func<T> argument) where T : IComparable
        {
            if (validator.Value.CompareTo(argument()) <= 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(validator);
            }

            return validator;
        }

        public static ValidatorBase<T> IsLessThan<T>(this ValidatorBase<T> validator, T argument) where T : IComparable
        {
            return IsLessThan(validator, () => argument);
        }

        public static ValidatorBase<T> IsLessThan<T>(this ValidatorBase<T> validator, Func<T> argument) where T : IComparable
        {
            if (validator.Value.CompareTo(argument()) >= 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(validator);
            }

            return validator;
        }

        public static ValidatorBase<T> IsInRange<T>(this ValidatorBase<T> validator, T start, T end) where T : IComparable
        {
            if (validator.Value.CompareTo(start) < 0 || validator.Value.CompareTo(end) > 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(validator);
            }

            return validator;
        }
    }
}