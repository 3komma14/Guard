using System;

namespace Seterlund.CodeGuard
{
    public static class ClassValidatorExtensions
    {
        public static ArgumentValidator<T> IsNotNull<T>(this ArgumentValidator<T> argumentValidator) where T : class
        {
            if (argumentValidator.Value == null)
            {
                argumentValidator.ThrowArgumentNullException();
            }

            return argumentValidator;
        }

    }
}