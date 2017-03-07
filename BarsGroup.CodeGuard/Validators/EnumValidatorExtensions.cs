using System;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class EnumValidatorExtensions
    {
        public static IArg<TEnum> IsValidValue<TEnum>(this IArg<TEnum> arg)
        {
            Guard.That(arg).IsNotNull();


            if (!Enum.IsDefined(arg.Value.GetType(), arg.Value))
                arg.ThrowArgument("Value is not valid");

            return arg;
        }

        public static IArg<TEnum> HasFlagSet<TEnum>(this IArg<TEnum> arg, TEnum flagValue)
        {
            Guard.That(arg).IsNotNull();


            var value = arg.Value as Enum;
            var flagEnumValue = flagValue as Enum;
            if (flagEnumValue != null && !value?.HasFlag(flagEnumValue) == true)
                arg.ThrowArgument("Value does not have flag set");

            return arg;
        }
    }
}