namespace Seterlund.CodeGuard
{
    public static class BooleanValidatorExtensions
    {
        public static Arg<bool> IsTrue(this Arg<bool> arg)
        {
            return IsValid(arg, true);
        }

        public static Arg<bool> IsFalse(this Arg<bool> arg)
        {
            return IsValid(arg, false);
        }

        private static Arg<bool> IsValid(Arg<bool> arg, bool expected)
        {
            if (arg.Value != expected)
            {
                arg.ArgumentOutRangeMessage();
            }

            return arg;
        }
    }
}