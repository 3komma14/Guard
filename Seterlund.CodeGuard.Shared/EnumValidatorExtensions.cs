using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard
{
    public static class EnumValidatorExtensions
    {
        public static IArg<TEnum> IsValidValue<TEnum>(this IArg<TEnum> arg)
        {
            if (!Enum.IsDefined(arg.Value.GetType(), arg.Value))
            {
                arg.Message.Set("Value is not valid");
            }

            return arg;
        }

        public static IArg<TEnum> HasFlagSet<TEnum>(this IArg<TEnum> arg, TEnum flagValue)
        {
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
