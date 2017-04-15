using System.Text.RegularExpressions;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class StringValidatorExtensions
    {
        public static ArgBase<string> IsNotEmpty(this ArgBase<string> arg)
        {
            Guard.That(arg.Value).IsNotNull();

            if (arg.Value == string.Empty)
                arg.ThrowArgument("String is empty");

            return arg;
        }

        public static ArgBase<string> IsNotNullOrEmpty(this ArgBase<string> arg)
        {
            Guard.That(arg.Value).IsNotNull();

            if (string.IsNullOrEmpty(arg.Value))
                arg.ThrowArgument("String is null or empty");

            return arg;
        }

        public static ArgBase<string> StartsWith(this ArgBase<string> arg, string value)
        {
            Guard.That(arg.Value).IsNotNull();


            if (!arg.Value.StartsWith(value))
                arg.ThrowArgument($"String must start with <{value}>");

            return arg;
        }

        public static ArgBase<string> EndsWith(this ArgBase<string> arg, string value)
        {
            Guard.That(arg.Value).IsNotNull();


            if (!arg.Value.EndsWith(value))
                arg.ThrowArgument($"String must end with <{value}>");

            return arg;
        }

        public static ArgBase<string> Length(this ArgBase<string> arg, int length)
        {
            Guard.That(arg.Value).IsNotNull();


            if (arg.Value.Length != length)
                arg.ThrowArgument("String have wrong length");

            return arg;
        }

        public static ArgBase<string> Contains(this ArgBase<string> arg, string value)
        {
            Guard.That(arg.Value).IsNotNull();


            if (!arg.Value.Contains(value))
                arg.ThrowArgument($"String must contain <{value}>");

            return arg;
        }

        public static ArgBase<string> IsMatch(this ArgBase<string> arg, string pattern)
        {
            Guard.That(arg.Value).IsNotNull();
            Guard.That(pattern).IsNotNullOrWhiteSpace();


            var r = new Regex(pattern);
            if (!r.IsMatch(arg.Value))
                arg.ThrowArgument($"String must match <{pattern}>");

            return arg;
        }

        public static ArgBase<string> IsNotNullOrWhiteSpace(this ArgBase<string> arg)
        {
            Guard.That(arg.Value).IsNotNull();


            if (string.IsNullOrWhiteSpace(arg.Value))
                arg.ThrowArgument("String is null or whitespace");

            return arg;
        }
    }
}