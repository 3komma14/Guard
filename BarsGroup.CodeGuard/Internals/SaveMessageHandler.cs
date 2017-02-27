using System.Collections.Generic;
using BarsGroup.CodeGuard.Validators;

namespace BarsGroup.CodeGuard.Internals
{
    internal class SaveMessageHandler<T> : IMessageHandler<T>
    {
        private readonly IArg<T> _arg;
        protected List<ErrorInfo> Result = new List<ErrorInfo>();

        public SaveMessageHandler(IArg<T> arg)
        {
            Guard.That(arg).IsNotNull();


            _arg = arg;
        }


        public void Set(string message)
        {
            AddResultItem(message);
        }

        public void SetArgumentNull()
        {
            AddResultItem("Argument is null.");
        }

        public void SetArgumentOutRange()
        {
            AddResultItem("Argument is out of range.");
        }

        public void SetArgumentOutRange(string message)
        {
            AddResultItem(message);
        }

        public void SetArgumentOutRange(T min, T max)
        {
            var message = ErrorMessageFactory.OutOfRange(_arg, min, max);
            AddResultItem(message);
        }

        public void SetArgumentLessThan(T min)
        {
            var message = ErrorMessageFactory.LessThan(_arg, min);
            AddResultItem(message);
        }

        public void SetArgumentLargerThan(T max)
        {
            var message = ErrorMessageFactory.LessThan(_arg, max);
            AddResultItem(message);
        }

        public void SetArgumentNotEqual(T expected)
        {
            var message = ErrorMessageFactory.NotEqual(_arg, expected);
            AddResultItem(message);
        }

        public List<ErrorInfo> GetResult()
        {
            return Result;
        }

        private void AddResultItem(string message)
        {
            Result.Add(new ErrorInfo {Message = message, Name = _arg.Name});
        }
    }
}