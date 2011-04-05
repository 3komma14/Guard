using System;

namespace Seterlund.CodeGuard
{
    public static class ClassValidatorExtensions
    {
        public static ArgumentValidatorBase<T> IsNotNull<T>(this ArgumentValidatorBase<T> argumentValidator) where T : class
        {
            if (argumentValidator.Value == null)
            {
                ExceptionHelper.ThrowArgumentNullException(argumentValidator);
            }

            return argumentValidator;
        }
   }
}