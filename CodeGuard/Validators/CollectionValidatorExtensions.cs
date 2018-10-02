using System.Collections;
using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Validators
{
    public static class CollectionValidatorExtensions
    {
        #region Public Methods

        public static IArg<ICollection> IsNotEmpty(this IArg<ICollection> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<ICollection>>() != null);

            var value = arg.Value;
            if (value == null || value.Count > 0)
            {
                arg.Message.Set("Collection is empty");
            }

            return arg;
        }

        #endregion Public Methods
    }
}
