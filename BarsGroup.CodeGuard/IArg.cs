using System.Collections.Generic;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard
{
    public interface IArg<T>
    {
        T Value { get; }
        ArgName Name { get; }
        bool HasName { get; }
        IMessageHandler<T> Message { get; }
        IEnumerable<ErrorInfo> Errors { get; }
    }

}