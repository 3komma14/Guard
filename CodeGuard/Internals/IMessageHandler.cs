namespace Seterlund.CodeGuard.Internals
{
    public interface IMessageHandler<T>
    {
        void Set(string message);
        void SetArgumentNull();
        void SetArgumentOutRange();
    }
}
