namespace Seterlund.CodeGuard.Internals
{
    internal class SaveMessageHandler : MessageHandler
    {
        public override void ArgumentMessage<T>(Arg<T> arg, string message)
        {
            arg.AddResultItem(message);
        }

        public override void ArgumentNullMessage<T>(Arg<T> arg)
        {
            arg.AddResultItem("Argument is null.");
        }

        public override void ArgumentOutRangeMessage<T>(Arg<T> arg)
        {
            arg.AddResultItem("Argument is out of range.");
        }
    }
}
