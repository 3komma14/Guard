namespace Seterlund.CodeGuard
{
    public static class BooleanValidatorExtensions
    {
        public static ArgumentBase<bool> IsTrue(this ArgumentBase<bool> argument)
        {
            return IsValid(argument, true);
        }

        public static ArgumentBase<bool> IsFalse(this ArgumentBase<bool> argument)
        {
            return IsValid(argument, false);
        }

        private static ArgumentBase<bool> IsValid(ArgumentBase<bool> argument, bool expected)
        {
            if (argument.Value != expected)
            {
                argument.ArgumentOutRangeMessage();
            }

            return argument;
        }
    }
}