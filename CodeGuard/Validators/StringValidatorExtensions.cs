using CodeGuard.dotNetCore.Internals;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace CodeGuard.dotNetCore.Validators
{
    public static class StringValidatorExtensions
    {
        #region Public Methods

        public static IArg<string> Contains(this IArg<string> arg, string value)
        {
            Contract.Requires(arg != null);
            Contract.Requires(arg.Value != null);
            Contract.Requires(value != null);
            Contract.Ensures(Contract.Result<IArg<string>>() != null);

            if (!arg.Value.Contains(value))
            {
                arg.Message.Set(string.Format("String must contain <{0}>", value));
            }

            return arg;
        }

        public static IArg<string> EndsWith(this IArg<string> arg, string value)
        {
            Contract.Requires(arg != null);
            Contract.Requires(arg.Value != null);
            Contract.Requires(value != null);
            Contract.Ensures(Contract.Result<IArg<string>>() != null);

            if (!arg.Value.EndsWith(value))
            {
                arg.Message.Set(string.Format("String must end with <{0}>", value));
            }

            return arg;
        }

        public static IArg<string> IsEmpty(this IArg<string> arg)
        {
            Contract.Requires(arg != null);
            Contract.Requires(arg.Value != null);
            Contract.Ensures(Contract.Result<IArg<string>>() != null);

            if (arg.Value != string.Empty)
            {
                arg.Message.Set("String is not empty");
            }

            return arg;
        }

        public static IArg<string> IsMatch(this IArg<string> arg, string pattern)
        {
            Contract.Requires(arg != null);
            Contract.Requires(arg.Value != null);
            Contract.Requires(!string.IsNullOrWhiteSpace(pattern));
            Contract.Ensures(Contract.Result<IArg<string>>() != null);

            var r = new Regex(pattern);
            if (!r.IsMatch(arg.Value))
            {
                arg.Message.Set(string.Format("String must match <{0}>", pattern));
            }

            return arg;
        }

        public static IArg<string> IsNotEmpty(this IArg<string> arg)
        {
            Contract.Requires(arg != null);
            Contract.Requires(arg.Value != null);
            Contract.Ensures(Contract.Result<IArg<string>>() != null);

            if (arg.Value == string.Empty)
            {
                arg.Message.Set("String is empty");
            }

            return arg;
        }

        public static IArg<string> IsNullOrEmpty(this IArg<string> arg)
        {
            Contract.Requires(arg != null);
            Contract.Requires(arg.Value != null);
            Contract.Ensures(Contract.Result<IArg<string>>() != null);

            if (!string.IsNullOrEmpty(arg.Value))
            {
                arg.Message.Set("String is not null or empty");
            }

            return arg;
        }

        public static IArg<string> IsNullOrWhiteSpace(this IArg<string> arg)
        {
            Contract.Requires(arg != null);
            Contract.Requires(arg.Value != null);
            Contract.Ensures(Contract.Result<IArg<string>>() != null);

            if (!arg.Value.IsNullOrWhiteSpace())
            {
                arg.Message.Set("String is not null or whitespace");
            }

            return arg;
        }

        public static IArg<string> Length(this IArg<string> arg, int length)
        {
            Contract.Requires(arg != null);
            Contract.Requires(arg.Value != null);
            Contract.Ensures(Contract.Result<IArg<string>>() != null);

            if (arg.Value.Length != length)
            {
                arg.Message.Set("String have wrong length");
            }

            return arg;
        }

        public static IArg<string> NotNullOrEmpty(this IArg<string> arg)
        {
            Contract.Requires(arg != null);
            Contract.Requires(arg.Value != null);
            Contract.Ensures(Contract.Result<IArg<string>>() != null);

            if (string.IsNullOrEmpty(arg.Value))
            {
                arg.Message.Set("String is null or empty");
            }

            return arg;
        }

        public static IArg<string> NotNullOrWhiteSpace(this IArg<string> arg)
        {
            Contract.Requires(arg != null);
            Contract.Requires(arg.Value != null);
            Contract.Ensures(Contract.Result<IArg<string>>() != null);

            if (arg.Value.IsNullOrWhiteSpace())
            {
                arg.Message.Set("String is null or whitespace");
            }

            return arg;
        }

        public static IArg<string> StartsWith(this IArg<string> arg, string value)
        {
            Contract.Requires(arg != null);
            Contract.Requires(arg.Value != null);
            Contract.Requires(value != null);
            Contract.Ensures(Contract.Result<IArg<string>>() != null);

            if (!arg.Value.StartsWith(value))
            {
                arg.Message.Set(string.Format("String must start with <{0}>", value));
            }

            return arg;
        }

        #endregion Public Methods
    }
}
