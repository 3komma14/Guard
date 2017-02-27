using System;

namespace BarsGroup.CodeGuard.Validators
{
    public static class ClassValidatorExtensions
    {
        public static IArg<T> IsNotNull<T>(this IArg<T> arg)
        {
            if (arg == null)
                throw new ArgumentNullException(nameof(arg));

            if (arg.Value == null)
                arg.Message.SetArgumentNull();

            return arg;
        }
    }
}