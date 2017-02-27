namespace BarsGroup.CodeGuard.Validators
{
    public static class NullableValidatorExtensions
    {
        /// <summary>
        ///     Is argument instance of type
        /// </summary>
        /// <returns></returns>
        public static IArg<T?> IsNotNull<T>(this IArg<T?> arg) where T : struct
        {
            Guard.That(arg).IsNotNull();

            var value = arg.Value;
            if (!value.HasValue)
                arg.Message.SetArgumentNull();

            return arg;
        }
    }
}