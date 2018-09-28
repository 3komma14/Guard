﻿using CodeGuard.dotNetCore.Internals;
using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Validators
{
    public static class IntegerValidatorExtensions
    {
        #region Public Methods

        public static IArg<int> IsEven(this IArg<int> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);

            if (!MathUtil.IsEven(arg.Value))
            {
                var message = ErrorMessageFactory.NotEvenNumber(arg);
                arg.Message.SetArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<long> IsEven(this IArg<long> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);

            if (!MathUtil.IsEven(arg.Value))
            {
                var message = ErrorMessageFactory.NotEvenNumber(arg);
                arg.Message.SetArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<long> IsNegative(this IArg<long> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<long>>() != null);

            if (arg.Value >= 0)
            {
                var message = ErrorMessageFactory.NotNegativeNumber(arg);
                arg.Message.SetArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<int> IsNegative(this IArg<int> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<int>>() != null);

            if (arg.Value >= 0)
            {
                var message = ErrorMessageFactory.NotNegativeNumber(arg);
                arg.Message.SetArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<int> IsOdd(this IArg<int> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);

            if (!MathUtil.IsOdd(arg.Value))
            {
                var message = ErrorMessageFactory.NotOddNumber(arg);
                arg.Message.SetArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<long> IsOdd(this IArg<long> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);

            if (!MathUtil.IsOdd(arg.Value))
            {
                var message = ErrorMessageFactory.NotOddNumber(arg);
                arg.Message.SetArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<long> IsPositive(this IArg<long> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);

            if (arg.Value <= 0)
            {
                var message = ErrorMessageFactory.NotPositiveNumber(arg);
                arg.Message.SetArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<int> IsPositive(this IArg<int> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);

            if (arg.Value <= 0)
            {
                var message = ErrorMessageFactory.NotPositiveNumber(arg);
                arg.Message.SetArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<int> IsPrime(this IArg<int> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);

            if (!MathUtil.IsPrime(arg.Value))
            {
                var message = ErrorMessageFactory.NotPrimeNumber(arg);
                arg.Message.SetArgumentOutRange(message);
            }

            return arg;
        }

        public static IArg<long> IsPrime(this IArg<long> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);

            if (!MathUtil.IsPrime(arg.Value))
            {
                var message = ErrorMessageFactory.NotPrimeNumber(arg);
                arg.Message.SetArgumentOutRange(message);
            }

            return arg;
        }

        #endregion Public Methods
    }
}
