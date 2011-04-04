using System;

namespace Seterlund.CodeGuard
{
    public static class IComparableValidatorExtensions
    {
        public static ArgumentValidator<T> IsEqual<T>(this ArgumentValidator<T> argumentValidator, T argument) where T : IComparable
        {
            return IsEqual(argumentValidator, () => argument);
        }

        public static ArgumentValidator<T> IsEqual<T>(this ArgumentValidator<T> argumentValidator, Func<T> argument) where T : IComparable
        {
            if (argumentValidator.Value.CompareTo(argument()) != 0)
            {
                argumentValidator.ThrowArgumentOutOfRangeException();
            }

            return argumentValidator;
        }

        public static ArgumentValidator<T> IsGreaterThan<T>(this ArgumentValidator<T> argumentValidator, T argument) where T : IComparable
        {
            return IsGreaterThan(argumentValidator, () => argument);
        }

        public static ArgumentValidator<T> IsGreaterThan<T>(this ArgumentValidator<T> argumentValidator, Func<T> argument) where T : IComparable
        {
            if (argumentValidator.Value.CompareTo(argument()) <= 0)
            {
                argumentValidator.ThrowArgumentOutOfRangeException();
            }

            return argumentValidator;
        }

        public static ArgumentValidator<T> IsLessThan<T>(this ArgumentValidator<T> argumentValidator, T argument) where T : IComparable
        {
            return IsLessThan(argumentValidator, () => argument);
        }

        public static ArgumentValidator<T> IsLessThan<T>(this ArgumentValidator<T> argumentValidator, Func<T> argument) where T : IComparable
        {
            if (argumentValidator.Value.CompareTo(argument()) >= 0)
            {
                argumentValidator.ThrowArgumentOutOfRangeException();
            }

            return argumentValidator;
        }

        public static ArgumentValidator<T> IsInRange<T>(this ArgumentValidator<T> argumentValidator, T start, T end) where T : IComparable
        {
            if (argumentValidator.Value.CompareTo(start) < 0 || argumentValidator.Value.CompareTo(end) > 0)
            {
                argumentValidator.ThrowArgumentOutOfRangeException();
            }

            return argumentValidator;
        }
    }
}