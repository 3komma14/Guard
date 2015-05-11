using Seterlund.CodeGuard.Internals;
using System.Diagnostics.Contracts;

namespace Seterlund.CodeGuard
{
    public static class BooleanValidatorExtensions
    {
        public static IArg<bool> IsTrue(this IArg<bool> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
            Contract.Ensures(Contract.Result<IArg<bool>>() != null);
#endif
            return IsValid(arg, true);
        }

        public static IArg<bool> IsFalse(this IArg<bool> arg)
        {
#if !NET35
            Contract.Requires(arg != null);
            Contract.Ensures(arg != null);
            Contract.Ensures(Contract.Result<IArg<bool>>() != null);
#endif           
            return IsValid(arg, false);
        }

        private static IArg<bool> IsValid(IArg<bool> arg, bool expected)
        {            
            if (arg.Value != expected)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }
    }
}