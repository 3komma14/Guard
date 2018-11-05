namespace CodeGuard.dotNetCore.Internals
{
    internal class ErrorHandlerBase<T>
    {
        #region Internal Constructors

        internal ErrorHandlerBase(IArg<T> arg)
        {
            Arg = arg;
        }

        #endregion Internal Constructors

        #region Public Properties
        public IArg<T> Arg { get; set; }
        #endregion Public Properties
    }
}
