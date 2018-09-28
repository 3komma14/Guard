using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Internals
{
    internal class SaveMessageHandler<T> : IMessageHandler<T>
    {
        #region Protected Fields
        protected List<ErrorInfo> Result = new List<ErrorInfo>();
        #endregion Protected Fields

        #region Private Fields
        private readonly IArg<T> _arg;
        #endregion Private Fields

        #region Public Constructors

        public SaveMessageHandler(IArg<T> arg)
        {
            Contract.Requires(arg != null);

            _arg = arg;
        }

        #endregion Public Constructors

        #region Public Methods

        public List<ErrorInfo> GetResult()
        {
            return Result;
        }

        public void Set(string message)
        {
            AddResultItem(message);
        }

        public void SetArgumentLargerThan(T max)
        {
            var message = ErrorMessageFactory.LessThan(_arg, max);
            AddResultItem(message);
        }

        public void SetArgumentLessThan(T min)
        {
            var message = ErrorMessageFactory.LessThan(_arg, min);
            AddResultItem(message);
        }

        public void SetArgumentNotEqual(T expected)
        {
            var message = ErrorMessageFactory.NotEqual(_arg, expected);
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

        #endregion Public Methods

        #region Private Methods

        private void AddResultItem(string message)
        {
            Result.Add(new ErrorInfo() { Message = message, Name = _arg.Name });
        }

        #endregion Private Methods
    }
}
