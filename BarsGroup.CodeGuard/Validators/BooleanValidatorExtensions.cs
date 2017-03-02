namespace BarsGroup.CodeGuard.Validators
{
    public static class BooleanValidatorExtensions
    {
        public static IArg<bool> IsTrue(this IArg<bool> arg)
        {
            Guard.That(arg).IsNotNull();

            return arg.IsEqual(true);
        }

        public static IArg<bool> IsFalse(this IArg<bool> arg)
        {
            Guard.That(arg).IsNotNull();

            return arg.IsEqual(false);
        }
    }
}