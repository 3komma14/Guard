using System;

namespace BarsGroup.CodeGuard.Validators
{
    public static class ComparableValidatorExtensions
    {
        public static IArg<T> IsEqual<T>(this IArg<T> arg, T param) where T : IComparable
        {
            Guard.That(arg).IsNotNull();

            if (arg.Value.CompareTo(param) != 0)
                arg.Message.SetArgumentNotEqual(param);

            return arg;
        }

        public static IArg<T> IsEqual<T>(this IArg<T> arg, Func<T> fun) where T : IComparable
        {
            Guard.That(arg).IsNotNull();
            Guard.That(fun).IsNotNull();


            return IsEqual(arg, fun());
        }

        public static IArg<T> IsNotEqual<T>(this IArg<T> arg, T param) where T : IComparable
        {
            Guard.That(arg).IsNotNull();

            if (arg.Value.CompareTo(param) == 0)
                arg.Message.SetArgumentOutRange();

            return arg;
        }

        public static IArg<T> IsNotEqual<T>(this IArg<T> arg, Func<T> param) where T : IComparable
        {
            Guard.That(arg).IsNotNull();
            Guard.That(param).IsNotNull();

            return IsNotEqual(arg, param());
        }

        public static IArg<T> IsGreaterThan<T>(this IArg<T> arg, T param) where T : IComparable
        {
            Guard.That(arg).IsNotNull();

            if (arg.Value.CompareTo(param) <= 0)
                arg.Message.SetArgumentOutRange();

            return arg;

        }

        public static IArg<T> IsGreaterThan<T>(this IArg<T> arg, Func<T> param) where T : IComparable
        {
            Guard.That(arg).IsNotNull();
            Guard.That(param).IsNotNull();


            return IsGreaterThan(arg, param());
        }

        public static IArg<T> IsGreaterThanOrEqualTo<T>(this IArg<T> arg, T param) where T : IComparable
        {
            Guard.That(arg).IsNotNull();

            if (arg.Value.CompareTo(param) < 0)
                arg.Message.SetArgumentOutRange();

            return arg;

        }

        public static IArg<T> IsGreaterThanOrEqualTo<T>(this IArg<T> arg, Func<T> param) where T : IComparable
        {
            Guard.That(arg).IsNotNull();
            Guard.That(param).IsNotNull();

            return IsGreaterThanOrEqualTo(arg,  param());
        }

        public static IArg<T> IsLessThan<T>(this IArg<T> arg, T param) where T : IComparable
        {
            Guard.That(arg).IsNotNull();



            if (arg.Value.CompareTo(param) >= 0)
                arg.Message.SetArgumentOutRange();

            return arg;
        }

        public static IArg<T> IsLessThan<T>(this IArg<T> arg, Func<T> param) where T : IComparable
        {
            Guard.That(arg).IsNotNull();
            Guard.That(param).IsNotNull();

            return IsLessThan(arg,  param());
        }

        public static IArg<T> IsLessThanOrEqualTo<T>(this IArg<T> arg, T param) where T : IComparable
        {
            Guard.That(arg).IsNotNull();

            if (arg.Value.CompareTo(param) > 0)
                arg.Message.SetArgumentOutRange();

            return arg;
            
        }

        public static IArg<T> IsLessThanOrEqualTo<T>(this IArg<T> arg, Func<T> param) where T : IComparable
        {
            Guard.That(arg).IsNotNull();
            Guard.That(param).IsNotNull();

            return IsLessThanOrEqualTo(arg,  param());

        }

        public static IArg<T> IsInRange<T>(this IArg<T> arg, T start, T end) where T : IComparable
        {
            Guard.That(arg).IsNotNull();


            if (arg.Value.CompareTo(start) < 0 || arg.Value.CompareTo(end) > 0)
                arg.Message.SetArgumentOutRange(start, end);

            return arg;
        }
    }
}