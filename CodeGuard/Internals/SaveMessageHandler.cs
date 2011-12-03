using System.Collections.Generic;
using System.Linq;

namespace Seterlund.CodeGuard.Internals
{
    internal class SaveMessageHandler<T> : IMessageHandler<T>
    {
        private readonly IArg<T> _arg;
        protected List<string> Result = new List<string>();

        public List<string> GetResult()
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
            if (!string.IsNullOrEmpty(_arg.Name))
            {
                if (!message.EndsWith("."))
                {
                    message += ". ";
                }
                message += "Param: " + _arg.Name;
            }
            Result.Add(message);
        }
    }
}
