using System;

namespace CodeGuard.dotNetCore.Internals
{
    public interface IMessageHandler<T> 
    {
        void Set(string message);
        void SetArgumentNull();
        void SetArgumentOutRange();
        void SetArgumentOutRange(string message);
        void SetArgumentOutRange(T min, T max);
        void SetArgumentLessThan(T min);
        void SetArgumentLargerThan(T max);
        void SetArgumentNotEqual(T expected);
    }
}
