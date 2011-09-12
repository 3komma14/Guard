using System.Collections;

namespace Seterlund.CodeGuard
{
    public static class CollectionValidatorExtensions
    {
        public static Arg<ICollection> IsNotEmpty(this Arg<ICollection> arg)
        {
            if (arg.Value.Count > 0)
            {
                arg.ArgumentMessage("Collection is empty");
            }

            return arg;
        }
    }
}
