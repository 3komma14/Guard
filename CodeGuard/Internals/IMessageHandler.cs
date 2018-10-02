namespace CodeGuard.dotNetCore.Internals
{
    public interface IMessageHandler<T>
    {
        #region Public Methods

        void Set(string message);

        void SetArgumentLargerThan(T max);

        void SetArgumentLessThan(T min);

        void SetArgumentNotEqual(T expected);

        void SetArgumentNull();

        void SetArgumentOutRange();

        void SetArgumentOutRange(string message);

        void SetArgumentOutRange(T min, T max);

        #endregion Public Methods
    }
}
