using Seterlund.CodeGuard.Internals;
using System.Diagnostics.Contracts;

namespace Seterlund.CodeGuard
{
    public static class ArrayValidatorExtensions
    {
        public static IArg<T[]> IsNotEmpty<T>(this IArg<T[]> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<T[]>>() != null);
#endif
            if (arg.Value == null || arg.Value.Length == 0)
            {
                arg.Message.Set("Array is empty");
            }

            return arg;
        }

        public static IArg<T[]> CountIs<T>(this IArg<T[]> arg, int count)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<T[]>>() != null);
#endif
            if (arg.Value == null || arg.Value.Length != count)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }
   }
}