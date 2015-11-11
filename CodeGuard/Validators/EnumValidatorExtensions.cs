using System;
using System.Diagnostics.Contracts;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard.Validators
{
    public static class EnumValidatorExtensions
    {
        public static IArg<TEnum> IsValidValue<TEnum>(this IArg<TEnum> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<TEnum>>() != null);
#endif
            if (!Enum.IsDefined(arg.Value.GetType(), arg.Value))
            {
                arg.Message.Set("Value is not valid");
            }

            return arg;
        }

        public static IArg<TEnum> HasFlagSet<TEnum>(this IArg<TEnum> arg, TEnum flagValue)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<TEnum>>() != null);
#endif
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
    }
}
