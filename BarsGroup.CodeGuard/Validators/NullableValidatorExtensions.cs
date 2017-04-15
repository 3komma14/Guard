using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class NullableValidatorExtensions
    {
        /// <summary>
        ///     Is argument instance of type
        /// </summary>
        /// <returns></returns>
        public static ArgBase<T?> IsNotNull<T>(this ArgBase<T?> arg) where T : struct
        {
            var value = arg.Value;
            if (!value.HasValue)
                arg.ThrowArgumentNull();

            return arg;
        }
    }
}