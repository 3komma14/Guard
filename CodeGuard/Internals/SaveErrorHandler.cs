namespace Seterlund.CodeGuard.Internals
{
    internal class SaveErrorHandler : IErrorHandler
    {
        public void ArgumentMessage<T>(Arg<T> arg, string message)
        {
            arg.AddResultItem(message);
        }

        public void ArgumentNullMessage<T>(Arg<T> arg)
        {
            arg.AddResultItem("Argument is null.");
        }

        public void ArgumentOutRangeMessage<T>(Arg<T> arg)
        {
            arg.AddResultItem("Argument is out of range.");
        }
    }
}
