using System;
using System.Collections.Generic;
using $rootnamespace$.CodeGuard.Internals;

namespace $rootnamespace$.CodeGuard
{
    public interface IArg<T>
    {
        T Value { get; }
        ArgName Name { get; }
        IMessageHandler<T> Message { get; }
        IEnumerable<ErrorInfo> Errors { get; }
    }
}
