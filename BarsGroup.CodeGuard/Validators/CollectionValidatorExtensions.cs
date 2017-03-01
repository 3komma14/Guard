using System.Collections;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class CollectionValidatorExtensions
    {
        public static IArg<ICollection> IsNotEmpty(this IArg<ICollection> arg)
        {
            Guard.That(arg).IsNotNull();

            var value = arg.Value;
            if (value == null || value.Count == 0)
                arg.ThrowArgument("Collection is empty");

            return arg;
        }
    }
}