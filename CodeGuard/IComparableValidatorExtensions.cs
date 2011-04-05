using System;

namespace Seterlund.CodeGuard
{
    public static class IComparableValidatorExtensions
    {
        public static ArgumentValidatorBase<T> IsEqual<T>(this ArgumentValidatorBase<T> argumentValidator, T argument) where T : IComparable
        {
            return IsEqual(argumentValidator, () => argument);
        }

        public static ArgumentValidatorBase<T> IsEqual<T>(this ArgumentValidatorBase<T> argumentValidator, Func<T> argument) where T : IComparable
        {
            if (argumentValidator.Value.CompareTo(argument()) != 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(argumentValidator);
            }

            return argumentValidator;
        }

        public static ArgumentValidatorBase<T> IsGreaterThan<T>(this ArgumentValidatorBase<T> argumentValidator, T argument) where T : IComparable
        {
            return IsGreaterThan(argumentValidator, () => argument);
        }

        public static ArgumentValidatorBase<T> IsGreaterThan<T>(this ArgumentValidatorBase<T> argumentValidator, Func<T> argument) where T : IComparable
        {
            if (argumentValidator.Value.CompareTo(argument()) <= 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(argumentValidator);
            }

            return argumentValidator;
        }

        public static ArgumentValidatorBase<T> IsLessThan<T>(this ArgumentValidatorBase<T> argumentValidator, T argument) where T : IComparable
        {
            return IsLessThan(argumentValidator, () => argument);
        }

        public static ArgumentValidatorBase<T> IsLessThan<T>(this ArgumentValidatorBase<T> argumentValidator, Func<T> argument) where T : IComparable
        {
            if (argumentValidator.Value.CompareTo(argument()) >= 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(argumentValidator);
            }

            return argumentValidator;
        }

        public static ArgumentValidatorBase<T> IsInRange<T>(this ArgumentValidatorBase<T> argumentValidator, T start, T end) where T : IComparable
        {
            if (argumentValidator.Value.CompareTo(start) < 0 || argumentValidator.Value.CompareTo(end) > 0)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(argumentValidator);
            }

            return argumentValidator;
        }
    }
}