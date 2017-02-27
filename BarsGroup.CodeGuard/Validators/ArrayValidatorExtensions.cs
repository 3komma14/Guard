namespace BarsGroup.CodeGuard.Validators
{
    public static class ArrayValidatorExtensions
    {
        public static IArg<T[]> IsNotEmpty<T>(this IArg<T[]> arg)
        {
            Guard.That(arg).IsNotNull();

            if (arg.Value == null || arg.Value.Length == 0)
                arg.Message.Set("Array is empty");

            return arg;
        }

        public static IArg<T[]> CountIs<T>(this IArg<T[]> arg, int count)
        {
            Guard.That(arg).IsNotNull();

            if (arg.Value == null || arg.Value.Length != count)
                arg.Message.SetArgumentOutRange();

            return arg;
        }
    }
}