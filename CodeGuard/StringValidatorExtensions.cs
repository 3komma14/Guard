using System.Text.RegularExpressions;

namespace Seterlund.CodeGuard
{
    public static class StringValidatorExtensions
    {
        public static ArgumentBase<string> IsNotEmpty(this ArgumentBase<string> argument)
        {
            if (argument.Value == string.Empty)
            {
                argument.ArgumentMessage("String is empty");
            }

            return argument;
        }

        public static ArgumentBase<string> IsNotNullOrEmpty(this ArgumentBase<string> argument)
        {
            if (string.IsNullOrEmpty(argument.Value))
            {
                argument.ArgumentMessage("String is null or empty");
            }

            return argument;
        }

        public static ArgumentBase<string> StartsWith(this ArgumentBase<string> argument, string value)
        {
            if (!argument.Value.StartsWith(value))
            {
                argument.ArgumentMessage(string.Format("String must start with <{0}>", value));
            }

            return argument;
        }

        public static ArgumentBase<string> EndsWith(this ArgumentBase<string> argument, string value)
        {
            if (!argument.Value.EndsWith(value))
            {
                argument.ArgumentMessage(string.Format("String must end with <{0}>", value));
            }

            return argument;
        }

        public static ArgumentBase<string> Length(this ArgumentBase<string> argument, int length)
        {
            if (argument.Value.Length != length)
            {
                argument.ArgumentMessage("String have wrong length");
            }

            return argument;
        }

        public static ArgumentBase<string> Contains(this ArgumentBase<string> argument, string value)
        {
            if (!argument.Value.Contains(value))
            {
                argument.ArgumentMessage(string.Format("String must contain <{0}>", value));
            }

            return argument;
        }

        public static ArgumentBase<string> IsMatch(this ArgumentBase<string> argument, string pattern)
        {
            var r = new Regex(pattern);
            if (!r.IsMatch(argument.Value))
            {
                argument.ArgumentMessage(string.Format("String must match <{0}>", pattern));
            }

            return argument;
        }


    }
}