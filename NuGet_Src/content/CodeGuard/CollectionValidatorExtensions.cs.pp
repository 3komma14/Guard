using System.Collections;

namespace $rootnamespace$.CodeGuard
{
    public static class CollectionValidatorExtensions
    {
        public static IArg<ICollection> IsNotEmpty(this IArg<ICollection> arg)
        {
            if (arg.Value.Count > 0)
            {
                arg.Message.Set("Collection is empty");
            }

            return arg;
        }
    }
}
