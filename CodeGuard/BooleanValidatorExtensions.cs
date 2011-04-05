namespace Seterlund.CodeGuard
{
    public static class BooleanValidatorExtensions
    {
        public static ArgumentValidatorBase<bool> IsTrue(this ArgumentValidatorBase<bool> argumentValidator)
        {
            return IsValid(argumentValidator, true);
        }

        public static ArgumentValidatorBase<bool> IsFalse(this ArgumentValidatorBase<bool> argumentValidator)
        {
            return IsValid(argumentValidator, false);
        }

        private static ArgumentValidatorBase<bool> IsValid(ArgumentValidatorBase<bool> argumentValidator, bool expected)
        {
            if (argumentValidator.Value != expected)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(argumentValidator);
            }

            return argumentValidator;
        }
    }
}