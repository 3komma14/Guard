using System;

namespace $rootnamespace$.CodeGuard
{
    public static class GuidValidatorExtensions
    {
        public static IArg<Guid> IsNotEmpty(this IArg<Guid> arg)
        {
            if (Guid.Empty.Equals(arg.Value))
            {
                arg.Message.Set("Guid is empty");
            }

            return arg;
        }
    }
}
