using System;

namespace Seterlund.CodeGuard
{
    public static class GuidValidatorExtensions
    {
        public static Arg<Guid> IsNotEmpty(this Arg<Guid> arg)
        {
            if (Guid.Empty.Equals(arg.Value))
            {
                arg.ArgumentMessage("Guid is empty");
            }

            return arg;
        }
    }
}
