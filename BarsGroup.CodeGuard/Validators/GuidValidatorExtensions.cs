using System;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class GuidValidatorExtensions
    {
        public static IArg<Guid> IsNotEmpty(this IArg<Guid> arg)
        {
            Guard.That(arg).IsNotNull();

            if (arg.Value.Equals(Guid.Empty))
                arg.ThrowArgument("Guid is empty");

            return arg;
        }
    }
}