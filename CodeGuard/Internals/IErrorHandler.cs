namespace Seterlund.CodeGuard.Internals
{
    public interface IErrorHandler
    {
        void ArgumentMessage<T>(Arg<T> arg, string message);

        void ArgumentNullMessage<T>(Arg<T> arg);

        void ArgumentOutRangeMessage<T>(Arg<T> arg);
    }
}
