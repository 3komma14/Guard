using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard
{
    public static class Guard
    {
        public static ArgBase<T> That<T>(T argument, string argumentName = "")
        {
            return new ArgBase<T>(argument, argumentName);
        }
    }
}