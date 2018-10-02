namespace CodeGuard.dotNetCore.Internals
{
    internal class ErrorHandlerBase<T>
    {
        #region Public Constructors

        public ErrorHandlerBase(IArg<T> arg)
        {
            Arg = arg;
        }

        #endregion Public Constructors

        #region Public Properties
        public IArg<T> Arg { get; set; }
        #endregion Public Properties
    }
}
