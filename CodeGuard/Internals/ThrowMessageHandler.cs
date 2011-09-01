using System;

namespace Seterlund.CodeGuard.Internals
{
    internal class ThrowMessageHandler : MessageHandler
    {
        public override void ArgumentMessage<T>(Arg<T> arg, string message)
        {
            if (string.IsNullOrEmpty(arg.Name))
            {
                throw new ArgumentException(message);
            }

            throw new ArgumentException(message, arg.Name);
        }

        public override void ArgumentNullMessage<T>(Arg<T> arg)
        {
            if (string.IsNullOrEmpty(arg.Name))
            {
                throw new ArgumentNullException();
            }

            throw new ArgumentNullException(arg.Name);
        }

        public override void ArgumentOutRangeMessage<T>(Arg<T> arg)
        {
            if (string.IsNullOrEmpty(arg.Name))
            {
                throw new ArgumentOutOfRangeException();
            }

            throw new ArgumentOutOfRangeException(arg.Name);
        }
    }
}
