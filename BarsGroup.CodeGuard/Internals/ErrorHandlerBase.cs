namespace BarsGroup.CodeGuard.Internals
{
    internal class ErrorHandlerBase<T>
    {
        public ErrorHandlerBase(IArg<T> arg)
        {
            Arg = arg;
        }

        public IArg<T> Arg { get; set; }
    }
}