using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seterlund.CodeGuard.Internals
{
    internal class ErrorHandlerBase<T>
    {
        public IArg<T> Arg { get; set; }

        public ErrorHandlerBase(IArg<T> arg)
        {
            Arg = arg;
        }
    }
}
