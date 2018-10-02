using System;
using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Validators
{
    public static class NullableValidatorExtensions
    {
        #region Public Methods

        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <returns></returns>
        public static IArg<T?> NotNull<T>(this IArg<T?> arg) where T : struct
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<T?>>() != null);

            var value = (Nullable<T>)arg.Value;
            if (!value.HasValue)
            {
                arg.Message.SetArgumentNull();
            }

            return arg;
        }

        #endregion Public Methods
    }
}
