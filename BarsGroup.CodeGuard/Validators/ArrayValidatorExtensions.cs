using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class ArrayValidatorExtensions
    {
        public static ArgBase<T[]> IsNotEmpty<T>(this ArgBase<T[]> arg)
        {
            arg.IsNotNull();

            if (arg.Value.Length == 0)
                arg.ThrowArgument("Array is empty");

            return arg;
        }

        public static ArgBase<T[]> CountIs<T>(this ArgBase<T[]> arg, int count)
        {
            arg.IsNotNull();

            if (arg.Value.Length != count)
                throw new NotExpectedException<int>(arg.Value.Length, count, arg.Name);

            return arg;
        }
    }
}