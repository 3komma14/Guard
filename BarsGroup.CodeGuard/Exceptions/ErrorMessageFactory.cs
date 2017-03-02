namespace BarsGroup.CodeGuard.Exceptions
{
    public static class ErrorMessageFactory
    {

        public static string NotPrimeNumber<T>(IArg<T> arg)
        {
            return string.Format("The value '{0}' is not a prime number", arg.Value);
        }

        public static string NotEvenNumber<T>(IArg<T> arg)
        {
            return string.Format("The value '{0}' is not a even number", arg.Value);
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