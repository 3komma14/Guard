using System;
using BarsGroup.CodeGuard.Exceptions;

namespace BarsGroup.CodeGuard.Internals
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
            if (!_arg.HasName)
                throw new ArgumentException(message);

            throw new ArgumentException(message, _arg.Name);
        }

        public void SetArgumentNull()
        {
            if (!_arg.HasName)
                throw new ArgumentNullException();

            throw new ArgumentNullException(_arg.Name);
        }

        public void SetArgumentOutRange()
        {
            if (!_arg.HasName)
                throw new ArgumentOutOfRangeException();

            throw new ArgumentOutOfRangeException(_arg.Name);
        }

        public void SetArgumentOutRange(string message)
        {
            if (!_arg.HasName)
                throw new ArgumentOutOfRangeException(message, (Exception) null);

            throw new ArgumentOutOfRangeException(_arg.Name, _arg.Value, message);
        }

        public void SetArgumentOutRange(T min, T max)
        {
            var message = ErrorMessageFactory.OutOfRange(_arg, min, max);
            SetArgumentOutRange(message);
        }

        public void SetArgumentLessThan(T min)
        {
            var message = ErrorMessageFactory.LessThan(_arg, min);
            SetArgumentOutRange(message);
        }

        public void SetArgumentLargerThan(T max)
        {
            var message = ErrorMessageFactory.LessThan(_arg, max);
            SetArgumentOutRange(message);
        }

        public void SetArgumentNotEqual(T expected)
        {
            throw ArgumentOutOfRangeExceptionFactory.NotEqual(_arg, expected);
        }
    }
}