using System;
using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Validators
{
    public static class GuidValidatorExtensions
    {
        public static IArg<Guid> IsNotEmpty(this IArg<Guid> arg)
        {

            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<Guid>>() != null);

            if (Guid.Empty.Equals(arg.Value))
            {
                arg.Message.Set("Guid is empty");
            }

            return arg;
        }
    }
}
