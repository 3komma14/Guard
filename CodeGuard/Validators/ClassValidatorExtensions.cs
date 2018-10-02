using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Validators
{
    public static class ClassValidatorExtensions
    {
        #region Public Methods

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

        public static IArg<T> Null<T>(this IArg<T> arg) where T : class
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<T>>() != null);

            if (arg.Value != null)
            {
                arg.Message.SetArgumentNull();
            }

            return arg;
        }

        #endregion Public Methods
    }
}
