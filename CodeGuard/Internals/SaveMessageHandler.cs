using System.Collections.Generic;
using System.Linq;

namespace Seterlund.CodeGuard.Internals
{
    internal class SaveMessageHandler<T> : IMessageHandler<T>
    {
        private readonly IArg<T> _arg;
        protected List<ErrorInfo> Result = new List<ErrorInfo>();

        public List<ErrorInfo> GetResult()
        {
            return Result;
        }

        public SaveMessageHandler(IArg<T> arg)
        {
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

        private void AddResultItem(string message)
        {
            Result.Add(new ErrorInfo() {Message = message, Name = _arg.Name});
        }
    }
}
