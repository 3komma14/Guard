namespace Seterlund.CodeGuard
{
    public static class StringValidatorExtensions
    {
        public static ArgumentValidator<string> IsNotEmpty(this ArgumentValidator<string> argumentValidator)
        {
            if (argumentValidator.Value == string.Empty)
            {
                argumentValidator.ThrowArgumentException("String is empty");
            }

            return argumentValidator;
        }

        public static ArgumentValidator<string> IsNotNullOrEmpty(this ArgumentValidator<string> argumentValidator)
        {
            if (string.IsNullOrEmpty(argumentValidator.Value))
            {
                argumentValidator.ThrowArgumentException("String is null or empty");
            }

            return argumentValidator;
        }

    }
}