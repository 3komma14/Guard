using System;
using System.Collections.Generic;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard
{
    public interface IArg<T>
    {
        T Value { get; }
        ArgName Name { get; }
        IMessageHandler<T> Message { get; }
        IEnumerable<ErrorInfo> Errors { get; }
    }
}