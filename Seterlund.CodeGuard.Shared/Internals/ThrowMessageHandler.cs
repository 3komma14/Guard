using System;

namespace Seterlund.CodeGuard.Internals
{
    internal class ThrowMessageHandler<T> : IMessageHandler<T>
    {
        private readonly IArg<T> _arg;

        public ThrowMessageHandler(IArg<T> arg)
        {
            _arg = arg;
        }

        public void Set(string message)
        {
            if (string.IsNullOrEmpty(_arg.Name))
            {
                throw new ArgumentException(message);
            }

            throw new ArgumentException(message, _arg.Name);
        }

        public void SetArgumentNull()
        {
            if (string.IsNullOrEmpty(_arg.Name))
            {
                throw new ArgumentNullException();
            }

            throw new ArgumentNullException(_arg.Name);
        }

        public void SetArgumentOutRange()
        {
            if (string.IsNullOrEmpty(_arg.Name))
            {
                throw new ArgumentOutOfRangeException();
            }

            throw new ArgumentOutOfRangeException(_arg.Name);
        }
    }
}
