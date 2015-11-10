using System;
using System.Diagnostics.Contracts;
using Seterlund.CodeGuard.Exceptions;

namespace Seterlund.CodeGuard.Internals
{
    internal class ThrowMessageHandler<T> : IMessageHandler<T>
    {
        private readonly IArg<T> _arg;

        public ThrowMessageHandler(IArg<T> arg)
        {
#if !NET35    
            Contract.Requires(arg != null);
#endif
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

        public void SetArgumentOutRange(T min, T max)
        {
            var message = ErrorMessageFactory.OutOfRange(_arg, min, max);
            if (string.IsNullOrEmpty(_arg.Name))
            {                   
                throw new ArgumentOutOfRangeException(message, (Exception)null);
            }

            throw new ArgumentOutOfRangeException(_arg.Name, _arg.Value, message);
        }

        public void SetArgumentLessThan(T min)
        {
            var message = ErrorMessageFactory.LessThan(_arg, min);
            if (string.IsNullOrEmpty(_arg.Name))
            {
                throw new ArgumentOutOfRangeException(message, (Exception)null);
            }

            throw new ArgumentOutOfRangeException(_arg.Name, _arg.Value, message);
        }

        public void SetArgumentLargerThan(T max)
        {
            var message = ErrorMessageFactory.LessThan(_arg, max);
            if (string.IsNullOrEmpty(_arg.Name))
            {
                throw new ArgumentOutOfRangeException(message, (Exception)null);
            }

            throw new ArgumentOutOfRangeException(_arg.Name, _arg.Value, message);
        }

        public void SetArgumentNotEqual(T expected)
        {
            throw ArgumentOutOfRangeExceptionFactory.NotEqual(_arg, expected);
        }
    }
}
