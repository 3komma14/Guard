using System.Diagnostics.Contracts;

namespace Seterlund.CodeGuard.Validators
{
    public static class ClassValidatorExtensions
    {
        public static IArg<T> IsNotNull<T>(this IArg<T> arg) where T : class
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<T>>() != null);
#endif
            if (arg.Value == null)
            {
                arg.Message.SetArgumentNull();
            }

            return arg;
        }
   }
}