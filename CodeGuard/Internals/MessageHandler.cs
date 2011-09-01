namespace Seterlund.CodeGuard.Internals
{
    public abstract class MessageHandler
    {
        public abstract void ArgumentMessage<T>(Arg<T> arg, string message);

        public abstract void ArgumentNullMessage<T>(Arg<T> arg);

        public abstract void ArgumentOutRangeMessage<T>(Arg<T> arg);
    }
}
