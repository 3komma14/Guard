namespace BarsGroup.CodeGuard.Exceptions
{
    public static class ErrorMessageFactory
    {
        public static string LargerThan<T>(IArg<T> arg, T max)
        {
            return !arg.HasName
                ? string.Format("The value '{0}' is larger than '{1}'", arg.Value, max)
                : string.Format("The value '{0}' of '{1}' is larger than '{2}'", arg.Value, arg.Name, max);
        }

        public static string LessThan<T>(IArg<T> arg, T min)
        {
            return !arg.HasName ? string.Format("The value '{0}' is less than '{1}'", arg.Value, min) : string.Format("The value '{0}' of '{1}' is less than '{2}'", arg.Value, arg.Name, min);
        }

        public static string NotEqual<T>(IArg<T> arg, T expected)
        {
            return string.Format("The value '{0}' is not equal to '{1}'", arg.Value, expected);
        }

        public static string NotPrimeNumber<T>(IArg<T> arg)
        {
            return string.Format("The value '{0}' is not a prime number", arg.Value);
        }

        public static string NotEvenNumber<T>(IArg<T> arg)
        {
            return string.Format("The value '{0}' is not a even number", arg.Value);
        }

        public static string NotOddNumber<T>(IArg<T> arg)
        {
            return string.Format("The value '{0}' is not a odd number", arg.Value);
        }

        public static string NotPositiveNumber<T>(IArg<T> arg)
        {
            return string.Format("The value '{0}' is not a positive number", arg.Value);
        }

        public static string NotNegativeNumber<T>(IArg<T> arg)
        {
            return string.Format("The value '{0}' is not a negative number", arg.Value);
        }
    }
}