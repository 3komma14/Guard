using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Validators
{
    public static class ArrayValidatorExtensions
    {
        #region Public Methods

        public static IArg<T[]> CountIs<T>(this IArg<T[]> arg, int count)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<T[]>>() != null);

            if (arg.Value == null || arg.Value.Length != count)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<T[]> IsNotEmpty<T>(this IArg<T[]> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<T[]>>() != null);

            if (arg.Value == null || arg.Value.Length == 0)
            {
                arg.Message.Set("Array is empty");
            }

            return arg;
        }

        #endregion Public Methods
    }
}
