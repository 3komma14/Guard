using System.Collections;
using System.Diagnostics.Contracts;

namespace Seterlund.CodeGuard
{
    public static class CollectionValidatorExtensions
    {
        public static IArg<ICollection> IsNotEmpty(this IArg<ICollection> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<ICollection>>() != null);
#endif
            var value = arg.Value;
            if (value == null || value.Count > 0)
            {
                arg.Message.Set("Collection is empty");
            }

            return arg;
        }
    }
}
