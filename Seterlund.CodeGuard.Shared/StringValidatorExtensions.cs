using System.Text.RegularExpressions;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard
{
    public static class StringValidatorExtensions
    {
        public static IArg<string> IsNotEmpty(this IArg<string> arg)
        {
            if (arg.Value == string.Empty)
            {
                arg.Message.Set("String is empty");
            }

            return arg;
        }

        public static IArg<string> IsNotNullOrEmpty(this IArg<string> arg)
        {
            if (string.IsNullOrEmpty(arg.Value))
            {
                arg.Message.Set("String is null or empty");
            }

            return arg;
        }

        public static IArg<string> StartsWith(this IArg<string> arg, string value)
        {
            if (!arg.Value.StartsWith(value))
            {
                arg.Message.Set(string.Format("String must start with <{0}>", value));
            }

            return arg;
        }

        public static IArg<string> EndsWith(this IArg<string> arg, string value)
        {
            if (!arg.Value.EndsWith(value))
            {
                arg.Message.Set(string.Format("String must end with <{0}>", value));
            }

            return arg;
        }

        public static IArg<string> Length(this IArg<string> arg, int length)
        {
            if (arg.Value.Length != length)
            {
                arg.Message.Set("String have wrong length");
            }

            return arg;
        }

        public static IArg<string> Contains(this IArg<string> arg, string value)
        {
            if (!arg.Value.Contains(value))
            {
                arg.Message.Set(string.Format("String must contain <{0}>", value));
            }

            return arg;
        }

        public static IArg<string> IsMatch(this IArg<string> arg, string pattern)
        {
            var r = new Regex(pattern);
            if (!r.IsMatch(arg.Value))
            {
                arg.Message.Set(string.Format("String must match <{0}>", pattern));
            }

            return arg;
        }

        public static IArg<string> IsNotNullOrWhiteSpace(this IArg<string> arg)
        {
            if (arg.Value.IsNullOrWhiteSpace())
            {
                arg.Message.Set("String is null or whitespace");
            }

            return arg;
        }
    }
}