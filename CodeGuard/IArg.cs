using System.Collections.Generic;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard
{
    public interface IArg<T>
    {
        T Value { get; }
        string Name { get; }
        IMessageHandler<T> Message { get; }
        IEnumerable<string> Errors { get; }
    }
}