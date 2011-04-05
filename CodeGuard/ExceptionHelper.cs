using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seterlund.CodeGuard
{
    public class ExceptionHelper
    {
        public static void ThrowArgumentNullException<T>(ArgumentValidatorBase<T> argumentValidator)
        {
            if(string.IsNullOrEmpty(argumentValidator.Name))
            {
                throw new ArgumentNullException();
            }

            throw  new ArgumentNullException(argumentValidator.Name);
        }

        public static void ThrowArgumentOutOfRangeException<T>(ArgumentValidatorBase<T> argumentValidator)
        {
            if(string.IsNullOrEmpty(argumentValidator.Name))
            {
                throw new ArgumentOutOfRangeException();
            }

            throw new ArgumentOutOfRangeException(argumentValidator.Name);
        }

        public static void ThrowArgumentException<T>(ArgumentValidatorBase<T> argumentValidator, string message)
        {
            if(string.IsNullOrEmpty(argumentValidator.Name))
            {
                throw new ArgumentException(message);
            }

            throw new ArgumentException(message, argumentValidator.Name);
        }
    }
}
