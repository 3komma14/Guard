using System;

namespace Seterlund.CodeGuard
{
    public static class ClassValidatorExtensions
    {
        public static ValidatorBase<T> IsNotNull<T>(this ValidatorBase<T> validator) where T : class
        {
            if (validator.Value == null)
            {
                ExceptionHelper.ThrowArgumentNullException(validator);
            }

            return validator;
        }
   }
}