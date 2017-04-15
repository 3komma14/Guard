using System;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class EnumValidatorExtensions
    {
        public static ArgBase<TEnum> IsValidValue<TEnum>(this ArgBase<TEnum> arg)
        {
            if (!Enum.IsDefined(arg.Value.GetType(), arg.Value))
                arg.ThrowArgument("Value is not valid");

            return arg;
        }

        public static ArgBase<TEnum> HasFlagSet<TEnum>(this ArgBase<TEnum> arg, TEnum flagValue)
        {
            var value = arg.Value as Enum;
            var flagEnumValue = flagValue as Enum;
            if (flagEnumValue != null && !value?.HasFlag(flagEnumValue) == true)
                arg.ThrowArgument("Value does not have flag set");

            return arg;
        }
    }
}