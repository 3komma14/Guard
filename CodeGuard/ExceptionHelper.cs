using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seterlund.CodeGuard
{
    public class ExceptionHelper
    {
        public static void ThrowArgumentNullException<T>(ValidatorBase<T> validator)
        {
            if(string.IsNullOrEmpty(validator.Name))
            {
                throw new ArgumentNullException();
            }

            throw  new ArgumentNullException(validator.Name);
        }

        public static void ThrowArgumentOutOfRangeException<T>(ValidatorBase<T> validator)
        {
            if(string.IsNullOrEmpty(validator.Name))
            {
                throw new ArgumentOutOfRangeException();
            }

            throw new ArgumentOutOfRangeException(validator.Name);
        }

        public static void ThrowArgumentException<T>(ValidatorBase<T> validator, string message)
        {
            if(string.IsNullOrEmpty(validator.Name))
            {
                throw new ArgumentException(message);
            }

            throw new ArgumentException(message, validator.Name);
        }
    }
}
