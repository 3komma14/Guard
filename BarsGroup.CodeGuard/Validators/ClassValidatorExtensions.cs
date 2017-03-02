using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class ClassValidatorExtensions
    {
        public static IArg<T> IsNotNull<T>(this IArg<T> arg)
        {
            if (arg == null)
                throw new ArgumentNullException(nameof(arg));

            if (arg.Value == null)
                arg.ThrowArgumentNull();

            return arg;
        }

        public static IArg<T> Is<T, TType>(this IArg<T> arg)
        {
            if (!(arg.Value is TType))
                arg.ThrowArgument(string.Format("Value is not <{0}>", typeof(TType).Name));

            return arg;
        }
    }
}