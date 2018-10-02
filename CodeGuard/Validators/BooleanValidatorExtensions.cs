using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Validators
{
    public static class BooleanValidatorExtensions
    {
        #region Public Methods

        public static IArg<bool> IsFalse(this IArg<bool> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
            Contract.Ensures(Contract.Result<IArg<bool>>() != null);

            return IsValid(arg, false);
        }

        public static IArg<bool> IsTrue(this IArg<bool> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
            Contract.Ensures(Contract.Result<IArg<bool>>() != null);

            return IsValid(arg, true);
        }

        #endregion Public Methods

        #region Private Methods

        private static IArg<bool> IsValid(IArg<bool> arg, bool expected)
        {
            if (arg.Value != expected)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        #endregion Private Methods
    }
}
