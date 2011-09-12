using System;

namespace Seterlund.CodeGuard.Internals
{
    internal class ThrowErrorHandler : IErrorHandler
    {
        public void ArgumentMessage<T>(Arg<T> arg, string message)
        {
            if (string.IsNullOrEmpty(arg.Name))
            {
                throw new ArgumentException(message);
            }

            throw new ArgumentException(message, arg.Name);
        }

        public void ArgumentNullMessage<T>(Arg<T> arg)
        {
            if (string.IsNullOrEmpty(arg.Name))
            {
                throw new ArgumentNullException();
            }

            throw new ArgumentNullException(arg.Name);
        }

        public void ArgumentOutRangeMessage<T>(Arg<T> arg)
        {
            if (string.IsNullOrEmpty(arg.Name))
            {
                throw new ArgumentOutOfRangeException();
            }

            throw new ArgumentOutOfRangeException(arg.Name);
        }
    }
}
