using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Validators
{
    public static class ClassValidatorExtensions
    {
        public static IArg<T> NotNull<T>(this IArg<T> arg) where T : class
        {

            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<T>>() != null);

            if (arg.Value == null)
            {
                arg.Message.SetArgumentNull();
            }

            return arg;
        }
   }
}