using System.Text.RegularExpressions;

namespace Seterlund.CodeGuard
{
    public static class StringValidatorExtensions
    {
        public static Arg<string> IsNotEmpty(this Arg<string> arg)
        {
            if (arg.Value == string.Empty)
            {
                arg.ArgumentMessage("String is empty");
            }

            return arg;
        }

        public static Arg<string> IsNotNullOrEmpty(this Arg<string> arg)
        {
            if (string.IsNullOrEmpty(arg.Value))
            {
                arg.ArgumentMessage("String is null or empty");
            }

            return arg;
        }

        public static Arg<string> StartsWith(this Arg<string> arg, string value)
        {
            if (!arg.Value.StartsWith(value))
            {
                arg.ArgumentMessage(string.Format("String must start with <{0}>", value));
            }

            return arg;
        }

        public static Arg<string> EndsWith(this Arg<string> arg, string value)
        {
            if (!arg.Value.EndsWith(value))
            {
                arg.ArgumentMessage(string.Format("String must end with <{0}>", value));
            }

            return arg;
        }

        public static Arg<string> Length(this Arg<string> arg, int length)
        {
            if (arg.Value.Length != length)
            {
                arg.ArgumentMessage("String have wrong length");
            }

            return arg;
        }

        public static Arg<string> Contains(this Arg<string> arg, string value)
        {
            if (!arg.Value.Contains(value))
            {
                arg.ArgumentMessage(string.Format("String must contain <{0}>", value));
            }

            return arg;
        }

        public static Arg<string> IsMatch(this Arg<string> arg, string pattern)
        {
            var r = new Regex(pattern);
            if (!r.IsMatch(arg.Value))
            {
                arg.ArgumentMessage(string.Format("String must match <{0}>", pattern));
            }

            return arg;
        }


    }
}