namespace Seterlund.CodeGuard
{
    public static class BooleanValidatorExtensions
    {
        public static ArgumentValidator<bool> IsTrue(this ArgumentValidator<bool> argumentValidator)
        {
            return IsValid(argumentValidator, true);
        }

        public static ArgumentValidator<bool> IsFalse(this ArgumentValidator<bool> argumentValidator)
        {
            return IsValid(argumentValidator, false);
        }

        private static ArgumentValidator<bool> IsValid(ArgumentValidator<bool> argumentValidator, bool expected)
        {
            if (argumentValidator.Value != expected)
            {
                argumentValidator.ThrowArgumentOutOfRangeException();
            }

            return argumentValidator;
        }
    }
}