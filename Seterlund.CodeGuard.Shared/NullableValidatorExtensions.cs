using System;

namespace Seterlund.CodeGuard
{
    public static class NullableValidatorExtensions
    {
        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <returns></returns>
        public static IArg<T?> IsNotNull<T>(this IArg<T?> arg) where T: struct 
        {
            if (arg.Value == null || !arg.Value.HasValue)
            {
                arg.Message.SetArgumentNull();
            }

            return arg;
        }

    }
}
