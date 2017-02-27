namespace BarsGroup.CodeGuard.Validators
{
    public static class BooleanValidatorExtensions
    {
        public static IArg<bool> IsTrue(this IArg<bool> arg)
        {
            Guard.That(arg).IsNotNull();

            return IsValid(arg, true);
        }

        public static IArg<bool> IsFalse(this IArg<bool> arg)
        {
            Guard.That(arg).IsNotNull();

            return IsValid(arg, false);
        }

        private static IArg<bool> IsValid(IArg<bool> arg, bool expected)
        {
            if (arg.Value != expected)
                arg.Message.SetArgumentOutRange();

            return arg;
        }
    }
}