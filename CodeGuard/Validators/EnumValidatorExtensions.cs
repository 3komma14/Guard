using System;
using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Validators
{
    public static class EnumValidatorExtensions
    {
        #region Public Methods

        public static IArg<TEnum> HasFlagSet<TEnum>(this IArg<TEnum> arg, TEnum flagValue)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<TEnum>>() != null);

            Enum value = arg.Value as Enum;
            Enum flagEnumValue = flagValue as Enum;
            if (value != null)
            {
                if (!value.HasFlag(flagEnumValue))
                {
                    arg.Message.Set("Value does not have flag set");
                }
            }

            return arg;
        }

        public static IArg<TEnum> IsValidValue<TEnum>(this IArg<TEnum> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<TEnum>>() != null);

            if (!Enum.IsDefined(arg.Value.GetType(), arg.Value))
            {
                arg.Message.Set("Value is not valid");
            }

            return arg;
        }

        #endregion Public Methods
    }
}
