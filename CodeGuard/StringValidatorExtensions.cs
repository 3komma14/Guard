namespace Seterlund.CodeGuard
{
    public static class StringValidatorExtensions
    {
        public static ArgumentValidatorBase<string> IsNotEmpty(this ArgumentValidatorBase<string> argumentValidator)
        {
            if (argumentValidator.Value == string.Empty)
            {
                ExceptionHelper.ThrowArgumentException(argumentValidator, "String is empty");
            }

            return argumentValidator;
        }

        public static ArgumentValidatorBase<string> IsNotNullOrEmpty(this ArgumentValidatorBase<string> argumentValidator)
        {
            if (string.IsNullOrEmpty(argumentValidator.Value))
            {
                ExceptionHelper.ThrowArgumentException(argumentValidator, "String is null or empty");
            }

            return argumentValidator;
        }

    }
}