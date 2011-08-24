using System;

namespace Seterlund.CodeGuard.Internals
{
    public class ExceptionHelper
    {
        public static void ThrowArgumentNullException<T>(ArgumentBase<T> argument)
        {
            if(string.IsNullOrEmpty(argument.Name))
            {
                throw new ArgumentNullException();
            }

            throw  new ArgumentNullException(argument.Name);
        }

        public static void ThrowArgumentOutOfRangeException<T>(ArgumentBase<T> argument)
        {
            if(string.IsNullOrEmpty(argument.Name))
            {
                throw new ArgumentOutOfRangeException();
            }

            throw new ArgumentOutOfRangeException(argument.Name);
        }

        public static void ThrowArgumentException<T>(ArgumentBase<T> argument, string message)
        {
            if(string.IsNullOrEmpty(argument.Name))
            {
                throw new ArgumentException(message);
            }

            throw new ArgumentException(message, argument.Name);
        }
    }
}
