using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class ArrayValidatorExtensions
    {
        public static ArgBase<T[]> IsNotEmpty<T>(this ArgBase<T[]> arg)
        {
            if (arg.Value == null || arg.Value.Length == 0)
                arg.ThrowArgument("Array is empty");

            return arg;
        }

        public static ArgBase<T[]> CountIs<T>(this ArgBase<T[]> arg, int count)
        {
            Guard.That(arg.Value.Length, arg.Name).IsEqual(count);

            return arg;
        }
    }
}