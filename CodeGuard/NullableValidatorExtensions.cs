using System;
using System.Diagnostics.Contracts;

namespace Seterlund.CodeGuard
{
    public static class NullableValidatorExtensions
    {
        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <returns></returns>
        public static IArg<T?> IsNotNull<T>(this IArg<T?> arg) where T : struct 
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<T?>>() != null);
#endif
            var value = (Nullable<T>)arg.Value;
            if (!value.HasValue)
            {
                arg.Message.SetArgumentNull();
            }

            return arg;
        }

    }
}
