using System;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class GuidValidatorExtensions
    {
        public static ArgBase<Guid> IsNotEmpty(this ArgBase<Guid> arg)
        {
            if (arg.Value.Equals(Guid.Empty))
                arg.ThrowArgument("Guid is empty");

            return arg;
        }
    }
}