using System;
using System.Diagnostics.Contracts;

namespace Seterlund.CodeGuard.Validators
{
    public static class GuidValidatorExtensions
    {
        public static IArg<Guid> IsNotEmpty(this IArg<Guid> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<Guid>>() != null);
#endif
            if (Guid.Empty.Equals(arg.Value))
            {
                arg.Message.Set("Guid is empty");
            }

            return arg;
        }
    }
}
